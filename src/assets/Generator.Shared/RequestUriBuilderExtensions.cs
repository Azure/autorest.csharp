// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace Azure.Core
{
    internal static class RequestUriBuilderExtensions
    {
        private static string ConvertToString(object value, string? format = null)
            => value switch
            {
                string s => s,
                bool b => TypeFormatters.ToString(b),
                int or float or double or long or decimal => ((IFormattable)value).ToString(TypeFormatters.DefaultNumberFormat, CultureInfo.InvariantCulture),
                byte[] b when format != null => TypeFormatters.ToString(b, format),
                IEnumerable<string> s => string.Join(",", s),
                DateTimeOffset dateTime when format != null => TypeFormatters.ToString(dateTime, format),
                TimeSpan timeSpan when format != null => TypeFormatters.ToString(timeSpan, format),
                TimeSpan timeSpan => XmlConvert.ToString(timeSpan),
                Guid guid => guid.ToString(),
                _ => value.ToString()!
            };

        public static void AppendPath(this RequestUriBuilder builder, bool value, bool escape = false)
        {
            builder.AppendPath(ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, float value, bool escape = true)
        {
            builder.AppendPath(ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, double value, bool escape = true)
        {
            builder.AppendPath(ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, int value, bool escape = true)
        {
            builder.AppendPath(ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, byte[] value, string format, bool escape = true)
        {
            builder.AppendPath(ConvertToString(value, format), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, IEnumerable<string> value, bool escape = true)
        {
            builder.AppendPath(ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, DateTimeOffset value, string format, bool escape = true)
        {
            builder.AppendPath(ConvertToString(value, format), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, TimeSpan value, string format, bool escape = true)
        {
            builder.AppendPath(ConvertToString(value, format), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, Guid value, bool escape = true)
        {
            builder.AppendPath(ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, long value, bool escape = true)
        {
            builder.AppendPath(ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, bool value, bool escape = false)
        {
            builder.AppendQuery(name, ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, float value, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, DateTimeOffset value, string format, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value, format), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, TimeSpan value, string format, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value, format), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, double value, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, decimal value, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, int value, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, long value, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, TimeSpan value, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, byte[] value, string format, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value, format), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, Guid value, bool escape = true)
        {
            builder.AppendQuery(name, ConvertToString(value), escape);
        }

        public static void AppendQueryDelimited<T>(this RequestUriBuilder builder, string name, IEnumerable<T> value, string delimiter, bool escape = true) where T : notnull
        {
            var stringValues = value.Select(v => ConvertToString(v));
            builder.AppendQuery(name, string.Join(delimiter, stringValues), escape);
        }
    }
}
