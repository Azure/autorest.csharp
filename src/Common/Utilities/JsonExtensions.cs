using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.V3.Common.Utilities
{
    internal static class JsonExtensions
    {
        public static string ToJsonArray(this IEnumerable<string> values) => values != null ? $"[{String.Join(",", values.Select(v => $"\"{v}\""))}]" : "[]";
        public static string ToJsonArray(this IEnumerable<int> values) => values != null ? $"[{String.Join(",", values.Select(v => v.ToString()))}]" : "[]";
        public static string ToJsonArray(this IEnumerable<object> values) => values != null ? $"[{String.Join(",", values.Select(sl => sl.ToString()))}]" : "[]";

        public static string ToJsonBool(this bool value) => value ? "true" : "false";

        public static string TextOrEmpty(this object value, string text) => value != null ? text : String.Empty;

        //https://stackoverflow.com/a/324812/294804
        //private static string ToLiteral(string input)
        //{
        //    using var writer = new StringWriter();
        //    using var provider = CodeDomProvider.CreateProvider("CSharp");
        //    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
        //    return writer.ToString();
        //}

        public static string ToStringLiteral(this string text) =>
            !String.IsNullOrEmpty(text)
                ? text
                    .Replace("\\", "\\\\") // backslashes
                    .Replace("\"", "\\\"") // quotes
                    .Replace("\0", "\\0") // nulls
                    .Replace("\a", "\\a") // alert
                    .Replace("\b", "\\b") // backspace
                    .Replace("\f", "\\f") // form feed
                    .Replace("\n", "\\n") // newline
                    .Replace("\r", "\\r") // return
                    .Replace("\t", "\\t") // tab
                    .Replace("\v", "\\v") // vertical tab
                : text;

        public static string ToJsonStringOrNull(this string text) => !text.IsNullOrEmpty() ? $@"""{text}""" : "null";
    }
}
