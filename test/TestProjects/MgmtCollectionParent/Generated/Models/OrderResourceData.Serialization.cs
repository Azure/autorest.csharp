// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtCollectionParent.Models;

namespace MgmtCollectionParent
{
    public partial class OrderResourceData
    {
        internal static OrderResourceData DeserializeOrderResourceData(JsonElement element)
        {
            Optional<ResourceIdentifier> id = default;
            Optional<string> name = default;
            Optional<ResourceType> type = default;
            Optional<SystemData> systemData = default;
            Optional<IReadOnlyList<string>> orderItemIds = default;
            Optional<StageDetails> currentStage = default;
            Optional<IReadOnlyList<StageDetails>> orderStageHistory = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("orderItemIds"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            orderItemIds = array;
                            continue;
                        }
                        if (property0.NameEquals("currentStage"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            currentStage = StageDetails.DeserializeStageDetails(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("orderStageHistory"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<StageDetails> array = new List<StageDetails>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(StageDetails.DeserializeStageDetails(item));
                            }
                            orderStageHistory = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new OrderResourceData(id, name, type, systemData, Optional.ToList(orderItemIds), currentStage.Value, Optional.ToList(orderStageHistory));
        }
    }
}
