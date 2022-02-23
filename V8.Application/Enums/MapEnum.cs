using System;
using System.Collections.Generic;
using System.Text;

namespace V8.Application.Enums
{
    public static class MapEnum
    {
        public static Dictionary<int, List<EnumPermission.Type>> MatrixPermission
        {
            get
            {
                var Map = new Dictionary<int, List<EnumPermission.Type>>();

                Map.Add((int)EnumModule.Code.S9030, new List<EnumPermission.Type> { EnumPermission.Type.Read, EnumPermission.Type.Print, EnumPermission.Type.Export, EnumPermission.Type.Update, EnumPermission.Type.Deleted, EnumPermission.Type.Create, EnumPermission.Type.Copy });

                Map.Add((int)EnumModule.Code.S9010, new List<EnumPermission.Type> { EnumPermission.Type.Read, EnumPermission.Type.Print, EnumPermission.Type.Export, EnumPermission.Type.Update, EnumPermission.Type.Deleted, EnumPermission.Type.Create, EnumPermission.Type.Grant });

                Map.Add((int)EnumModule.Code.S9020, new List<EnumPermission.Type> { EnumPermission.Type.Read, EnumPermission.Type.Print, EnumPermission.Type.Export, EnumPermission.Type.Update, EnumPermission.Type.Deleted, EnumPermission.Type.Create, EnumPermission.Type.Import, EnumPermission.Type.Grant });

                return Map;
            }
        }
    }
}
