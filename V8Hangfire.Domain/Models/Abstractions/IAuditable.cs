using System;
using System.Collections.Generic;
using System.Text;

namespace V8Hangfire.Domain.Models.Abstractions
{
    public interface IAuditable
    {
        int? CreatedBy { get; set; }

        DateTime? CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        int? UpdatedBy { get; set; }
    }
}
