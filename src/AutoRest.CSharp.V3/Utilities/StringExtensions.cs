using System;
using System.Collections.Generic;
using System.IO;

namespace AutoRest.CSharp.V3.Utilities
{
    internal static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text) => String.IsNullOrEmpty(text);
        public static bool IsNullOrWhiteSpace(this string text) => String.IsNullOrWhiteSpace(text);
        public static string NullIfEmpty(this string text) => text.IsNullOrEmpty() ? null : text;
        public static string NullIfWhiteSpace(this string text) => text.IsNullOrWhiteSpace() ? null : text;
        public static string EmptyIfNull(this string text) => text ?? String.Empty;

        //https://stackoverflow.com/a/41176852/294804
        public static IEnumerable<string> ToLines(this string value, bool removeEmptyLines = false)
        {
            using var sr = new StringReader(value);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (removeEmptyLines && String.IsNullOrWhiteSpace(line)) continue;
                yield return line;
            }
        }
    }
}
