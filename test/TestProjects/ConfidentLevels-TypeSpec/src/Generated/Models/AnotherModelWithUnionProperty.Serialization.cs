// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure;

namespace ConfidentLevelsInTsp.Models
{
    public partial class AnotherModelWithUnionProperty
    {
        internal static AnotherModelWithUnionProperty DeserializeAnotherModelWithUnionProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData unionProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("unionProperty"u8))
                {
                    unionProperty = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
            }
            return new AnotherModelWithUnionProperty(unionProperty);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static AnotherModelWithUnionProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAnotherModelWithUnionProperty(document.RootElement);
        }
    }
}
