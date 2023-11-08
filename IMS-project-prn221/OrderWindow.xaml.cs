using IMS_project_prn221.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IMS_project_prn221
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    /// 
    public partial class OrderWindow : Window
    {
        private readonly InventoryManagementContext _context = new InventoryManagementContext();
        private int productAmount = 0; 
        private float productPrice = 0;
        private int warehouseId;
        private int productId;
        private int providerId;
   
        public OrderWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            OrderWindowLoad();
        }
        private void OrderWindowLoad() { 
            var listProvider = _context.Providers.ToList();
            foreach (var provider in listProvider)
            {
                supplierComboBox.Items.Add(provider.ProviderName);
            }
            var listWarehouse = _context.Warehouses.ToList();

            foreach (var Warehouse in listWarehouse)
            {
                warehouseComboBox.Items.Add(Warehouse.WarehouseName + " còn trống " + (((calVOfProduct(Warehouse.WarehouseId)) * 100)/ calVOfWarehouse50Percent(Warehouse.WarehouseId)).ToString("0.00") + "%");
            }
        }

        private void supplierComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedSupp = ((ComboBox)sender).SelectedItem.ToString();
            int ProviderId = _context.Providers.FirstOrDefault(provider => provider.ProviderName == selectedSupp).ProviderId;
            var products =_context.Products.Where(x => x.ProviderId == ProviderId).ToList();
            itemListView.ItemsSource = products.ToList();
        }


        public float calVOfProduct(int warehouseId) {

            var listProduct = from x in _context.Inventories
                              where x.WarehouseId == warehouseId
                              select x;
            float VOfAllProduct = 0;
            foreach (var product in listProduct.ToList()) {
            var  product1 = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                VOfAllProduct += (float)(product1.PackedDepth * product1.PackedHeight * product1.PackedWidth * product.QuantityAvaiable);
            }
            return VOfAllProduct;
        }
        public float calVOfWarehouse50Percent(int warehouseId)
        {
            Warehouse warehouse = _context.Warehouses.FirstOrDefault(x => x.WarehouseId == warehouseId);

            return (float)((float)(warehouse.Height * warehouse.Length * warehouse.Width)*0.5);
        }

      
        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedValue = warehouseComboBox.SelectedItem.ToString();
            string[] parts = selectedValue.Split(' ');
            string result = parts[0];
            int warehouseid = ((Warehouse)(_context.Warehouses.FirstOrDefault(x => x.WarehouseName.Equals(result)))).WarehouseId;
            Product pr = itemListView.SelectedItem as Product;
            if (pr != null)
            {

                try
                {
                    productAmount = Int32.Parse(quantityTextBox.Text);
                    totalAmountTextBlock.Text = (productAmount * pr.OriginPrice).ToString() + " $";
                }
                catch (Exception)
                {
                    MessageBox.Show(e.ToString());
                }

                try
                {
                    float percentNeed = (float)(pr.PackedWidth * pr.PackedDepth * pr.PackedHeight * Int32.Parse(quantityTextBox.Text)) * 100 / calVOfWarehouse50Percent(warehouseid);
                    totalVTextBlock.Text = percentNeed.ToString() + " %";
                }
                catch (Exception)
                {
                    MessageBox.Show(e.ToString());
                }

                try
                {
                    warehouseId = _context.Warehouses.FirstOrDefault(x => x.WarehouseName.Equals(result.ToString())).WarehouseId;
                    totalVExistTextBlock.Text = (calVOfProduct(warehouseId) * 100 / calVOfWarehouse50Percent(warehouseId)).ToString("0.00") + " %";
                }
                catch (Exception)
                {
                    MessageBox.Show(e.ToString());
                }

                ProductNameTextBlock.Text = pr.ProductName;

                ProviderTextBlock.Text = supplierComboBox.SelectedItem.ToString();

                WarehouseTextBlock.Text = result;
            }
            else {
                MessageBox.Show("bạn chưa chọn sản phẩm");
            }
        }

        private void OrderConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string VNeed = totalVTextBlock.Text;
            string Vexist = totalVExistTextBlock.Text;
            string[] VNeedParts = VNeed.Split(' ');
            string[] VexistParts = Vexist.Split(' ');
            string splitVNeed = VNeedParts[0];
            string splitVVexist = VexistParts[0];
            warehouseId = _context.Warehouses.FirstOrDefault(x => x.WarehouseName.Equals(WarehouseTextBlock.Text)).WarehouseId;
            if (float.Parse(splitVNeed) + float.Parse(splitVVexist) > 100)
            {
                MessageBox.Show("không thể đặt hàng vì số lượng sản phẩm quá lớn");
            }

            else
            {
                try
                {
                    string providerName = ProviderTextBlock.Text;
                    string dateCurrent = DateTime.Now.ToString("dd/MM/yyyy");
                    DateTime formatteddateCurrent = DateTime.ParseExact(dateCurrent, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dateExpect = (DateTime)datePicker.SelectedDate;

                    DateTime formattedDateTime = DateTime.ParseExact(dateExpect.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string price = totalAmountTextBlock.Text;
                    string[] part = price.Split(' ');
                    string spilteTotal = part[0];
                    int ProviderId = _context.Providers.FirstOrDefault(x => x.ProviderName.Equals(ProviderTextBlock.Text)).ProviderId;
                    int ProductId = _context.Products.FirstOrDefault(x => x.ProductName.Equals(ProductNameTextBlock.Text)).ProductId;
                    OrderDetail order = new OrderDetail()
                    {
                        ExpectedDate = formattedDateTime,
                        OrderQuantity = Int32.Parse(quantityTextBox.Text),
                        OrderDate = formatteddateCurrent,
                        ProviderId = ProviderId,
                        ProductId = ProductId,
                        TotalPayment = decimal.Parse(spilteTotal),
                        WarehouseId = warehouseId

                    };
                    _context.OrderDetails.AddRange(order);
                    _context.SaveChanges();
                    MessageBox.Show("đặt hàng thành công");
                }
                catch (Exception) { 
                MessageBox.Show(e.ToString());
                }
             
            }
        }
    }
}
