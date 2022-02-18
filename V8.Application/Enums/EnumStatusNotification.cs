using System.ComponentModel;

namespace V8.Application.Enums
{
    public static class EnumStatusNotification
    {
        public enum Status
        {
            [Description("Chưa đọc")]
            Unread = 1,
            [Description("Đã đọc")]
            Read = 2,
        }
    }
}
