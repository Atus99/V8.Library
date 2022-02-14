using System;
using System.Collections.Generic;
using System.Text;

namespace V8Notify.Domain.Models.Abstractions
{
    public interface IAuditable
    {
        int? CreatedBy { get; set; }

        DateTime? CreateDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        int? UpdatedBy { get; set; }
    }
}
