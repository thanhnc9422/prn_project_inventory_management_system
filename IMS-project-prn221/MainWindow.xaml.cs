using IMS_project_prn221.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMS_project_prn221
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly InventoryManagementContext _context = new InventoryManagementContext();

        public MainWindow()
        {
            InitializeComponent();
            loadWareHouse();
        }

        public void loadWareHouse()
        {
            var wh = _context.Warehouses.ToList();
            foreach (var whpart in wh)
            {
                MenuItem whItem = new MenuItem();
                whItem.Header = whpart.WarehouseName;
                whItem.Click += wh_Click;
                whName.Items.Add(whItem);
            }
        }


        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();
        }
        private void Sell_Click(object sender, RoutedEventArgs e)
        {
            SellWindow sellWindow = new SellWindow();
            sellWindow.Show();
        }
        private void ViewEmployees_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OrderHistory_Click(object sender, RoutedEventArgs e)
        {
            HistoryOrderWindow historyOrderWindow = new HistoryOrderWindow();   
            historyOrderWindow.Show();
        }
        private void SellHistory_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
        }
        private void wh_Click(object sender, RoutedEventArgs e)
        {
            MenuItem whSelected = (MenuItem)sender;
            var wh = _context.Warehouses.ToList();
            foreach (var whpart in wh)
            {
                if (whSelected.Header.Equals(whpart.WarehouseName))
                {
                    WarehouseWindow warehouseWindow = new WarehouseWindow(whpart.WarehouseId);
                    warehouseWindow.Show();
                }
            }

        }
    }
    
}
