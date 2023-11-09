using IMS_project_prn221.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace IMS_project_prn221
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly InventoryManagementContext _context = new InventoryManagementContext();
        private Staff staff;

        public MainWindow(Staff staff)
        {
            this.staff = staff;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            loadWareHouse();
            if (staff.RoleId == 2)
            {

                empManagement.Visibility = Visibility.Collapsed;
                orderManagement.Visibility = Visibility.Collapsed;

            }
        }

        public void loadWareHouse()
        {
            var wh = _context.Warehouses.ToList();
            foreach (var whpart in wh)
            {
                TreeViewItem whItem = new TreeViewItem();
                whItem.Header = whpart.WarehouseName;
                whItem.PreviewMouseDoubleClick += wh_Click;
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
            ViewEmployees viewEmployees = new ViewEmployees();
            viewEmployees.Show();
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployees addEmployees = new AddEmployees();
            addEmployees.Show();
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
            TreeViewItem whSelected = (TreeViewItem)sender;
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
