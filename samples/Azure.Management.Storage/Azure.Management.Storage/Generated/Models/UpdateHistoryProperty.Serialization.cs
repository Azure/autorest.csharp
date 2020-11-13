// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class UpdateHistoryProperty
    {
        internal static UpdateHistoryProperty DeserializeUpdateHistoryProperty(JsonElement element)
        {
            Optional<ImmutabilityPolicyUpdateType> update = default;
            Optional<int> immutabilityPeriodSinceCreationInDays = default;
            Optional<DateTimeOffset> timestamp = default;
            Optional<string> objectIdentifier = default;
            Optional<string> tenantId = default;
            Optional<string> upn = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("update"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    update = new ImmutabilityPolicyUpdateType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("immutabilityPeriodSinceCreationInDays"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    immutabilityPeriodSinceCreationInDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("timestamp"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    timestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("objectIdentifier"))
                {
                    objectIdentifier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tenantId"))
                {
                    tenantId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("upn"))
                {
                    upn = property.Value.GetString();
                    continue;
                }
            }
            return new UpdateHistoryProperty(Optional.ToNullable(update), Optional.ToNullable(immutabilityPeriodSinceCreationInDays), Optional.ToNullable(timestamp), objectIdentifier.Value, tenantId.Value, upn.Value);
        }
    }
}
