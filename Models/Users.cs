using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class Users
    {
        public Users()
        {
            Articles = new HashSet<Articles>();
            Comments = new HashSet<Comments>();
            Projects = new HashSet<Projects>();
            ReportsReporter = new HashSet<Reports>();
            ReportsUser = new HashSet<Reports>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string Img { get; set; }
        public long AccessLevel { get; set; }

        public virtual ICollection<Articles> Articles { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual ICollection<Reports> ReportsReporter { get; set; }
        public virtual ICollection<Reports> ReportsUser { get; set; }
    }
}
