using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace V8.Domain.Models.V8
{
    [Description("Bảng Menu")]
    public class Module
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Khóa chính")]
        public int ID { get; set; }

        public int IDChannel { get; set; } = 0;

        [Description("ID của menu cha")]
        public int ParentId { get; set; }

        [Description("string mô tả các cấp menu cha nếu có")]
        public string ParentPath { get; set; }

        [MaxLength(10)]
        [Description("Mã phân quyền: enum EnumModule.Code")]
        public int Code { get; set; }

        [Required]
        [MaxLength(250)]
        [Description("Tên hiển thị của Menu")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Description("Đường dẫn của Menu")]
        public string Url { get; set; }

        [MaxLength(30)]
        [Description("Tên biểu tượng được dùng cho Menu")]
        public string Icon { get; set; }

        [Description("Giá trị xác định thứ tự sắp xếp của Menu trong cùng cấp")]
        public int SortOrder { get; set; }

        [Description("Trạng thái: enum EnumCommon.Status")]
        public int Status { get; set; } = 1;

        [Description("Hiển thị: enum EnumCommon.IsShow")]
        public int IsShow { get; set; } = 1;
    }
}
