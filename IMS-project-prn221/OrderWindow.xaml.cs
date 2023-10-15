using IMS_project_prn221.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                warehouseTextBox.Items.Add(Warehouse.WarehouseName + " còn trống " + (((calVOfWarehouse50Percent(Warehouse.WarehouseId) - calVOfProduct(Warehouse.WarehouseId)) * 100)/ calVOfWarehouse50Percent(Warehouse.WarehouseId)).ToString("0.00") + "%");
            }
        }
        private void warehouseTextBox_SelectionChanged(object sender, RoutedEventArgs e) { 
                   ComboBox comboBox = (ComboBox)sender;
                 string selectedValue = comboBox.SelectedItem.ToString();
            string[] parts = selectedValue.Split(' ');
            string result = parts[0];
            warehouseId = _context.Warehouses.FirstOrDefault(x => x.WarehouseName.Equals(result.ToString())).WarehouseId;
            
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
                productPrice = (float)((Product)item).OriginPrice;
                productId = product.ProductId;
                totalAmountTextBlock.Text = (productAmount * productPrice).ToString();
                float percentNeed = (float)(product.PackedWidth * product.PackedDepth * product.PackedHeight * Int32.Parse(quantityTextBox.Text)) *100/ calVOfWarehouse50Percent(warehouseId);
                totalVTextBlock.Text = percentNeed.ToString() + "%";
            }
        }

        private float calVOfProduct(int warehouseId) {

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
        private float calVOfWarehouse50Percent(int warehouseId)
        {
            Warehouse warehouse = _context.Warehouses.FirstOrDefault(x => x.WarehouseId == warehouseId);

            return (float)((float)(warehouse.Height * warehouse.Length * warehouse.Width)*0.5);
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đã chọn: " +productAmount + " "+ productId+" "+productPrice+" "+providerId);
        }
    }
}
