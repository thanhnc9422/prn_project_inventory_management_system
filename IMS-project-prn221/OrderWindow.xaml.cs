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
                warehouseTextBox.Items.Add(Warehouse.WarehouseName + " còn trống " + (((calVOfProduct(Warehouse.WarehouseId)) * 100)/ calVOfWarehouse50Percent(Warehouse.WarehouseId)).ToString("0.00") + "%");
            }
        }
        private void warehouseTextBox_SelectionChanged(object sender, RoutedEventArgs e) { 
                   ComboBox comboBox = (ComboBox)sender;
                 string selectedValue = comboBox.SelectedItem.ToString();
            string[] parts = selectedValue.Split(' ');
            string result = parts[0];
            warehouseId = _context.Warehouses.FirstOrDefault(x => x.WarehouseName.Equals(result.ToString())).WarehouseId;
            WarehouseTextBlock.Text = warehouseId+"";
            totalVExistTextBlock.Text = (calVOfProduct(warehouseId) * 100 / calVOfWarehouse50Percent(warehouseId)).ToString("0.00") + " %";


        }
        private void supplierComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem.ToString();
            int ProviderId = _context.Providers.FirstOrDefault(provider => provider.ProviderName == selectedValue).ProviderId;
            providerId = ProviderId;
            var products = from x in _context.Products where x.ProviderId == ProviderId select x;
            itemListView.ItemsSource = products.ToList();
            ProviderTextBlock.Text = selectedValue;
        }

        private void quantityTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var item = (sender as TextBox).Text;
            if (int.TryParse(item, out int x)) {
                productAmount = Int32.Parse(item);
                totalAmountTextBlock.Text = (productAmount * productPrice).ToString() + " $";
            }
        }

        private void itemListView_PreviewMouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
           var item = (sender as ListView).SelectedItem;
            if (item != null) {
                Product product = item as Product;
                ProductNameTextBlock.Text = product.ProductName;
                productPrice = (float)((Product)item).OriginPrice;
                productId = product.ProductId;
                totalAmountTextBlock.Text = (productAmount * productPrice).ToString() +" $";
                if (warehouseTextBox.Text != "") { 
               
                int whId = Int32.Parse(WarehouseTextBlock.Text);
                if (whId != null && ! string.IsNullOrEmpty(quantityTextBox.Text)) { 
                float percentNeed = (float)(product.PackedWidth * product.PackedDepth * product.PackedHeight * Int32.Parse(quantityTextBox.Text)) *100/ calVOfWarehouse50Percent(whId);

                    totalVTextBlock.Text = percentNeed.ToString() + " %";
                }
                }
            }
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
            string VNeed = totalVTextBlock.Text;
            string Vexist = totalVExistTextBlock.Text;
            string[] VNeedParts = VNeed.Split(' ');
            string[] VexistParts = Vexist.Split(' ');
            string result0 = VNeedParts[0];
            string result1 = VexistParts[0];

            if (float.Parse(result0) + float.Parse(result1) > 100)
            {
                MessageBox.Show("không thể đặt hàng vì số lượng sản phẩm quá lớn");
            }

            else {
                string providerName = ProviderTextBlock.Text;
                string[] partProvider = providerName.Split(' ');
                string resultPartProvider = partProvider[0];

                string dateCurrent = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime formatteddateCurrent = DateTime.ParseExact(dateCurrent, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateExpect = (DateTime)datePicker.SelectedDate;

                DateTime formattedDateTime = DateTime.ParseExact(dateExpect.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string price = totalAmountTextBlock.Text;
                string[] part = price.Split(' ');
                string result = part[0];
                int ProviderId = _context.Providers.FirstOrDefault(x => x.ProviderName.Equals(ProviderTextBlock.Text)).ProviderId;
                int ProductId = _context.Products.FirstOrDefault(x => x.ProductName.Equals(ProductNameTextBlock.Text)).ProductId;
                OrderDetail order = new OrderDetail() {
                    ExpectedDate = formattedDateTime,
                    OrderQuantity = Int32.Parse(quantityTextBox.Text),
                    OrderDate = formatteddateCurrent,
                    ProviderId = ProviderId,
                    ProductId = ProductId,
                    TotalPayment = decimal.Parse(result),
                    WarehouseId = Int32.Parse(WarehouseTextBlock.Text)

                };
                
                
                _context.OrderDetails.AddRange(order);
                _context.SaveChanges();          
                MessageBox.Show("đặt hàng thành công");

            }
        }
    }
}
