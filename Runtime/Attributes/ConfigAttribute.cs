using System;
using Depra.Configuration.Runtime.Assets;

namespace Depra.Configuration.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigAttribute : Attribute, IComparable
    {
        private const int UndefinedOrderId = -1;

        public string FileName { get; set; }
        public string DisplayName { get; set; }
        public int OrderId { get; set; }

        public static ConfigAttribute Find<T>() where T : ConfigObject => Find(typeof(T));

        public static ConfigAttribute Find(Type type) =>
            (ConfigAttribute)GetCustomAttribute(type, typeof(ConfigAttribute));

        public int CompareTo(object obj)
        {
            if (obj is not ConfigAttribute otherAttribute || otherAttribute.OrderId == UndefinedOrderId)
            {
                return -1;
            }

            if (OrderId == otherAttribute.OrderId)
            {
                return string.CompareOrdinal(DisplayName, otherAttribute.DisplayName);
            }

            return OrderId > otherAttribute.OrderId ? 1 : -1;
        }
    }
}