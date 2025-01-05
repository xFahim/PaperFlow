using PaperFlowWpf.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Models
{
    public class ResearchGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }  // Thesis topic category
        public int AdminId { get; set; }      // User ID of the admin
        public DateTime CreatedAt { get; set; }
        public Privacy Privacy { get; set; }

        // Original navigation properties
        public User Creator { get; set; }
        public List<GroupMembership> Members { get; set; } = new List<GroupMembership>();
        public List<Material> Materials { get; set; } = new List<Material>();
        public List<Progress> ProgressUpdates { get; set; } = new List<Progress>();
        public List<Summary> Summaries { get; set; } = new List<Summary>();

        // New properties for join requests
        public List<JoinRequest> JoinRequests { get; set; } = new List<JoinRequest>();
    }

    // New class to track join requests
    public class JoinRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User User { get; set; }
        public ResearchGroup Group { get; set; }
    }

    public enum Privacy
    {
        Public,
        Private
    }

    

}
