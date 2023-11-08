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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Thực hiện xác thực người dùng ở đây và kiểm tra username và password

            //if (authenticationSuccessful)
            //{
            //    // Đăng nhập thành công, có thể chuyển người dùng đến cửa sổ quản lý kho hoặc thực hiện các hành động khác
            //}
            //else
            //{
            //    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại username và password.");
            //}
        }
    }
}
