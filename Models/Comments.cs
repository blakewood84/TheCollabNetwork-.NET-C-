using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class Comments
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }
        public long? ProjectId { get; set; }
        public long? ArticleId { get; set; }
        public long IsDraft { get; set; }
        public DateTime? DateCreated { get; set; }
        public long ReportCount { get; set; }

        public virtual Articles Article { get; set; }
        public virtual Projects Project { get; set; }
        public virtual Users User { get; set; }
    }
}
