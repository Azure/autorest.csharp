// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;

namespace MgmtMockAndSample.Models
{
    public partial class CheckNameAvailabilityResult
    {
        internal static CheckNameAvailabilityResult DeserializeCheckNameAvailabilityResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool nameAvailable = default;
            Reason reason = default;
            string message = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("nameAvailable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nameAvailable = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("reason"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    reason = property.Value.GetString().ToReason();
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
            }
            return new CheckNameAvailabilityResult(nameAvailable, reason, message);
        }
    }
}
