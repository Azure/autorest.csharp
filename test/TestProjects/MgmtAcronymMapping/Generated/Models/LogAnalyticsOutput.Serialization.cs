// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    internal partial class LogAnalyticsOutput
    {
        internal static LogAnalyticsOutput DeserializeLogAnalyticsOutput(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> output = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("output"u8))
                {
                    output = property.Value.GetString();
                    continue;
                }
            }
            return new LogAnalyticsOutput(output.Value);
        }
    }
}
