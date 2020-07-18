using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class ArticleComment
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }
        public long? ArticleId { get; set; }
        public DateTime? DateCreated { get; set; }
        public long ReportCount { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
