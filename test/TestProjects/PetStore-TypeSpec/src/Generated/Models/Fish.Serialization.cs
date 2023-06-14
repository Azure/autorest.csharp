// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;

namespace PetStore.Models
{
    public partial class Fish
    {
        internal static Fish DeserializeFish(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "shark": return Shark.DeserializeShark(element);
                    case "tuna": return Tuna.DeserializeTuna(element);
                }
            }
            return UnknownFish.DeserializeUnknownFish(element);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static Fish FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFish(document.RootElement);
        }
    }
}
