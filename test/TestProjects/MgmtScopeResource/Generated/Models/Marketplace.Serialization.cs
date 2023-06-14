// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtScopeResource.Models
{
    public partial class Marketplace
    {
        internal static Marketplace DeserializeMarketplace(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> etag = default;
            Optional<IReadOnlyDictionary<string, string>> tags = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> billingPeriodId = default;
            Optional<DateTimeOffset> usageStart = default;
            Optional<DateTimeOffset> usageEnd = default;
            Optional<decimal> resourceRate = default;
            Optional<string> offerName = default;
            Optional<string> resourceGroup = default;
            Optional<string> additionalInfo = default;
            Optional<string> orderNumber = default;
            Optional<string> instanceName = default;
            Optional<string> instanceId = default;
            Optional<string> currency = default;
            Optional<decimal> consumedQuantity = default;
            Optional<string> unitOfMeasure = default;
            Optional<decimal> pretaxCost = default;
            Optional<bool> isEstimated = default;
            Optional<Guid> meterId = default;
            Optional<Guid> subscriptionGuid = default;
            Optional<string> subscriptionName = default;
            Optional<string> accountName = default;
            Optional<string> departmentName = default;
            Optional<string> consumedService = default;
            Optional<string> costCenter = default;
            Optional<string> additionalProperties = default;
            Optional<string> publisherName = default;
            Optional<string> planName = default;
            Optional<bool> isRecurringCharge = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
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
                        if (property0.NameEquals("billingPeriodId"u8))
                        {
                            billingPeriodId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("usageStart"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            usageStart = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("usageEnd"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            usageEnd = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("resourceRate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            resourceRate = property0.Value.GetDecimal();
                            continue;
                        }
                        if (property0.NameEquals("offerName"u8))
                        {
                            offerName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("resourceGroup"u8))
                        {
                            resourceGroup = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("additionalInfo"u8))
                        {
                            additionalInfo = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("orderNumber"u8))
                        {
                            orderNumber = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("instanceName"u8))
                        {
                            instanceName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("instanceId"u8))
                        {
                            instanceId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("currency"u8))
                        {
                            currency = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("consumedQuantity"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            consumedQuantity = property0.Value.GetDecimal();
                            continue;
                        }
                        if (property0.NameEquals("unitOfMeasure"u8))
                        {
                            unitOfMeasure = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("pretaxCost"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            pretaxCost = property0.Value.GetDecimal();
                            continue;
                        }
                        if (property0.NameEquals("isEstimated"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            isEstimated = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("meterId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            meterId = property0.Value.GetGuid();
                            continue;
                        }
                        if (property0.NameEquals("subscriptionGuid"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            subscriptionGuid = property0.Value.GetGuid();
                            continue;
                        }
                        if (property0.NameEquals("subscriptionName"u8))
                        {
                            subscriptionName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("accountName"u8))
                        {
                            accountName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("departmentName"u8))
                        {
                            departmentName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("consumedService"u8))
                        {
                            consumedService = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("costCenter"u8))
                        {
                            costCenter = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("additionalProperties"u8))
                        {
                            additionalProperties = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("publisherName"u8))
                        {
                            publisherName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("planName"u8))
                        {
                            planName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("isRecurringCharge"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            isRecurringCharge = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new Marketplace(id, name, type, systemData.Value, billingPeriodId.Value, Optional.ToNullable(usageStart), Optional.ToNullable(usageEnd), Optional.ToNullable(resourceRate), offerName.Value, resourceGroup.Value, additionalInfo.Value, orderNumber.Value, instanceName.Value, instanceId.Value, currency.Value, Optional.ToNullable(consumedQuantity), unitOfMeasure.Value, Optional.ToNullable(pretaxCost), Optional.ToNullable(isEstimated), Optional.ToNullable(meterId), Optional.ToNullable(subscriptionGuid), subscriptionName.Value, accountName.Value, departmentName.Value, consumedService.Value, costCenter.Value, additionalProperties.Value, publisherName.Value, planName.Value, Optional.ToNullable(isRecurringCharge), etag.Value, Optional.ToDictionary(tags));
        }
    }
}
