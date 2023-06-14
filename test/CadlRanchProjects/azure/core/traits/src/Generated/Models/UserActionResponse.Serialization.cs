// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Specs_.Azure.Core.Traits.Models
{
    public partial class UserActionResponse
    {
        internal static UserActionResponse DeserializeUserActionResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string userActionResult = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("userActionResult"u8))
                {
                    userActionResult = property.Value.GetString();
                    continue;
                }
            }
            return new UserActionResponse(userActionResult);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static UserActionResponse FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUserActionResponse(document.RootElement);
        }
    }
}
