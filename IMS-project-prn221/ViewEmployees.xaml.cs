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
    /// Interaction logic for ViewEmployees.xaml
    /// </summary>
    public partial class ViewEmployees : Window
    {
        private readonly InventoryManagementContext _context = new InventoryManagementContext();
        private List<Staff> employees = new List<Staff>(); 
        public ViewEmployees()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            employees = _context.Staff.Include(x => x.Role).ToList();
            employeeDataGrid.ItemsSource = employees;
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị một cửa sổ hoặc trang để thêm nhân viên
            // Sau khi thêm, cập nhật DataGrid để hiển thị thông tin mới
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem đã chọn một nhân viên trong DataGrid chưa
            // Nếu có, xóa nhân viên khỏi cơ sở dữ liệu và cập nhật DataGrid
        }
        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
