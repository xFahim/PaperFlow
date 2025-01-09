using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for MyGroupView.xaml
    /// </summary>
    public partial class MyGroupView : Page
    {
        public class ResearchMaterial
        {
            public string PaperTitle { get; set; }
            public string DoiId { get; set; }
            public string Authors { get; set; }
            public string SuggestedBy { get; set; }
            public string ReadingStatus { get; set; }
            public string PublishedYear { get; set; }
            public string StatusColor { get; set; }
        }

        public SeriesCollection Series { get; set; }
        public string Title { get; set; }
        public MyGroupView()
        {
            InitializeComponent();

            var dummyData = new List<ResearchMaterial>
            {
                new ResearchMaterial
                {
                    PaperTitle = "Understanding AI in Healthcare",
                    DoiId = "10.1001/aihealth2023",
                    Authors = "John Doe, Jane Smith",
                    SuggestedBy = "Dr. Allen",
                    ReadingStatus = "Active",
                    PublishedYear = "2023",
                    StatusColor = "#4CAF50"  // Green for Active
                },
                new ResearchMaterial
                {
                    PaperTitle = "Quantum Computing Basics",
                    DoiId = "10.1234/quantum2024",
                    Authors = "Alice Johnson, Bob Lee",
                    SuggestedBy = "Prof. Miller",
                    ReadingStatus = "New",
                    PublishedYear = "2024",
                    StatusColor = "#FF9800"  // Orange for New
                },
                new ResearchMaterial
                {
                    PaperTitle = "Climate Change and Agriculture",
                    DoiId = "10.5678/climate2022",
                    Authors = "Sarah Green, Tom Brown",
                    SuggestedBy = "Environment Group",
                    ReadingStatus = "Closed",
                    PublishedYear = "2022",
                    StatusColor = "#F44336"  // Red for Closed
                }
            };

            // Add items to the ListView
            foreach (var paper in dummyData)
            {
                var listViewItem = new ListViewItem();
                var itemTemplate = (DataTemplate)ResearchMaterialList.ItemTemplate;

                var border = (Border)itemTemplate.LoadContent();
                var stackPanel = (StackPanel)border.Child;

                var paperTitleTextBlock = (TextBlock)stackPanel.Children[0];
                paperTitleTextBlock.Text = paper.PaperTitle;

                var doiPanel = (StackPanel)stackPanel.Children[1];
                var doiTextBlock = (TextBlock)doiPanel.Children[1];
                doiTextBlock.Text = paper.DoiId;

                var authorsTextBlock = (TextBlock)stackPanel.Children[2];
                authorsTextBlock.Text = "Authors: " + paper.Authors;

                var suggestedByTextBlock = (TextBlock)stackPanel.Children[3];
                suggestedByTextBlock.Text = "Suggested By: " + paper.SuggestedBy;

                var publishedYearTextBlock = (TextBlock)stackPanel.Children[4];
                publishedYearTextBlock.Text = "Published Year: " + paper.PublishedYear;

                var statusPanel = (StackPanel)stackPanel.Children[5];
                var statusColorBorder = (Border)statusPanel.Children[1];
                statusColorBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(paper.StatusColor));

                var readingStatusTextBlock = (TextBlock)statusColorBorder.Child;
                readingStatusTextBlock.Text = paper.ReadingStatus;

                listViewItem.Content = border;
                ResearchMaterialList.Items.Add(listViewItem);
            }

            ContributionChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Papers Read",
                    Values = new ChartValues<int> { 5, 10, 15, 20, 25 }
                },
                new LineSeries
                {
                    Title = "Papers Reviewed",
                    Values = new ChartValues<int> { 2, 8, 12, 18, 22 }
                }
            };

            ContributionChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Papers Read",
                    Values = new ChartValues<int> { 10, 0, 10, 5, 18 }
                },
                new LineSeries
                {
                    Title = "Papers Reviewed",
                    Values = new ChartValues<int> { 2, 0, 0, 9, 11 }
                }
            };
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            int i = ResearchMaterialList.SelectedIndex;

            if (i < 0)
            {
                MessageBox.Show("Select a material First.");
                return;
            }

            ResearchMaterialList.Items.RemoveAt(i);
            MessageBox.Show("Material Is Removed.");
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new addFileView());
        }
    }
}
