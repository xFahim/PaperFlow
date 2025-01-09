using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace PaperFlowWpf.Views
{
    /// <summary>
    /// Interaction logic for addFileView.xaml
    /// </summary>
    public partial class addFileView : Page
    {
        public addFileView()
        {
            InitializeComponent();
        }

        private async void fetchBtn_Click(object sender, RoutedEventArgs e)
        {
            string doi = doiBox.Text;
            if (string.IsNullOrWhiteSpace(doi))
            {
                MessageBox.Show("Please enter a DOI.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                string pdfUrl = await SciHubPdfFetcher.GetPdfUrlAsync(doi);
                if (!string.IsNullOrEmpty(pdfUrl))
                {
                    PdfViewer.Navigate(new Uri(pdfUrl));
                }
                else
                {
                    MessageBox.Show("Unable to fetch PDF. Check the DOI or try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf", 
                Title = "Select a PDF File",
                Multiselect = false 
            };


            if (openFileDialog.ShowDialog() == true)
            {

                string selectedFilePath = openFileDialog.FileName;
                this.NavigationService.Navigate(new PaperView(selectedFilePath));
            }
        }
    }
}
