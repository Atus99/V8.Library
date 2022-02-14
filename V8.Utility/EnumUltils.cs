using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace V8.Application.Commons
{
    public class EnumUltils
    {
        public static Dictionary<T, string> GetDescription<T>() where T : Enum
        {
            var rs = new Dictionary<T, string>();
            // gets the Type that contains all the info required    
            // to manipulate this type    
            Type enumType = typeof(T);

            // I will get all values and iterate through them    
            var enumValues = enumType.GetEnumValues();
            try
            {
                foreach (T item in enumValues)
                {
                    MemberInfo memberInfo = enumType.GetMember(item.ToString()).First();
                    var descriptionAttribute = memberInfo.GetCustomAttribute<DescriptionAttribute>();
                    if (descriptionAttribute != null)
                    {
                        rs.Add(item, descriptionAttribute.Description);
                    }
                    else
                    {
                        rs.Add(item, item.ToString());
                    }
                }
            }
            catch (Exception)
            {

            }
            return rs;
        }

        public static string GetDescriptionByValue<T>(T value) where T : Enum
        {
            var rs = string.Empty;
            // gets the Type that contains all the info required    
            // to manipulate this type    
            Type enumType = typeof(T);

            // I will get all values and iterate through them    
            var enumValues = enumType.GetEnumValues();
            try
            {
                foreach (T item in enumValues)
                {
                    if (item.Equals(value))
                    {
                        MemberInfo memberInfo = enumType.GetMember(item.ToString()).First();
                        var descriptionAttribute = memberInfo.GetCustomAttribute<DescriptionAttribute>();
                        if (descriptionAttribute != null)
                        {
                            rs = descriptionAttribute.Description;
                            break;
                        }

                    }

                }
            }
            catch (Exception)
            {
                return rs;
            }

            return rs;
        }

        public static List<SelectListItem> GetSelectListItem<T>(bool isName = true) where T : Enum
        {
            var rs = new List<SelectListItem>();
            // gets the Type that contains all the info required    
            // to manipulate this type    
            Type enumType = typeof(T);

            // I will get all values and iterate through them    
            var enumValues = enumType.GetEnumValues();
            try
            {
                foreach (T item in enumValues)
                {
                    MemberInfo memberInfo = enumType.GetMember(item.ToString()).First();
                    var descriptionAttribute = memberInfo.GetCustomAttribute<DescriptionAttribute>();
                    int itemCode = Convert.ToInt32(item);
                    if (descriptionAttribute != null)
                    {
                        rs.Add(new SelectListItem { Text = descriptionAttribute.Description, Value = isName ? item.ToString() : itemCode.ToString() });
                    }

                }
            }
            catch (Exception)
            {
                return rs;
            }

            return rs;
        }
    }
}
