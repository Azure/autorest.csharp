// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class FirewallPolicyInsights : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (IsEnabled.HasValue)
            {
                writer.WritePropertyName("isEnabled"u8);
                writer.WriteBooleanValue(IsEnabled.Value);
            }
            if (RetentionDays.HasValue)
            {
                writer.WritePropertyName("retentionDays"u8);
                writer.WriteNumberValue(RetentionDays.Value);
            }
            if (LogAnalyticsResources != null)
            {
                writer.WritePropertyName("logAnalyticsResources"u8);
                writer.WriteObjectValue(LogAnalyticsResources);
            }
            writer.WriteEndObject();
        }

        internal static FirewallPolicyInsights DeserializeFirewallPolicyInsights(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? isEnabled = default;
            int? retentionDays = default;
            FirewallPolicyLogAnalyticsResources logAnalyticsResources = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("isEnabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isEnabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("retentionDays"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    retentionDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("logAnalyticsResources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    logAnalyticsResources = FirewallPolicyLogAnalyticsResources.DeserializeFirewallPolicyLogAnalyticsResources(property.Value);
                    continue;
                }
            }
            return new FirewallPolicyInsights(isEnabled, retentionDays, logAnalyticsResources);
        }
    }
}
