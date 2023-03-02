// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    internal partial class UnknownPetActionError
    {
        internal static UnknownPetActionError DeserializeUnknownPetActionError(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string errorType = "Unknown";
            Optional<string> errorMessage = default;
            Optional<string> actionResponse = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("errorType"u8))
                {
                    errorType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errorMessage"u8))
                {
                    errorMessage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("actionResponse"u8))
                {
                    actionResponse = property.Value.GetString();
                    continue;
                }
            }
            return new UnknownPetActionError(actionResponse.Value, errorType, errorMessage.Value);
        }
    }
}
