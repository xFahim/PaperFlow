using PaperFlowWpf.Controller;
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

namespace PaperFlowWpf.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text;
            string pass = PassBox.Text;

            UserService u = new UserService();


            if (UserService.SignUp("New User", email, pass))
            {
                MessageBox.Show("Sign up successful! You can now login.");
            }
            else
            {
                MessageBox.Show("Sign up failed. Email might already be in use.");
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = UserService.Login(LUserNameBox.Text, LoginPassBox.Password);
            if (user != null)
            {
                MessageBox.Show("login successful.");
                this.NavigationService.Navigate(new HomePageView(user));
            }
            else
            {
                MessageBox.Show("Invalid email or password");
                
            }
        }
    }
}
