using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoRest.CSharp.V3.Common.Utilities
{
    internal static class JsonExtensions
    {
        public static string ToJsonArray(this IEnumerable<string> values) => values != null ? $"[{String.Join(",", values.Select(v => $"\"{v}\""))}]" : "[]";

        public static string ToJsonArray(this IEnumerable<int> values) => values != null ? $"[{String.Join(",", values.Select(v => v.ToString()))}]" : "[]";

        public static string ToJsonArray(this IEnumerable<object> values) => values != null ? $"[{String.Join(",", values.Select(sl => sl.ToString()))}]" : "[]";

        public static string ToJsonBool(this bool value) => value ? "true" : "false";

        public static string TextOrEmpty(this object value, string text) => value != null ? text : String.Empty;
    }
}
