﻿using System.ComponentModel;
using System.Reflection;

namespace DesafioBackEnd.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());
            return field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                  .FirstOrDefault() is not DescriptionAttribute attribute ? value.ToString() : attribute.Description;
        }
    }
}
