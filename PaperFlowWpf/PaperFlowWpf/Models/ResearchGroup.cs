using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace PaperFlowWpf.Models
{
    public class ResearchGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; } // Foreign key to User
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User Creator { get; set; }
        public List<GroupMembership> Members { get; set; }
        public List<Material> Materials { get; set; }
        public List<Progress> ProgressUpdates { get; set; }
        public List<Summary> Summaries { get; set; }
    }

}
