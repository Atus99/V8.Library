using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace V8.Domain.Models.V8
{
    [Description("Bảng quyền - Chứa các quyền cơ bản của hệ thống")]
    public class Permission
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Khóa chính")]
        public int ID { get; set; }

        public int IDChannel { get; set; } = 0;

        [Required]
        [Description("ID Menu")]
        public int IDModule { get; set; }

        [Required]
        [Description("Loại quyền")]
        public int Type { get; set; }

        [Required]
        [MaxLength(250)]
        [Description("Tên quyền")]
        public string Name { get; set; }
    }
}
