using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JsonFormattingAssignment
{
    public static class JsonFormatter
    {

        private static string FormatPrimitive(object obj)
        {
            if (obj is string || obj is char)
                return $"\"{obj}\"";
            else if (obj is DateTime)
                return $"\"{((DateTime)obj).ToString("o")}\"";
            else if (obj is bool)
                return obj.ToString().ToLower();
            else
                return obj.ToString();
        }

        public static string Convert(object item)
        {
            if (item == null)
                return "null";

            Type type = item.GetType();
            if (Type.GetTypeCode(type) != TypeCode.Object || type == typeof(DateTime))
                return FormatPrimitive(item);

            StringBuilder sb = new StringBuilder();
            if (type.IsArray)
            {
                Array array = (Array)item;
                sb.Append("[");
                for (int i = 0; i < array.Length; i++)
                {
                    sb.Append(Convert(array.GetValue(i)));
                    if (i < array.Length - 1)
                        sb.Append(",");
                }
                sb.Append("]");
            }
            else if (typeof(System.Collections.IList).IsAssignableFrom(type))
            {
                System.Collections.IList list = (System.Collections.IList)item;
                sb.Append("[");
                for (int i = 0; i < list.Count; i++)
                {
                    sb.Append(Convert(list[i]));
                    if (i < list.Count - 1)
                        sb.Append(",");
                }
                sb.Append("]");
            }
            else
            {
                sb.Append("{");
                PropertyInfo[] properties = type.GetProperties();
                bool first = true;
                foreach (PropertyInfo prop in properties)
                {
                    if (!first)
                        sb.Append(",");
                    else
                        first = false;

                    sb.Append($"\"{prop.Name}\":{Convert(prop.GetValue(item))}");
                }
                sb.Append("}");
            }
            return sb.ToString();
        }
    }
}