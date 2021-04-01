// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace TenantOnly
{
    internal partial class ErrorDetails
    {
        internal static ErrorDetails DeserializeErrorDetails(JsonElement element)
        {
            Optional<string> code = default;
            Optional<string> message = default;
            Optional<string> target = default;
            Optional<IReadOnlyList<ErrorSubDetailsItem>> details = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString();
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
                if (property.NameEquals("details"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ErrorSubDetailsItem> array = new List<ErrorSubDetailsItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ErrorSubDetailsItem.DeserializeErrorSubDetailsItem(item));
                    }
                    details = array;
                    continue;
                }
            }
            return new ErrorDetails(code.Value, message.Value, target.Value, Optional.ToList(details));
        }
    }
}
