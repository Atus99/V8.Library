using System.ComponentModel;

namespace V8.Application.Enums
{
    public static class EnumPermission
    {
        public enum Type
        {
            [Description("Xem")]
            Read = 1,
            [Description("Tạo mới")]
            Create = 2,
            [Description("Chỉnh sửa")]
            Update = 3,
            [Description("Xóa")]
            Deleted = 4,
            [Description("Import")]
            Import = 5,
            [Description("Export")]
            Export = 6,
            [Description("Phê duyệt")]
            Approve = 7,
            [Description("In ấn")]
            Print = 8,
            [Description("Phân quyền")]
            Grant = 9,
            [Description("Gửi duyệt")]
            Send = 10,
            [Description("Ký số")]
            DigitallySigned = 11,
            [Description("Đóng/mở")]
            OpenClose = 12,
            [Description("Gia hạn")]
            Extend = 13,
            [Description("Sao chép")]
            Copy = 14,
        }
    }
}
