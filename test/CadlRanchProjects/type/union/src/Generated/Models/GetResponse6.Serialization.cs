// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;

namespace _Type.Union.Models
{
    public partial class GetResponse6
    {
        internal static GetResponse6 DeserializeGetResponse6(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            EnumsOnlyCases prop = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("prop"u8))
                {
                    prop = EnumsOnlyCases.DeserializeEnumsOnlyCases(property.Value);
                    continue;
                }
            }
            return new GetResponse6(prop);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static GetResponse6 FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeGetResponse6(document.RootElement);
        }
    }
}
