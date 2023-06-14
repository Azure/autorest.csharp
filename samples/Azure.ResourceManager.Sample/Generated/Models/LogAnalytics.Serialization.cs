// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class LogAnalytics
    {
        internal static LogAnalytics DeserializeLogAnalytics(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<LogAnalyticsOutput> properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = Models.LogAnalyticsOutput.DeserializeLogAnalyticsOutput(property.Value);
                    continue;
                }
            }
            return new LogAnalytics(properties.Value);
        }
    }
}
