using System.ComponentModel;

namespace V8.Application.Enums
{
    public static class EnumModule
    {
        public enum Code
        {
            [Description("Quản lý nhóm quyền")]
            S9030 = 7,
            [Description("Quản lý nhóm người dùng")]
            S9010 = 8,
            [Description("Quản lý người dùng")]
            S9020 = 9,
        }
    }
}
