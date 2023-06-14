// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Model.Usage.Models
{
    public partial class OutputRecord
    {
        internal static OutputRecord DeserializeOutputRecord(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredProp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredProp"u8))
                {
                    requiredProp = property.Value.GetString();
                    continue;
                }
            }
            return new OutputRecord(requiredProp);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static OutputRecord FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOutputRecord(document.RootElement);
        }
    }
}
