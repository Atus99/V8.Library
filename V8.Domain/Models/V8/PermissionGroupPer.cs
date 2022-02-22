using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace V8.Domain.Models.V8
{
    [Description("Bảng trung gian giữa nhóm quyền và quyền cơ bản")]
    public class PermissionGroupPer
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Khóa chính")]
        public int ID { get; set; }

        public int IDChannel { get; set; } = 0;

        [Required]
        [Description("ID quyền")]
        public int IDPermission { get; set; }

        [Required]
        [Description("ID nhóm quyền")]
        public int IDGroupPermission { get; set; }

        [Description("Người tạo")]
        public int? CreatedBy { get; set; }

        [Description("Trạng thái")]
        public int Status { get; set; }

        [Required]
        [Description("Ngày tạo")]
        public DateTime CreateDate { get; set; }
    }
}
