using System;
using System.Collections.Generic;
using System.Text;

namespace V8Hangfire.Domain.Models.Abstractions
{
    public class Auditable : IAuditable
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
