// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;

namespace body_datetime_rfc1123
{
    internal static partial class RequestHeaderExtensions
    {
        public static void Add(this RequestHeaders headers, string name, bool value)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value));
        }

        public static void Add(this RequestHeaders headers, string name, float value)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value));
        }

        public static void Add(this RequestHeaders headers, string name, double value)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value));
        }

        public static void Add(this RequestHeaders headers, string name, int value)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value));
        }

        public static void Add(this RequestHeaders headers, string name, long value)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value));
        }

        public static void Add(this RequestHeaders headers, string name, DateTimeOffset value, string format)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value, format));
        }

        public static void Add(this RequestHeaders headers, string name, TimeSpan value, string format)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value, format));
        }

        public static void Add(this RequestHeaders headers, string name, Guid value)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value));
        }

        public static void Add(this RequestHeaders headers, string name, byte[] value, string format)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value, format));
        }

        public static void Add(this RequestHeaders headers, string name, BinaryData value, string format)
        {
            headers.Add(name, ModelSerializationExtensions.TypeFormatters.ConvertToString(value, format));
        }

        public static void Add(this RequestHeaders headers, string prefix, IDictionary<string, string> headersToAdd)
        {
            foreach (var header in headersToAdd)
            {
                headers.Add(prefix + header.Key, header.Value);
            }
        }

        public static void Add(this RequestHeaders headers, string name, ETag value)
        {
            headers.Add(name, value.ToString("H"));
        }

        public static void Add(this RequestHeaders headers, MatchConditions conditions)
        {
            if (conditions.IfMatch != null)
            {
                headers.Add("If-Match", conditions.IfMatch.Value);
            }

            if (conditions.IfNoneMatch != null)
            {
                headers.Add("If-None-Match", conditions.IfNoneMatch.Value);
            }
        }

        public static void Add(this RequestHeaders headers, RequestConditions conditions, string format)
        {
            if (conditions.IfMatch != null)
            {
                headers.Add("If-Match", conditions.IfMatch.Value);
            }

            if (conditions.IfNoneMatch != null)
            {
                headers.Add("If-None-Match", conditions.IfNoneMatch.Value);
            }

            if (conditions.IfModifiedSince != null)
            {
                headers.Add("If-Modified-Since", conditions.IfModifiedSince.Value, format);
            }

            if (conditions.IfUnmodifiedSince != null)
            {
                headers.Add("If-Unmodified-Since", conditions.IfUnmodifiedSince.Value, format);
            }
        }

        public static void AddDelimited<T>(this RequestHeaders headers, string name, IEnumerable<T> value, string delimiter)
        {
            headers.Add(name, string.Join(delimiter, value));
        }

        public static void AddDelimited<T>(this RequestHeaders headers, string name, IEnumerable<T> value, string delimiter, string format)
        {
            IEnumerable<string> stringValues = value.Select(v => ModelSerializationExtensions.TypeFormatters.ConvertToString(v, format));
            headers.Add(name, string.Join(delimiter, stringValues));
        }
    }
}
