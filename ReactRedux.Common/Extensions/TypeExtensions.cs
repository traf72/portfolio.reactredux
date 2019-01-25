using System;

namespace ReactRedux.Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsSubclassOfRawGeneric(this Type type, Type rawGenericType)
        {
            while (type != null && type != typeof(object))
            {
                Type cur = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
                if (rawGenericType == cur)
                {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }
    }
}