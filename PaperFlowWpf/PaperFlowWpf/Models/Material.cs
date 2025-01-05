using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; } // Path to the file
        public int UploadedBy { get; set; } // Foreign key to User
        public int GroupId { get; set; } // Foreign key to ResearchGroup
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User Uploader { get; set; }
        public ResearchGroup Group { get; set; }
    }

}
