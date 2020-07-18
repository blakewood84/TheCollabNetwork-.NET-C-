using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class Report
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ReporterId { get; set; }
        public long? ProjectId { get; set; }
        public long? CommentId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Message { get; set; }
        
        public virtual User Reporter { get; set; }
        public virtual User User { get; set; }
    }
}
