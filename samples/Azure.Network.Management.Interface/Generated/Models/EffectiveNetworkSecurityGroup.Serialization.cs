// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class EffectiveNetworkSecurityGroup : IUtf8JsonSerializable, IJsonModel<EffectiveNetworkSecurityGroup>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<EffectiveNetworkSecurityGroup>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<EffectiveNetworkSecurityGroup>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(NetworkSecurityGroup))
            {
                writer.WritePropertyName("networkSecurityGroup"u8);
                writer.WriteObjectValue(NetworkSecurityGroup);
            }
            if (Optional.IsDefined(Association))
            {
                writer.WritePropertyName("association"u8);
                writer.WriteObjectValue(Association);
            }
            if (Optional.IsCollectionDefined(EffectiveSecurityRules))
            {
                writer.WritePropertyName("effectiveSecurityRules"u8);
                writer.WriteStartArray();
                foreach (var item in EffectiveSecurityRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(TagMap))
            {
                writer.WritePropertyName("tagMap"u8);
                writer.WriteStringValue(TagMap);
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        EffectiveNetworkSecurityGroup IJsonModel<EffectiveNetworkSecurityGroup>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(EffectiveNetworkSecurityGroup)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEffectiveNetworkSecurityGroup(document.RootElement, options);
        }

        internal static EffectiveNetworkSecurityGroup DeserializeEffectiveNetworkSecurityGroup(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<SubResource> networkSecurityGroup = default;
            Optional<EffectiveNetworkSecurityGroupAssociation> association = default;
            Optional<IReadOnlyList<EffectiveNetworkSecurityRule>> effectiveSecurityRules = default;
            Optional<string> tagMap = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("networkSecurityGroup"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    networkSecurityGroup = SubResource.DeserializeSubResource(property.Value);
                    continue;
                }
                if (property.NameEquals("association"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    association = EffectiveNetworkSecurityGroupAssociation.DeserializeEffectiveNetworkSecurityGroupAssociation(property.Value);
                    continue;
                }
                if (property.NameEquals("effectiveSecurityRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<EffectiveNetworkSecurityRule> array = new List<EffectiveNetworkSecurityRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(EffectiveNetworkSecurityRule.DeserializeEffectiveNetworkSecurityRule(item));
                    }
                    effectiveSecurityRules = array;
                    continue;
                }
                if (property.NameEquals("tagMap"u8))
                {
                    tagMap = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new EffectiveNetworkSecurityGroup(networkSecurityGroup.Value, association.Value, Optional.ToList(effectiveSecurityRules), tagMap.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<EffectiveNetworkSecurityGroup>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(EffectiveNetworkSecurityGroup)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        EffectiveNetworkSecurityGroup IModel<EffectiveNetworkSecurityGroup>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(EffectiveNetworkSecurityGroup)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeEffectiveNetworkSecurityGroup(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<EffectiveNetworkSecurityGroup>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
