// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    internal partial class UnknownBaseModelWithDiscriminator
    {
        internal static UnknownBaseModelWithDiscriminator DeserializeUnknownBaseModelWithDiscriminator(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string discriminatorProperty = "Unknown";
            Optional<string> optionalPropertyOnBase = default;
            int requiredPropertyOnBase = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("discriminatorProperty"u8))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("optionalPropertyOnBase"u8))
                {
                    optionalPropertyOnBase = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredPropertyOnBase"u8))
                {
                    requiredPropertyOnBase = property.Value.GetInt32();
                    continue;
                }
            }
            return new UnknownBaseModelWithDiscriminator(discriminatorProperty, optionalPropertyOnBase.Value, requiredPropertyOnBase);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal new static UnknownBaseModelWithDiscriminator FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnknownBaseModelWithDiscriminator(document.RootElement);
        }
    }
}
