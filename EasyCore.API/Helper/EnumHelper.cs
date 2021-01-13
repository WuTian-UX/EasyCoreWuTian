using System;
using System.ComponentModel;
using System.Reflection;

namespace EasyCore.API
{
    public class EnumHelper
    {
        private static string UnknownError { get; } = "未知错误";

        /// <summary>
        /// 根据枚举值获取描述信息
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumItemName">枚举值</param>
        /// <returns></returns>
        public static string GetDescriptionByName<T>(T enumItemName)
        {
            FieldInfo fieldInfo = enumItemName.GetType().GetField(enumItemName.ToString());
            if (fieldInfo == null)
            {
                return UnknownError;
            }

            DescriptionAttribute attributes =
                Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attributes == null)
            {
                return UnknownError;
            }

            return attributes.Description;
        }
    }
}
