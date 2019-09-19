using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRest.CSharp.V3.Common.Utilities
{
    internal static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text) => String.IsNullOrEmpty(text);
        public static bool IsNullOrWhiteSpace(this string text) => String.IsNullOrWhiteSpace(text);
        public static string NullIfEmpty(this string text) => text.IsNullOrEmpty() ? null : text;
        public static string NullIfWhiteSpace(this string text) => text.IsNullOrWhiteSpace() ? null : text;
        public static string EmptyIfNull(this string text) => text ?? String.Empty;
    }
}
