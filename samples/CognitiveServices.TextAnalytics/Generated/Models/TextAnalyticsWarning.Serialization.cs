// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class TextAnalyticsWarning
    {
        internal static TextAnalyticsWarning DeserializeTextAnalyticsWarning(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            WarningCodeValue code = default;
            string message = default;
            Optional<string> targetRef = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"u8))
                {
                    code = property.Value.GetString().ToWarningCodeValue();
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetRef"u8))
                {
                    targetRef = property.Value.GetString();
                    continue;
                }
            }
            return new TextAnalyticsWarning(code, message, targetRef.Value);
        }
    }
}
