// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Authentication.OAuth2.Models
{
    public partial class InvalidAuth
    {
        internal static InvalidAuth DeserializeInvalidAuth(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("error"u8))
                {
                    error = property.Value.GetString();
                    continue;
                }
            }
            return new InvalidAuth(error);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static InvalidAuth FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInvalidAuth(document.RootElement);
        }
    }
}
