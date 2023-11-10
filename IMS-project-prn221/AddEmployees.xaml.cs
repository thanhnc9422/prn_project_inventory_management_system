using IMS_project_prn221.Models;
using MaterialDesignThemes.Wpf.Internal;
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
    /// Interaction logic for AddEmployees.xaml
    /// </summary>
    public partial class AddEmployees : Window
    {
        private readonly InventoryManagementContext _context = new InventoryManagementContext();
        List<Staff> listStaffs = new List<Staff>();
        private Staff selectedEmployeeToEdit;
        public AddEmployees()
        {
            InitializeComponent();
            LoadRoles();
            LoadData();
        }
        private void LoadData()
        {
            cmbRole.ItemsSource = _context.Roles.Select(x => x.RoleName).ToList();
            listStaffs = _context.Staff.Include(x => x.Role).ToList();
            EmployeeListsView.ItemsSource = listStaffs;
        }

        private void LoadRoles()
        {
            try
            {
                using (InventoryManagementContext context = new InventoryManagementContext()) // Thay thế YourDbContext bằng đối tượng DbContext của bạn
                {
                    // Lấy danh sách các vai trò từ cơ sở dữ liệu
                    List<Role> roles = context.Roles.ToList();
                    List<String> listRole = roles.Select(x => x.RoleName).ToList();

                    // Gán danh sách các vai trò cho ComboBox
                    cmbRole.ItemsSource = listRole;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách vai trò: " + ex.Message);
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            int phone = int.Parse(txtPhone.Text);
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Password.ToString();
            //Role selectedRole = (Role)cmbRole.SelectedItem;


            // gán thông tin lấy từ form
            Staff newEmployee = new Staff
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Phone = phone,
                Email = email,
                UserName = username,
                PassWord = password,
                /*RoleId = selectedRole.RoleId*/
            };
            _context.Staff.Add(newEmployee);
            _context.SaveChanges();
            clearText();
            cmbRole.SelectedIndex = -1;
            LoadData();
            MessageBox.Show("add successfully!!");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            clearText();
            cmbRole.SelectedIndex = -1;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = (Button)sender;
            Staff employee = deleteButton.Tag as Staff;
            if (employee != null)
            {
                _context.Staff.Remove(employee);
                _context.SaveChanges(true);
                LoadData();
                MessageBox.Show($"{employee.LastName + employee.FirstName} have been deleted ");
            }
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {

            // Lấy thông tin của nhân viên được chọn
            Staff selectedEmployee = (Staff)EmployeeListsView.SelectedItem;
            if (EmployeeListsView.SelectedItem != null)
            {
                Staff staff = _context.Staff.FirstOrDefault(x => x.StaffId == selectedEmployee.StaffId);

                if (staff != null)
                {
                    staff.FirstName = txtFirstName.Text;
                    staff.LastName = txtLastName.Text;
                    staff.Address = txtAddress.Text;
                    staff.Phone = Int32.Parse(txtPhone.Text);
                    staff.Email = txtEmail.Text;
                    staff.UserName = txtUsername.Text;
                    staff.PassWord = txtPassword.Password.ToString();
                    staff.RoleId = _context.Roles.FirstOrDefault(x => x.RoleName.Equals(cmbRole.SelectedItem.ToString())).RoleId;
                }
                // Hiển thị thông tin nhân viên trong các trường nhập liệu để có thể chỉnh sửa


                _context.Staff.Update(staff);
                _context.SaveChanges();

                // Đặt Role trong ComboBox cho nhân viên
                //cmbRole.SelectedItem = selectedEmployee.Role.RoleName;

                // Ẩn nút "Add" và hiển thị nút "Save" để cho phép lưu chỉnh sửa

                // Lưu thông tin nhân viên được chỉnh sửa
                clearText();
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để chỉnh sửa.");
            }
        }

        //private void EmployeeListsView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    Staff staff = (Staff)EmployeeListsView.SelectedItem;   
        //    if (staff != null) {
        //    cmbRole.SelectedValue = staff.Role.RoleName;
        //    }
        //}
        private void clearText()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
        }
    }
    }
