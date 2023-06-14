// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    public partial class PetAction
    {
        internal static PetAction DeserializePetAction(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> actionResponse = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("actionResponse"u8))
                {
                    actionResponse = property.Value.GetString();
                    continue;
                }
            }
            return new PetAction(actionResponse.Value);
        }
    }
}
