using System;
using System.Collections.Generic;
using System.IO;

namespace AutoRest.CodeModel
{
    internal static class StringExtensions
    {
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

        //https://stackoverflow.com/a/8809437/294804
        public static string ReplaceFirst(this string text, string oldValue, string newValue)
        {
            var position = text.IndexOf(oldValue, StringComparison.Ordinal);
            return position < 0 ? text : text.Substring(0, position) + newValue + text.Substring(position + oldValue.Length);
        }
    }
}
