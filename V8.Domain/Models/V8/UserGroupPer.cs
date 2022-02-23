using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using V8.Domain.Models.Abstractions;

namespace V8.Domain.Models.V8
{
    [Description("Bảng trung gian giữa người dùng và nhóm quyền")]
    public class UserGroupPer
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Khóa chính")]
        public int ID { get; set; }

        public int IDChannel { get; set; } = 0;

        [Required]
        [Description("ID người dùng")]
        public int IDUser { get; set; }

        [Required]
        [Description("ID nhóm quyền")]
        public int IDGroupPer { get; set; }

        [Description("Người tạo")]
        public int? CreatedBy { get; set; }

        [Description("Trạng thái")]
        public int Status { get; set; } = 1;

        [Description("Ngày tạo")]
        public DateTime? CreateDate { get; set; }
    }
}
