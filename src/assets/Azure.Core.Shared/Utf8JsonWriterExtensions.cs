// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;

namespace Azure.Core
{
    internal static class Utf8JsonWriterExtensions
    {
        public static void WriteStringValue(this Utf8JsonWriter writer, DateTimeOffset value, string format) =>
            writer.WriteStringValue(TypeFormatters.ToString(value, format));

        public static void WriteStringValue(this Utf8JsonWriter writer, TimeSpan value, string format) =>
            writer.WriteStringValue(TypeFormatters.ToString(value, format));
    }
}
