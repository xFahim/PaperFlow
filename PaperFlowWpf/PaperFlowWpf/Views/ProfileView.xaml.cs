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
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : Page
    {
        private readonly Random _random = new Random();
        public ProfileView(User u)
        {
            InitializeComponent();

            PopulateHeatmap();
            LoadDummyData();
        }
        private void LoadDummyData()
        {
            var dummyData = new List<ResearchGroup>
            {
                new ResearchGroup { Id = 1, Title = "AI for Agriculture", Description = "Exploring AI to improve farming practices.", Category = "Agriculture", CreatedAt = DateTime.Now.AddMonths(-3) },
                new ResearchGroup { Id = 2, Title = "Water Resource Management", Description = "Optimizing water usage in agriculture.", Category = "Environmental Science", CreatedAt = DateTime.Now.AddMonths(-2) },
                new ResearchGroup { Id = 3, Title = "IoT in Farming", Description = "Leveraging IoT for real-time monitoring.", Category = "Technology", CreatedAt = DateTime.Now.AddMonths(-1) },
                new ResearchGroup { Id = 4, Title = "Bangla Text Classification", Description = "Leveraging IoT for real-time monitoring.", Category = "Technology", CreatedAt = DateTime.Now.AddMonths(-1) }
            };

            ResearchGroupList.ItemsSource = dummyData;
        }
        private void PopulateHeatmap()
        {
            var today = DateTime.Now;
            var startDate = today.AddDays(-365);

            int col = 0;
            int row = (int)startDate.DayOfWeek;

            for (var date = startDate; date <= today; date = date.AddDays(1))
            {
                var activities = GenerateDummyActivities(date);
                var intensity = CalculateIntensity(activities);
                var cell = CreateHeatmapCell(intensity, date, activities);

                Grid.SetRow(cell, row);
                Grid.SetColumn(cell, col);
                ContributionGrid.Children.Add(cell);

                row = (row + 1) % 7;
                if (row == 0)
                {
                    col++;
                    ContributionGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                }
            }
        }
        private int GenerateDummyActivities(DateTime date)
        {
            // Generate more activities for weekdays, fewer for weekends
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return _random.Next(0, 3);
            return _random.Next(0, 8);
        }

        private SolidColorBrush CalculateIntensity(int activities)
        {
            // Color scheme similar to GitHub's but with blue tones for research theme
            if (activities == 0)
                return new SolidColorBrush(Color.FromRgb(238, 238, 238));
            else if (activities <= 2)
                return new SolidColorBrush(Color.FromRgb(198, 219, 239));
            else if (activities <= 4)
                return new SolidColorBrush(Color.FromRgb(158, 202, 225));
            else if (activities <= 6)
                return new SolidColorBrush(Color.FromRgb(107, 174, 214));
            else
                return new SolidColorBrush(Color.FromRgb(49, 130, 189));
        }

        private UIElement CreateHeatmapCell(SolidColorBrush intensity, DateTime date, int activities)
        {
            var border = new Border
            {
                Style = (Style)FindResource("HeatmapCell"),
                Background = intensity
            };

            // Create tooltip content
            var activityText = activities == 1 ? "activity" : "activities";
            ToolTipService.SetToolTip(border,
                $"{date.ToString("MMM d, yyyy")}\n{activities} research {activityText}");

            return border;
        }

        private void Explorebtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePageView(null));
        }

        private void MyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MyGroupView());
        }
    }
}
