using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class Articles
    {
        public Articles()
        {
            Comments = new HashSet<Comments>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public long StatusValue { get; set; }
        public long EnableComments { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
