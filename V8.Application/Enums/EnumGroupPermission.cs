using System.ComponentModel;

namespace V8.Application.Enums
{
    public static class EnumGroupPermission
    {
        public enum Status
        {
            [Description("Không hiệu lực")]
            InActive = 0,
            [Description("Hiệu lực")]
            Active = 1,
        }
    }
}
