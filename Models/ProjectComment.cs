using System;
using System.Collections.Generic;

namespace collabnetwork_.net_c_.Models
{
    public partial class ProjectComment
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }
        public long? ProjectId { get; set; }
        public DateTime? DateCreated { get; set; }
        public long ReportCount { get; set; }
        public long IsDraft { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
