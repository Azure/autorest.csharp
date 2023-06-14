// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    public partial class BytesProperty
    {
        internal static BytesProperty DeserializeBytesProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredProperty = default;
            BinaryData nullableProperty = default;
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
                    nullableProperty = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
            }
            return new BytesProperty(requiredProperty, nullableProperty);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static BytesProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeBytesProperty(document.RootElement);
        }
    }
}
