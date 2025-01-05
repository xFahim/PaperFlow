using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public int GroupId { get; set; } // Foreign key to ResearchGroup
        public string UpdateText { get; set; }
        public int UpdatedBy { get; set; } // Foreign key to User
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ResearchGroup Group { get; set; }
        public User Updater { get; set; }
    }

}
