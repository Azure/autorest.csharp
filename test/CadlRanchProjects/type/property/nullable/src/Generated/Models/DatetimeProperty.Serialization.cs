// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    public partial class DatetimeProperty
    {
        internal static DatetimeProperty DeserializeDatetimeProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredProperty = default;
            DateTimeOffset? nullableProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredProperty"u8))
                {
                    requiredProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nullableProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nullableProperty = null;
                        continue;
                    }
                    nullableProperty = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new DatetimeProperty(requiredProperty, nullableProperty);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static DatetimeProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDatetimeProperty(document.RootElement);
        }
    }
}
