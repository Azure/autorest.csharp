// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Xml;

namespace Azure.Core
{
    internal static class RequestHeaderExtensions
    {
        public static void Add(this RequestHeaders headers, string name, bool value)
        {
            headers.Add(name, value ? "true" : "false");
        }

        public static void Add(this RequestHeaders headers, string name, float value)
        {
            headers.Add(name, value.ToString("G"));
        }

        public static void Add(this RequestHeaders headers, string name, double value)
        {
            headers.Add(name, value.ToString("G"));
        }

        public static void Add(this RequestHeaders headers, string name, int value)
        {
            headers.Add(name, value.ToString("G"));
        }

        public static void Add(this RequestHeaders headers, string name, DateTime value, string format)
        {
            string formatted = format switch
            {
                "D" => value.ToString("yyyy-MM-dd"),
                "S" => value.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                "R" => value.ToString("R"),
                 _ => throw new ArgumentException("Format is not supported", nameof(format))
            };
            headers.Add(name, formatted);
        }

        public static void Add(this RequestHeaders headers, string name, TimeSpan value)
        {
            headers.Add(name, XmlConvert.ToString(value));
        }

        public static void Add(this RequestHeaders headers, string name, byte[] value)
        {
            headers.Add(name, Convert.ToBase64String(value));
        }

        public static void Add<T>(this RequestHeaders headers, string name, T value) where T: struct
        {
            headers.Add(name, value.ToString()!);
        }
    }
}
