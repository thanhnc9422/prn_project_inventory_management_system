using IMS_project_prn221.Models;
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
    /// Interaction logic for HistoryOrderWindow.xaml
    /// </summary>
    ///
    public partial class HistoryOrderWindow : Window
    {
        private readonly InventoryManagementContext _context = new InventoryManagementContext();
        private List<OrderDetail> orderDetails = new List<OrderDetail>();
        private string ProviderName;
        private DateTime StartDate;
        private DateTime EndDate;
        public HistoryOrderWindow()
        {
            InitializeComponent();
            loadWin();
        }
        public void loadWin() { 
             orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).ToList();
            dataListView.ItemsSource = orderDetails;
            var providers = _context.Providers.ToList();
            foreach ( var provider in providers )
            {
                providerComboBox.Items.Add(provider.ProviderName);
            }
            providerComboBox.Items.Add("All");
        }
        public void SearchButton_Click(object sender, RoutedEventArgs e) { 
        }

        private void providerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = sender as ComboBox;
            this.ProviderName = a.SelectedItem.ToString();
            if (startDatePicker.SelectedDate != null && endDatePicker.SelectedDate != null)
            {
                if (string.IsNullOrEmpty(this.ProviderName) || this.ProviderName.Equals("All"))
                {
                    this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).Where(x => x.OrderDate >= this.StartDate && x.OrderDate <= this.EndDate).ToList();
                }
                else
                {
                    this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).Where(x => x.OrderDate >= this.StartDate && x.OrderDate <= this.EndDate && x.Provider.ProviderName.Equals(this.ProviderName)).ToList();
                }
            }
            else {
                if (string.IsNullOrEmpty(this.ProviderName) || this.ProviderName.Equals("All"))
                {
                    this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).ToList();
                }
                else {
                    this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).Where(x => x.Provider.ProviderName.Equals(this.ProviderName)).ToList();
                }
            }
            dataListView.ItemsSource = this.orderDetails;
        }
        public void getSearch(string ProviderName, DateTime startDate, DateTime enddate) {
            if (ProviderName == "All" || string.IsNullOrEmpty(ProviderName)) {
                if (string.IsNullOrEmpty(startDate.ToString("dd/MM/yyyy")) && string.IsNullOrEmpty(enddate.ToString("dd/MM/yyyy"))) { 
                
                }
                this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).ToList();

            }

        }

        private void startDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.StartDate = startDatePicker.SelectedDate == null ? DateTime.Now: (DateTime)startDatePicker.SelectedDate;
            this.EndDate = endDatePicker.SelectedDate == null ? DateTime.Now: (DateTime)endDatePicker.SelectedDate;

            if (startDatePicker != null && endDatePicker != null)
            {
                if (string.IsNullOrEmpty(this.ProviderName) || this.ProviderName.Equals("All"))
                {
                    this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).Where(x => x.OrderDate >= this.StartDate && x.OrderDate <= this.EndDate).ToList();
                }
                else
                {
                    this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).Where(x => x.OrderDate >= this.StartDate && x.OrderDate <= this.EndDate && x.Provider.ProviderName.Equals(this.ProviderName)).ToList();
                }
            }
            else {
                if (this.ProviderName == null)
                {
                    this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).ToList();
                }
                else {
                    this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).Where(x => x.Provider.ProviderName.Equals(this.ProviderName)).ToList();
                }
            }
            dataListView.ItemsSource = this.orderDetails;
        }

        private void searchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            this.orderDetails = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Include(x => x.Provider).Where(x => x.Product.ProductName.Contains(searchTextBox.Text)).ToList();
            dataListView.ItemsSource = this.orderDetails;
        }
    }
}
