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
    /// Interaction logic for PaperView.xaml
    /// </summary>
    public partial class PaperView : Page
    {
        public PaperView(string p)
        {
            InitializeComponent();
            LoadPdf(p);
        }

        private void LoadPdf(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                string pdfUri = new Uri(filePath).AbsoluteUri;
                webView.Source = new Uri(pdfUri);
            }
            else
            {
                MessageBox.Show("File not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
