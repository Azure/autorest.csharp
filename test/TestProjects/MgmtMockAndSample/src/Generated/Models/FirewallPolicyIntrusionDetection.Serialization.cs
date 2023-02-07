// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class FirewallPolicyIntrusionDetection : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Mode))
            {
                writer.WritePropertyName("mode"u8);
                writer.WriteStringValue(Mode.Value.ToString());
            }
            if (Optional.IsDefined(Configuration))
            {
                writer.WritePropertyName("configuration"u8);
                writer.WriteObjectValue(Configuration);
            }
            writer.WriteEndObject();
        }

        internal static FirewallPolicyIntrusionDetection DeserializeFirewallPolicyIntrusionDetection(JsonElement element)
        {
            Optional<FirewallPolicyIntrusionDetectionStateType> mode = default;
            Optional<FirewallPolicyIntrusionDetectionConfiguration> configuration = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("mode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    mode = new FirewallPolicyIntrusionDetectionStateType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("configuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    configuration = FirewallPolicyIntrusionDetectionConfiguration.DeserializeFirewallPolicyIntrusionDetectionConfiguration(property.Value);
                    continue;
                }
            }
            return new FirewallPolicyIntrusionDetection(Optional.ToNullable(mode), configuration.Value);
        }
    }
}
