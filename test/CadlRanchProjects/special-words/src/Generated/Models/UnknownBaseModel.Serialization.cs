// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace SpecialWords.Models
{
    internal partial class UnknownBaseModel
    {
        internal static UnknownBaseModel DeserializeUnknownBaseModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string modelKind = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("model.kind"u8))
                {
                    modelKind = property.Value.GetString();
                    continue;
                }
            }
            return new UnknownBaseModel(modelKind);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal new static UnknownBaseModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnknownBaseModel(document.RootElement);
        }
    }
}
