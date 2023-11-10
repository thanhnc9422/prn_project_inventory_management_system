using IMS_project_prn221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Windows;
using System.Windows.Controls;

namespace IMS_project_prn221
{
    /// <summary>
    /// Interaction logic for SellWindow.xaml
    /// </summary>
    public partial class SellWindow : Window
    {
        private readonly InventoryManagementContext _context = new InventoryManagementContext();
        private List<DeliveryDetail> CartItems = new List<DeliveryDetail>();

        private List<Inventory> inventories = new List<Inventory>();
        private Customer customer = new Customer();
        private bool isNewCustomer;
        public SellWindow()
        {
            InitializeComponent();
       
            warehousecb.ItemsSource = (from x in _context.Warehouses select x.WarehouseName).ToList();
            warehousecb.SelectedIndex = 0;
            loadData();
        }



        private void loadData()
        {

            Warehouse warehouse = _context.Warehouses.FirstOrDefault(x => x.WarehouseName.Equals(warehousecb.SelectedItem.ToString()));
            inventories = _context.Inventories.Include(x => x.Product).Include(x => x.Warehouse).Where(x => x.WarehouseId == warehouse.WarehouseId).ToList();
            productListView.ItemsSource = inventories;
            //LoadCustomers();
        }
        //private void LoadCustomers()
        //{
        //    try
        //    {
        //        var customers = _context.Customers.Select(c => c.FirstName + " " + c.LastName).ToList();
        //        customerComboBox.ItemsSource = customers;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi nạp dữ liệu khách hàng: " + ex.Message);
        //    }
        //}

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            if (isNewCustomer) {
                Customer c = new Customer() {
                    FirstName = cusName.Text,
                  Phone = Int32.Parse(phonetb.Text)
            };
                _context.Customers.Add(c);
                _context.SaveChanges();
            }
            if (CartItems != null) {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn bán sản phẩm này?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Customer Cus;
                    if (isNewCustomer)
                    {
                       Cus = _context.Customers.FirstOrDefault(x => x.Phone == Int32.Parse(phonetb.Text));

                    }
                    else {
                       Cus = _context.Customers.FirstOrDefault(x => x.Phone == Int32.Parse(customer.Phone.ToString()));
                    }
                    foreach (var item in CartItems)
                    {
                        item.CustomerId = Cus.CustomerId;
                    }
                    _context.DeliveryDetails.AddRange(CartItems);
                    _context.SaveChanges();
                    // Thực hiện việc bán sản phẩm và cập nhật tổng
                    // Sau đó, cập nhật danh sách sản phẩm đã chọn và cập nhật ListView
                    // Đặc biệt, hãy cập nhật thông tin ở cột bên trái và cột bên phải của giao diện
                    MessageBox.Show("Bán hàng thành công!");
                }
                foreach (Inventory x in inventories) {
                    foreach (DeliveryDetail d in CartItems) {
                        if(x.ProductId == d.ProductId)
                        x.QuantityAvaiable -= d.DeliveryQuantity;
                    }
                }
                _context.Inventories.UpdateRange(inventories);
                _context.SaveChanges();
                loadData();
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
                    //cartListView.ItemsSource = inventories.Where(x => x.ProductId == productId).Select(I => new { Name = I.Product.ProductName, Quantity = I.QuantityAvaiable, Price = I.Product.OriginPrice });
                }


            }
        }
        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse = _context.Warehouses.FirstOrDefault(x => x.WarehouseName.Equals(warehousecb.SelectedItem.ToString()));

            string searchTerm = searchTextBox.Text;

            // Tìm sản phẩm theo tên (searchTerm) và cập nhật ListView "productListView"
            // Đảm bảo bạn có hàm để tìm sản phẩm theo tên trong cơ sở dữ liệu của mình.

            // Ví dụ:
            var inventories = _context.Inventories
                .Include(x => x.Product)
                .Include(x => x.Warehouse)
                .Where(i => i.Product.ProductName.Contains(searchTerm) && i.WarehouseId ==warehouse.WarehouseId)
                .ToList();

            productListView.ItemsSource = inventories;

            CartItems = new List<DeliveryDetail>();
            cartListView.ItemsSource = CartItems.ToList();
            //searchTextBox.Text = "";


        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu sản phẩm từ thuộc tính Tag của nút "+"
            Inventory selectedProduct = (Inventory)((Button)sender).Tag; // Đảm bảo bạn đã ép kiểu dữ liệu phù hợp
            List<int?> listProductId = (from x in CartItems select x.ProductId).ToList();

            if (!listProductId.Contains(selectedProduct.ProductId))
            {

                //selectedProduct.QuantityAvaiable = 10;
                // Thêm sản phẩm vào danh sách giỏ hàng
                DeliveryDetail detail = new DeliveryDetail()
                {
                    ActualDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DeliveryQuantity = 0,
                    ProductId = selectedProduct.ProductId,
                    SalePrice = 0,
                    Product = _context.Products.FirstOrDefault(x => x.ProductId == selectedProduct.ProductId)
                };

                CartItems.Add(detail);

                // Cập nhật ListView "cartListView"

                cartListView.ItemsSource = CartItems.ToList();

                // Tính toán tổng và lợi nhuận ở đây (nếu cần)
                cartListView.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Sản phẩm đã được thêm vào giỏ hàng");
            }

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu sản phẩm từ thuộc tính Tag của nút "Delete"
            var selectedProduct = (DeliveryDetail)((Button)sender).Tag; // Đảm bảo bạn đã ép kiểu dữ liệu phù hợp

            // Xóa sản phẩm khỏi danh sách giỏ hàng
            CartItems.Remove(selectedProduct);
            cartListView.ItemsSource = CartItems.ToList();
            // Cập nhật ListView "cartListView"
            loadData();
            // Tính toán tổng và lợi nhuận ở đây (nếu cần)
        }

        private void quantityTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            DeliveryDetail order = cartListView.SelectedItem as DeliveryDetail;
            List<Inventory> l = _context.Inventories.ToList();
            if (order != null)
            {
                Warehouse warehouse = _context.Warehouses.FirstOrDefault(x => x.WarehouseName.Equals(warehousecb.SelectedItem.ToString()));

                Inventory quantityProductExsit = (_context.Inventories.FirstOrDefault(x => x.ProductId == order.ProductId && x.WarehouseId == warehouse.WarehouseId));

                if (int.TryParse(quantityTextBox.Text, out int a) || string.IsNullOrEmpty(quantityTextBox.Text))
                {
                   
                        if (!string.IsNullOrEmpty(quantityTextBox.Text))
                        {
                        if (Int32.Parse(quantityTextBox.Text) <= quantityProductExsit.QuantityAvaiable)
                        {
                            order.DeliveryQuantity = Int32.Parse(quantityTextBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng sản phẩm trong kho không đủ!");

                        }
                    }
                  
                  
                    
                }
                else
                {
                    MessageBox.Show("Cân nhập số!");

                }

            }
            else
            {
                MessageBox.Show("Cần chọn sản phẩm ở giỏ hàng trước!");
            }
            updateTotalPay();
            cartListView.ItemsSource = CartItems.ToList();
        }

        private void priceTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            DeliveryDetail order = cartListView.SelectedItem as DeliveryDetail;
            if (order != null)
            {
                if (decimal.TryParse(priceTextBox.Text, out decimal a) || string.IsNullOrEmpty(priceTextBox.Text))
                {
                    if (!string.IsNullOrEmpty(priceTextBox.Text))
                    {
                        order.SalePrice = decimal.Parse(priceTextBox.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Cân nhập số!");

                }

                }
                else
                {
                    MessageBox.Show("Cần chọn sản phẩm ở giỏ hàng trước!");
                }
                updateTotalPay();
                cartListView.ItemsSource = CartItems.ToList();
            
        }
        private void updateTotalPay()
        {
                decimal total = 0;
                foreach (DeliveryDetail d in CartItems)
                {
                total += (decimal)d.DeliveryQuantity * (decimal)d.SalePrice;
                }
            totalTextBlock.Text ="Tổng tiền: "+ total.ToString() + " $";
            profitTextBlock.Text = "Lợi nhuận: " + (total - updateTotalPayOrigin()).ToString() + " $";
            }
        private decimal updateTotalPayOrigin()
        {
            decimal total = 0;
            foreach (DeliveryDetail d in CartItems)
            {
                total += (decimal)d.DeliveryQuantity * (decimal)d.Product.OriginPrice;
            }
            //totalTextBlock.Text = total.ToString();
            return total;
        }

        private void phonetb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(phonetb.Text))
            {

             customer = _context.Customers.FirstOrDefault(x => x.Phone.ToString().Contains(phonetb.Text));
                if (customer != null)
                {
                    cusName.Text = customer.LastName + " " + customer.FirstName;

                    isNewCustomer = false;
                }
                else {
                    cusName.Text = string.Empty;
                    isNewCustomer = true;
                }
            }
        }

        private void cartListView_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DeliveryDetail delivery = (DeliveryDetail)(sender as ListView).SelectedItem;
            priceTextBox.Text = delivery.SalePrice.ToString();
            quantityTextBox.Text = delivery.DeliveryQuantity.ToString();
        }
    }
}
