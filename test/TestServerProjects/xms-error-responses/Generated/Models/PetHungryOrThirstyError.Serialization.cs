// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    public partial class PetHungryOrThirstyError
    {
        internal static PetHungryOrThirstyError DeserializePetHungryOrThirstyError(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> hungryOrThirsty = default;
            Optional<string> reason = default;
            string errorType = default;
            Optional<string> errorMessage = default;
            Optional<string> actionResponse = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hungryOrThirsty"u8))
                {
                    hungryOrThirsty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("reason"u8))
                {
                    reason = property.Value.GetString();
                    continue;
                }
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
            return new PetHungryOrThirstyError(actionResponse.Value, errorType, errorMessage.Value, reason.Value, hungryOrThirsty.Value);
        }
    }
}
