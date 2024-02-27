// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    public partial class RollingUpgradePolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (MaxBatchInstancePercent.HasValue)
            {
                writer.WritePropertyName("maxBatchInstancePercent"u8);
                writer.WriteNumberValue(MaxBatchInstancePercent.Value);
            }
            if (MaxUnhealthyInstancePercent.HasValue)
            {
                writer.WritePropertyName("maxUnhealthyInstancePercent"u8);
                writer.WriteNumberValue(MaxUnhealthyInstancePercent.Value);
            }
            if (MaxUnhealthyUpgradedInstancePercent.HasValue)
            {
                writer.WritePropertyName("maxUnhealthyUpgradedInstancePercent"u8);
                writer.WriteNumberValue(MaxUnhealthyUpgradedInstancePercent.Value);
            }
            if (PauseTimeBetweenBatches != null)
            {
                writer.WritePropertyName("pauseTimeBetweenBatches"u8);
                writer.WriteStringValue(PauseTimeBetweenBatches);
            }
            writer.WriteEndObject();
        }

        internal static RollingUpgradePolicy DeserializeRollingUpgradePolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? maxBatchInstancePercent = default;
            int? maxUnhealthyInstancePercent = default;
            int? maxUnhealthyUpgradedInstancePercent = default;
            string pauseTimeBetweenBatches = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxBatchInstancePercent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxBatchInstancePercent = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxUnhealthyInstancePercent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxUnhealthyInstancePercent = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxUnhealthyUpgradedInstancePercent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxUnhealthyUpgradedInstancePercent = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("pauseTimeBetweenBatches"u8))
                {
                    pauseTimeBetweenBatches = property.Value.GetString();
                    continue;
                }
            }
            return new RollingUpgradePolicy(maxBatchInstancePercent, maxUnhealthyInstancePercent, maxUnhealthyUpgradedInstancePercent, pauseTimeBetweenBatches);
        }
    }
}
