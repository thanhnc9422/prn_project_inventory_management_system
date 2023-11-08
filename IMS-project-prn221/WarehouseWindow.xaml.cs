using IMS_project_prn221.Models;
using LiveCharts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for WarehouseWindow.xaml
    /// </summary>
    public partial class WarehouseWindow : Window
    {
        private int WareHouseId;
        private List<Inventory> Inventory;
        private readonly InventoryManagementContext _context = new InventoryManagementContext();
        public WarehouseWindow(int wareHouseId)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            WareHouseId = wareHouseId;
            loadWin();
        }
        public void loadWin() {
            Inventory = _context.Inventories.Include(x => x.Product).Where(x => x.WarehouseId == WareHouseId).ToList();
            itemListView.ItemsSource = Inventory;
            float whcc = float.Parse(((calVOfWarehouse50Percent(WareHouseId) - calVOfProduct(WareHouseId)) * 100 / calVOfWarehouse50Percent(WareHouseId)).ToString("0.00"));
            float pdcc = (float.Parse(((calVOfProduct(WareHouseId)) * 100 / calVOfWarehouse50Percent(WareHouseId)).ToString("0.00")));
            var provider = _context.Providers.ToList();
            foreach (var item in provider) {
                supplierComboBox.Items.Add(item.ProviderName);
            }
            supplierComboBox.Items.Add("All");
            percentWh.Values = new ChartValues<float> { whcc };
            percentPd.Values = new ChartValues<float> { pdcc };
            percentWh.Title = "% free";
            percentPd.Title = "sản phẩm chiếm";
            var recentProduct = _context.OrderDetails.OrderBy(p => p.ActualDate).Include(x => x.Product).Where(x => x.WarehouseId == WareHouseId).LastOrDefault();
            productNewAdd.Content = "tên sản phẩm: "+ recentProduct.Product.ProductName.ToString();
            quanlityAdd.Content = "Số lượng: " + recentProduct.OrderQuantity.ToString();
            timeAdd.Content = "Ngày nhập hàng: " + recentProduct.ActualDate.ToString();
        }
        public float calVOfProduct(int warehouseId)
        {

            var listProduct = from x in _context.Inventories
                              where x.WarehouseId == warehouseId
                              select x;
            float VOfAllProduct = 0;
            foreach (var product in listProduct.ToList())
            {
                var product1 = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                VOfAllProduct += (float)(product1.PackedDepth * product1.PackedHeight * product1.PackedWidth * product.QuantityAvaiable);
            }
            return VOfAllProduct;
        }
        public float calVOfWarehouse50Percent(int warehouseId)
        {
            Warehouse warehouse = _context.Warehouses.FirstOrDefault(x => x.WarehouseId == warehouseId);

            return (float)((float)(warehouse.Height * warehouse.Length * warehouse.Width) * 0.5);
        }
        private void supplierComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem.ToString();
            if (selectedValue.Equals("All"))
            {
                Inventory = _context.Inventories.Include(x => x.Product).Where(x => x.WarehouseId == WareHouseId).ToList();
                itemListView.ItemsSource = Inventory;
            }
            else {
                var providerSelected = _context.Providers.FirstOrDefault(x => x.ProviderName.Equals(selectedValue));
                Inventory = _context.Inventories.Include(x => x.Product).Include(x => x.Product.Provider).Where(x => x.WarehouseId == WareHouseId && x.Product.Provider.ProviderName.Equals(selectedValue)).ToList();
                itemListView.ItemsSource = Inventory;
            }
        }
    }

}
