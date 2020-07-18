using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectComments = new HashSet<ProjectComment>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Qualifiers { get; set; }
        public string SkillLevel { get; set; }
        public long Capacity { get; set; }
        public string Region { get; set; }
        public string Location { get; set; }
        public long Remote { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? StartDate { get; set; }
        public long Status { get; set; }
        public string Access { get; set; }
        public long EnableComments { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ProjectComment> ProjectComments { get; set; }
    }
}
