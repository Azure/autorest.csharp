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
    public partial class FirewallPolicyIntrusionDetectionConfiguration : IUtf8JsonSerializable, IModelJsonSerializable<FirewallPolicyIntrusionDetectionConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FirewallPolicyIntrusionDetectionConfiguration>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FirewallPolicyIntrusionDetectionConfiguration>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        FirewallPolicyIntrusionDetectionConfiguration IModelJsonSerializable<FirewallPolicyIntrusionDetectionConfiguration>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyIntrusionDetectionConfiguration(document.RootElement, options);
        }

        BinaryData IModelSerializable<FirewallPolicyIntrusionDetectionConfiguration>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        FirewallPolicyIntrusionDetectionConfiguration IModelSerializable<FirewallPolicyIntrusionDetectionConfiguration>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyIntrusionDetectionConfiguration(document.RootElement, options);
        }

        internal static FirewallPolicyIntrusionDetectionConfiguration DeserializeFirewallPolicyIntrusionDetectionConfiguration(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<FirewallPolicyIntrusionDetectionSignatureSpecification>> signatureOverrides = default;
            Optional<IList<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications>> bypassTrafficSettings = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new FirewallPolicyIntrusionDetectionConfiguration(Optional.ToList(signatureOverrides), Optional.ToList(bypassTrafficSettings), serializedAdditionalRawData);
        }
    }
}
