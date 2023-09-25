// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;

namespace _Type.Model.Inheritance.SingleDiscriminator.Models
{
    internal partial class UnknownBird
    {
        internal static UnknownBird DeserializeUnknownBird(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = "Unknown";
            int wingspan = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("wingspan"u8))
                {
                    wingspan = property.Value.GetInt32();
                    continue;
                }
            }
            return new UnknownBird(kind, wingspan);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new UnknownBird FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnknownBird(document.RootElement);
        }
    }
}
