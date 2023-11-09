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
    /// Interaction logic for HistorySellWindow.xaml
    /// </summary>
    public partial class HistorySellWindow : Window
    {
        private readonly InventoryManagementContext _context = new InventoryManagementContext();
        private List<DeliveryDetail> deliveryDetail = new List<DeliveryDetail>();
        private DateTime StartDate;
        private DateTime EndDate;
        public HistorySellWindow()
        {
            InitializeComponent();
            loadWin();
        }
        public void loadWin()
        {
            deliveryDetail = _context.DeliveryDetails.Include(x => x.Product).Include(x => x.Customer).ToList();
            dataListView.ItemsSource = deliveryDetail.ToList();
        }
        public void SearchButton_Click(object sender, RoutedEventArgs e)
        {
        }

      


        private void startDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.StartDate = startDatePicker.SelectedDate == null ? DateTime.Now : (DateTime)startDatePicker.SelectedDate;
            this.EndDate = endDatePicker.SelectedDate == null ? DateTime.Now : (DateTime)endDatePicker.SelectedDate;

            if (startDatePicker != null && endDatePicker != null)
            {
         
                    this.deliveryDetail = _context.DeliveryDetails.Include(x => x.Product).Include(x => x.Customer).Where(x => x.ActualDate >= this.StartDate && x.ActualDate <= this.EndDate).ToList();
   
            }
            dataListView.ItemsSource = this.deliveryDetail;
        }

        private void searchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            this.deliveryDetail = _context.DeliveryDetails.Include(x => x.Product).Include(x => x.Customer).Include(x => x.Product).Where(x => x.Customer.FirstName.Contains(searchTextBox.Text)).ToList();
            dataListView.ItemsSource = this.deliveryDetail;
        }
    }
}
