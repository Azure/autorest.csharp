// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtMockAndSample.Models
{
    public partial class FirewallPolicyIntrusionDetectionConfiguration : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(SignatureOverrides))
            {
                writer.WritePropertyName("signatureOverrides"u8);
                writer.WriteStartArray();
                foreach (var item in SignatureOverrides)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(BypassTrafficSettings))
            {
                writer.WritePropertyName("bypassTrafficSettings"u8);
                writer.WriteStartArray();
                foreach (var item in BypassTrafficSettings)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyIntrusionDetectionConfiguration(doc.RootElement, options);
        }

        internal static FirewallPolicyIntrusionDetectionConfiguration DeserializeFirewallPolicyIntrusionDetectionConfiguration(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<FirewallPolicyIntrusionDetectionSignatureSpecification>> signatureOverrides = default;
            Optional<IList<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications>> bypassTrafficSettings = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("signatureOverrides"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FirewallPolicyIntrusionDetectionSignatureSpecification> array = new List<FirewallPolicyIntrusionDetectionSignatureSpecification>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FirewallPolicyIntrusionDetectionSignatureSpecification.DeserializeFirewallPolicyIntrusionDetectionSignatureSpecification(item));
                    }
                    signatureOverrides = array;
                    continue;
                }
                if (property.NameEquals("bypassTrafficSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications> array = new List<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FirewallPolicyIntrusionDetectionBypassTrafficSpecifications.DeserializeFirewallPolicyIntrusionDetectionBypassTrafficSpecifications(item));
                    }
                    bypassTrafficSettings = array;
                    continue;
                }
            }
            return new FirewallPolicyIntrusionDetectionConfiguration(Optional.ToList(signatureOverrides), Optional.ToList(bypassTrafficSettings));
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyIntrusionDetectionConfiguration(doc.RootElement, options);
        }
    }
}
