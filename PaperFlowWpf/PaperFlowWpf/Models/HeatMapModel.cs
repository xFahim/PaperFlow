using LiveCharts.Defaults;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Models
{
    public class HeatmapViewModel
    {
        public ChartValues<HeatPoint> HeatmapValues { get; set; }
        public List<string> XLabels { get; set; }
        public List<string> YLabels { get; set; }

        public HeatmapViewModel()
        {
            // Define labels
            XLabels = new List<string> { "Week 1", "Week 2", "Week 3", "Week 4" }; // Weekly intervals
            YLabels = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            // Define heatmap values
            HeatmapValues = new ChartValues<HeatPoint>
            {
                new HeatPoint(0, 0, 10), // Week 1, Monday: 10 contributions
                new HeatPoint(1, 0, 15), // Week 2, Monday: 15 contributions
                new HeatPoint(2, 0, 5),  // Week 3, Monday: 5 contributions
                new HeatPoint(3, 0, 0),  // Week 4, Monday: No contributions
                new HeatPoint(0, 1, 8),  // Week 1, Tuesday: 8 contributions
                new HeatPoint(1, 1, 12), // Week 2, Tuesday: 12 contributions
                // ... Add data for other days and weeks
            };
        }
    }
}
