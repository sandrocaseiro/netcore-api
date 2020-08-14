using NetCoreAPI.Attributes;
using NetCoreAPI.Exceptions;
using NetCoreAPI.Models;
using System;
using System.ComponentModel;
using System.Reflection;

namespace NetCoreAPI.Helpers
{
    public static class EnumExtensions
    {
        public static string ToDescription(this DResponse<dynamic>.ErrorType value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute?.Description ?? value.ToString();
        }

        public static DResponse<dynamic>.ErrorType ToErrorType(this string description)
        {
            var type = typeof(DResponse<dynamic>.ErrorType);
            if (!type.IsEnum)
                throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (DResponse<dynamic>.ErrorType)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (DResponse<dynamic>.ErrorType)field.GetValue(null);
                }
            }
            
            throw new ArgumentException("Not found.", nameof(description));
        }

        public static int ToHttpStatus(this AppErrors value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            var attribute = Attribute.GetCustomAttribute(field, typeof(AppErrorAttribute)) as AppErrorAttribute;

            return attribute?.HttpStatus ?? 0;
        }

        public static int ToCode(this AppErrors value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            var attribute = Attribute.GetCustomAttribute(field, typeof(AppErrorAttribute)) as AppErrorAttribute;

            return attribute?.Code ?? 0;
        }

        public static string ToMessageRes(this AppErrors value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            var attribute = Attribute.GetCustomAttribute(field, typeof(AppErrorAttribute)) as AppErrorAttribute;

            return attribute?.MessageRes ?? string.Empty;
        }
    }
}
