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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WarehousesLLQ_Click(object sender, RoutedEventArgs e)
        {

        }
        private void WarehousesCG_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow();    
            chartWindow.Show();
        }
        private void Sell_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ViewEmployees_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OrderHistory_Click(object sender, RoutedEventArgs e)
        {
         
        }
        private void SellHistory_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
        orderWindow.Show();
        }
}
    
}
