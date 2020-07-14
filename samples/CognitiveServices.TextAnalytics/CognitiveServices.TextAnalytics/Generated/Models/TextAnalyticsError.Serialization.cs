// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class TextAnalyticsError
    {
        internal static TextAnalyticsError DeserializeTextAnalyticsError(JsonElement element)
        {
            ErrorCodeValue code = default;
            string message = default;
            Optional<string> target = default;
            Optional<InnerError> innerError = default;
            Optional<IReadOnlyList<TextAnalyticsError>> details = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString().ToErrorCodeValue();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("innerError"))
                {
                    innerError = InnerError.DeserializeInnerError(property.Value);
                    continue;
                }
                if (property.NameEquals("details"))
                {
                    List<TextAnalyticsError> array = new List<TextAnalyticsError>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeTextAnalyticsError(item));
                    }
                    details = array;
                    continue;
                }
            }
            return new TextAnalyticsError(code, message, target.Value, innerError.Value, Optional.ToList(details));
        }
    }
}
