using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Kernel.Core.Utils
{
    public static class EnumExtensions
    {
        public static string GetName<T>(this T value)
        {
            return Enum.GetName(typeof(T), value);
        }

        public static string GetDescription<T>(this T e)
            where T : IConvertible
        {
            string description = null;

            if (!(e is Enum)) return null;

            var type = typeof(T);
            var values = Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val != e.ToInt32(CultureInfo.InvariantCulture)) continue;

                var memInfo = type.GetMember(type.GetEnumName(val));
                var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (descriptionAttributes.Length > 0) description = ((DescriptionAttribute)descriptionAttributes[0]).Description;

                break;
            }

            return description;
        }
    }
}
