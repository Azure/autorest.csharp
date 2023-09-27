// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Rest.Experimental.Core;

namespace OpenAI.Models
{
    internal static class RequestUriExtensions
    {
        public static void AppendPath(this RequestUri builder, bool value, bool escape = false)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUri builder, float value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUri builder, double value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUri builder, int value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUri builder, byte[] value, string format, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendPath(this RequestUri builder, IEnumerable<string> value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUri builder, DateTimeOffset value, string format, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendPath(this RequestUri builder, TimeSpan value, string format, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendPath(this RequestUri builder, Guid value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUri builder, long value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, bool value, bool escape = false)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, float value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, DateTimeOffset value, string format, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, TimeSpan value, string format, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, double value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, decimal value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, int value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, long value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, TimeSpan value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, byte[] value, string format, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendQuery(this RequestUri builder, string name, Guid value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQueryDelimited<T>(this RequestUri builder, string name, IEnumerable<T> value, string delimiter, bool escape = true)
        {
            var stringValues = value.Select(v => TypeFormatters.ConvertToString(v));
            builder.AppendQuery(name, string.Join(delimiter, stringValues), escape);
        }

        public static void AppendQueryDelimited<T>(this RequestUri builder, string name, IEnumerable<T> value, string delimiter, string format, bool escape = true)
        {
            var stringValues = value.Select(v => TypeFormatters.ConvertToString(v, format));
            builder.AppendQuery(name, string.Join(delimiter, stringValues), escape);
        }
    }
}
