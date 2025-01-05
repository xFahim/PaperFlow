using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Models
{
    public class GroupMembership
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key to User
        public int GroupId { get; set; } // Foreign key to ResearchGroup
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User User { get; set; }
        public ResearchGroup Group { get; set; }
    }

}
