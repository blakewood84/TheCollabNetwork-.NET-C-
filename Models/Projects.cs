﻿using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class Projects
    {
        public Projects()
        {
            Comments = new HashSet<Comments>();
            Reports = new HashSet<Reports>();
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

        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Reports> Reports { get; set; }
    }
}
