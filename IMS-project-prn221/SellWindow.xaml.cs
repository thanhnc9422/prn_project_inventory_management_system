using IMS_project_prn221.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for SellWindow.xaml
    /// </summary>
    public partial class SellWindow : Window
    {
        private readonly InventoryManagementContext _context = new InventoryManagementContext();
        private ObservableCollection<Inventory> CartItems = new ObservableCollection<Inventory>();

        private List<Inventory> inventories = new List<Inventory>();
        public SellWindow()
        {
            InitializeComponent();
            loadData();
        }



        private void loadData()
        {

            inventories = _context.Inventories.Include(x => x.Product).Include(x => x.Warehouse).ToList();
            productListView.ItemsSource = inventories;
            LoadCustomers();
        }
        private void LoadCustomers()
        {
            try
            {
                var customers = _context.Customers.Select(c => c.FirstName + " " + c.LastName).ToList();
                customerComboBox.ItemsSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp dữ liệu khách hàng: " + ex.Message);
            }
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn bán sản phẩm này?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Thực hiện việc bán sản phẩm và cập nhật tổng
                // Sau đó, cập nhật danh sách sản phẩm đã chọn và cập nhật ListView
                // Đặc biệt, hãy cập nhật thông tin ở cột bên trái và cột bên phải của giao diện
            }
        }
        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productListView.SelectedItem != null)
            {
                if (productListView.SelectedItem is Inventory selectedObject)
                {
                    int productId = selectedObject.Product.ProductId;
                    // Bây giờ bạn có thể sử dụng productId cho mục đích của mình
                    Console.WriteLine(productListView.SelectedItem.ToString());
                    var selectedProduct = productListView.SelectedItem as Inventory; // Thay thế YourProductModel bằng tên của lớp dữ liệu của bạn.



                    var inventories = _context.Inventories.Include(x => x.Product).Include(x => x.Warehouse).ToList();
                    cartListView.ItemsSource = inventories.Where(x => x.ProductId == productId).Select(I => new { Name = I.Product.ProductName, Quantity = I.QuantityAvaiable, Price = I.Product.OriginPrice });
                }


            }
        }
        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {

            string searchTerm = searchTextBox.Text;

            // Tìm sản phẩm theo tên (searchTerm) và cập nhật ListView "productListView"
            // Đảm bảo bạn có hàm để tìm sản phẩm theo tên trong cơ sở dữ liệu của mình.

            // Ví dụ:
            var inventories = _context.Inventories
                .Include(x => x.Product)
                .Include(x => x.Warehouse)
                .Where(i => i.Product.ProductName.Contains(searchTerm))
                .ToList();

            productListView.ItemsSource = inventories;



            //searchTextBox.Text = "";


        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu sản phẩm từ thuộc tính Tag của nút "+"
            var selectedProduct = (Inventory)((Button)sender).Tag; // Đảm bảo bạn đã ép kiểu dữ liệu phù hợp
            if (!CartItems.Contains(selectedProduct))
            {
                // Thêm sản phẩm vào danh sách giỏ hàng
                CartItems.Add(selectedProduct);

                // Cập nhật ListView "cartListView"

                cartListView.ItemsSource = CartItems.Select(item => new { Name = item.Product.ProductName, Quantity = item.QuantityAvaiable, Price = item.Product.OriginPrice, Total = item.QuantityAvaiable * item.Product.OriginPrice });

                // Tính toán tổng và lợi nhuận ở đây (nếu cần)
            }
            else
            {
                MessageBox.Show("Sản phẩm đã được thêm vào giỏ hàng");
            }

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu sản phẩm từ thuộc tính Tag của nút "Delete"
            var selectedProduct = (Inventory)((Button)sender).Tag; // Đảm bảo bạn đã ép kiểu dữ liệu phù hợp

            // Xóa sản phẩm khỏi danh sách giỏ hàng
            CartItems.Remove(selectedProduct);

            // Cập nhật ListView "cartListView"
            cartListView.ItemsSource = CartItems.Select(item => new { Name = item.Product.ProductName, Quantity = item.QuantityAvaiable, Price = item.Product.OriginPrice });

            // Tính toán tổng và lợi nhuận ở đây (nếu cần)
        }
    }
}
