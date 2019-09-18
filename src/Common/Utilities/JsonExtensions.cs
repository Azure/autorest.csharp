using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoRest.CSharp.V3.Common.Utilities
{
    internal static class JsonExtensions
    {
        public static string ToJsonArray(this IEnumerable<string> values) => $"[{String.Join(",", values.Select(v => $"\"{v}\""))}]";

        public static string ToJsonBool(this bool value) => value ? "true" : "false";
    }
}
