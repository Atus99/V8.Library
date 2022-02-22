using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace V8.Domain.Models.V8
{
    [Description("Bảng nhóm quyền - chứa các quyền cơ bản trong hệ thống và dc cấp cho người dùng")]
    public class GroupPermission
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Khóa chính")]
        public int ID { get; set; }
        public int IDChannel { get; set; } = 0;
        [Required]
        [MaxLength(250)]
        [Description("Tên nhóm quyền")]
        public string Name { get; set; }
        [MaxLength(250)]
        [Description("Mô tả")]
        public string Description { get; set; }
        [Description("Trạng thái")]
        public int Status { get; set; } = 1;
    }
}
