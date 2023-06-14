// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    internal partial class UnknownOutputBaseModelWithDiscriminator
    {
        internal static UnknownOutputBaseModelWithDiscriminator DeserializeUnknownOutputBaseModelWithDiscriminator(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
            }
            return new UnknownOutputBaseModelWithDiscriminator(kind);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal new static UnknownOutputBaseModelWithDiscriminator FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnknownOutputBaseModelWithDiscriminator(document.RootElement);
        }
    }
}
