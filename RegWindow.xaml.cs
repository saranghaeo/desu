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

namespace desu
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        ApplicationContext db;

        public RegWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text.Trim();
            string password = passwordBox.Password.Trim();
            string password_2 = passwordBox_2.Password.Trim();
            string email = emailBox.Text.Trim().ToLower();

            if (login.Length < 4)
            {
                loginBox.ToolTip = "error";
                loginBox.Background = Brushes.DarkRed;
            }
            else if (password.Length < 6)
            {
                passwordBox.ToolTip = "error";
                passwordBox.Background = Brushes.DarkRed;
            }
            else if (password != password_2)
            {
                passwordBox_2.ToolTip = "error";
                passwordBox_2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                emailBox.ToolTip = "error";
                emailBox.Background = Brushes.DarkRed;
            }
            else
            {
                var newloginform = new LoginWindow();
                loginBox.ToolTip = "";
                loginBox.Background = Brushes.Transparent;
                emailBox.ToolTip = "";
                emailBox.Background = Brushes.Transparent;
                passwordBox.ToolTip = "";
                passwordBox.Background = Brushes.Transparent;
                passwordBox_2.ToolTip = "";
                passwordBox_2.Background = Brushes.Transparent;
                int role;
                if (Admin.IsChecked == true) role = 1; else role = 2;

                User user = new User(login, password, email, role);


                db.Users.Add(user);
                db.SaveChanges();


                MessageBox.Show("Successfully!");
                newloginform.Show();
                this.Close();

            }
        }
    }
}
