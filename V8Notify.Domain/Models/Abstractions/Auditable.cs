using System;
using System.Collections.Generic;
using System.Text;

namespace V8Notify.Domain.Models.Abstractions
{
    public class Auditable : IAuditable
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
