using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Models
{
    public class Summary
    {
        public int Id { get; set; }
        public int GroupId { get; set; } // Foreign key to ResearchGroup
        public string Content { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        public int GeneratedBy { get; set; } // Foreign key to User

        // Navigation properties
        public ResearchGroup Group { get; set; }
        public User Generator { get; set; }
    }

}
