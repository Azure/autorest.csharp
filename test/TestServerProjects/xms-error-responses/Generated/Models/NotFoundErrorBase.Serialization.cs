// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    internal partial class NotFoundErrorBase
    {
        internal static NotFoundErrorBase DeserializeNotFoundErrorBase(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("whatNotFound", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "AnimalNotFound": return AnimalNotFound.DeserializeAnimalNotFound(element);
                    case "InvalidResourceLink": return LinkNotFound.DeserializeLinkNotFound(element);
                }
            }
            Optional<string> reason = default;
            string whatNotFound = default;
            Optional<string> someBaseProp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("reason"u8))
                {
                    reason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("whatNotFound"u8))
                {
                    whatNotFound = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("someBaseProp"u8))
                {
                    someBaseProp = property.Value.GetString();
                    continue;
                }
            }
            return new NotFoundErrorBase(someBaseProp.Value, reason.Value, whatNotFound);
        }
    }
}
