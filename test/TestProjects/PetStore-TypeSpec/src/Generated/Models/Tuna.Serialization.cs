// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace PetStore.Models
{
    public partial class Tuna
    {
        internal static Tuna DeserializeTuna(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int fat = default;
            string kind = default;
            int size = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("fat"u8))
                {
                    fat = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("size"u8))
                {
                    size = property.Value.GetInt32();
                    continue;
                }
            }
            return new Tuna(kind, size, fat);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal new static Tuna FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeTuna(document.RootElement);
        }
    }
}
