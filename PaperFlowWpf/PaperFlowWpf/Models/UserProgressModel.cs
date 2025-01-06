using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Models
{
    public class UserProgressModel
    {
        public int UserId { get; set; }
        public List<int> GroupIds { get; set; } = new List<int>();
        public Dictionary<string, int> PapersReadByMonth { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> AnnotationsByMonth { get; set; } = new Dictionary<string, int>();
        public List<string> Topics { get; set; } = new List<string>();
        public string BestWork { get; set; }
        public int OngoingResearchProjects { get; set; }
        public int TotalDatasetsCollected { get; set; }
        public int LiteratureReviewsCompleted { get; set; }
        public int DiscussionsParticipated { get; set; }
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public Dictionary<string, int> ContributionsByCategory { get; set; } = new Dictionary<string, int>();

        public Dictionary<string, int> WeeklyWorkHours { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> PapersPerTopic { get; set; } = new Dictionary<string, int>();
        public string MostWorkedOnTopic { get; set; }
        public List<string> RecentActivities { get; set; } = new List<string>();
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}
