// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ImmutabilityPolicyProperties
    {
        internal static ImmutabilityPolicyProperties DeserializeImmutabilityPolicyProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ETag etag = default;
            IReadOnlyList<UpdateHistoryProperty> updateHistory = default;
            int immutabilityPeriodSinceCreationInDays = default;
            ImmutabilityPolicyState state = default;
            bool allowProtectedAppendWrites = default;
            bool allowProtectedAppendWritesAll = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    etag = new ETag(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("updateHistory"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<UpdateHistoryProperty> array = new List<UpdateHistoryProperty>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(UpdateHistoryProperty.DeserializeUpdateHistoryProperty(item));
                    }
                    updateHistory = array;
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("immutabilityPeriodSinceCreationInDays"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            immutabilityPeriodSinceCreationInDays = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("state"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            state = new ImmutabilityPolicyState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("allowProtectedAppendWrites"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allowProtectedAppendWrites = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("allowProtectedAppendWritesAll"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allowProtectedAppendWritesAll = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ImmutabilityPolicyProperties(
                etag,
                updateHistory ?? new ChangeTrackingList<UpdateHistoryProperty>(),
                immutabilityPeriodSinceCreationInDays,
                state,
                allowProtectedAppendWrites,
                allowProtectedAppendWritesAll);
        }
    }
}
