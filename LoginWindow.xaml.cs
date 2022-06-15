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



namespace desu
{

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Reg(object sender, RoutedEventArgs e)
        {
            new RegWindow().Show();
            Close();
        }
        
        private void Sign_in(object sender, RoutedEventArgs e)
        {
            User authUser = null;
            using (ApplicationContext context = new ApplicationContext())
            {
                authUser = context.Users.Where(b => b.Login == loginBox.Text && b.Password == passwordBox.Password).FirstOrDefault();
            }

            if (authUser != null)
            {
                var newForm = new MainWindow(authUser.Role);

                newForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }
      
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
