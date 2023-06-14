// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
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
            Optional<ContentType> contentType = default;
            Optional<BinaryData> content = default;
            Optional<RequestMethod> method = default;
            Optional<Uri> basePath = default;
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
                if (property.NameEquals("contentType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    contentType = new ContentType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("content"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    content = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("method"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    method = new RequestMethod(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("basePath"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    basePath = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new LogAnalytics(properties.Value, Optional.ToNullable(contentType), content.Value, Optional.ToNullable(method), basePath.Value);
        }
    }
}
