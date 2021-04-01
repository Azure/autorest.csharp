// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace TenantOnly
{
    public partial class InstructionProperties
    {
        internal static InstructionProperties DeserializeInstructionProperties(JsonElement element)
        {
            float amount = default;
            DateTimeOffset startDate = default;
            DateTimeOffset endDate = default;
            Optional<DateTimeOffset> creationDate = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("amount"))
                {
                    amount = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("startDate"))
                {
                    startDate = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("endDate"))
                {
                    endDate = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("creationDate"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    creationDate = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new InstructionProperties(amount, startDate, endDate, Optional.ToNullable(creationDate));
        }
    }
}
