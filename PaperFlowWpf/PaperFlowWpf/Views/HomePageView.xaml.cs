using PaperFlowWpf.Models;
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
    /// Interaction logic for HomePageView.xaml
    /// </summary>
    public partial class HomePageView : Page
    {
        public HomePageView(User u)
        {
            InitializeComponent();
        }

        private void CreateGroupButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Group Successfully created. You will find it in your dashboard");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Join Request Sent.\n\nPlease wait for approval");
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProfileView(null));
        }
    }
}
