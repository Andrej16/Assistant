using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assistant
{
    public static class CoreTool
    {
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        public static bool IsSubclassOfRawGeneric(Type baseType, Type derivedType)
        {
            while (derivedType != null && derivedType != typeof(object))
            {
                var currentType = derivedType.IsGenericType ? derivedType.GetGenericTypeDefinition() : derivedType;
                if (baseType == currentType)
                {
                    return true;
                }
                derivedType = derivedType.BaseType;
            }
            return false;
        }

        public static void Output(object sender, object msg)
        {
            StackFrame stackFrame = new StackTrace(1).GetFrame(1);
            int lineNumber = stackFrame.GetFileLineNumber();

            Console.WriteLine("{0}[{1}:{3}]: {2}", DateTime.Now.ToLongTimeString(), sender?.GetType(), msg, lineNumber);
        }

        public static TAttribute GetEnumAttribute<TAttribute>(Enum enumVal) where TAttribute : Attribute
        {
            var memberInfo = enumVal.GetType().GetMember(enumVal.ToString());
            return memberInfo[0].GetCustomAttributes(typeof(TAttribute), false).OfType<TAttribute>().FirstOrDefault();
        }

        public static string MakeInsertSQLStatement(Type type)
        {
            StringBuilder builder = new StringBuilder("INSERT INTO ").AppendLine(type.Name);
            builder.Append("(");

            PropertyInfo[] propertyInfos = type.GetProperties();
            int counter = 0;

            foreach (var p in propertyInfos)
            {
                if (++counter == propertyInfos.Length)
                    builder.Append(p.Name).AppendLine(")");
                else
                    builder.Append(p.Name).AppendLine(",");
            }

            builder.AppendLine("VALUES");
            counter = 0;
            foreach (var p in type.GetProperties())
            {
                if (++counter == propertyInfos.Length)
                    builder.Append(p.Name).AppendLine(");");
                else
                    builder.Append(p.Name).AppendLine(",");
            }

            return builder.ToString();
        }
    }
}
