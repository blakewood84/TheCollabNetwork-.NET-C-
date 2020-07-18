using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class Article
    {
        public Article()
        {
            ArticleComments = new HashSet<ArticleComment>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public long StatusValue { get; set; }
        public long EnableComments { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
    }
}
