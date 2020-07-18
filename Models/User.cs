using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class User
    {
        public User()
        {
            Articles = new HashSet<Article>();
            ArticleComments = new HashSet<ArticleComment>();
            ProjectComments = new HashSet<ProjectComment>();
            Projects = new HashSet<Project>();
            Reporters = new HashSet<Report>();
            ReportedUsers = new HashSet<Report>();
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
        public DateTime? DateCreated { get; set; }
        public long AccessLevel { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
        public virtual ICollection<ProjectComment> ProjectComments { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Report> Reporters { get; set; }
        public virtual ICollection<Report> ReportedUsers { get; set; }
    }
}
