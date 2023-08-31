// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Network.Management.Interface.Models
{
    public partial class EffectiveNetworkSecurityRule : IUtf8JsonSerializable, IModelJsonSerializable<EffectiveNetworkSecurityRule>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<EffectiveNetworkSecurityRule>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<EffectiveNetworkSecurityRule>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Protocol))
            {
                writer.WritePropertyName("protocol"u8);
                writer.WriteStringValue(Protocol.Value.ToString());
            }
            if (Optional.IsDefined(SourcePortRange))
            {
                writer.WritePropertyName("sourcePortRange"u8);
                writer.WriteStringValue(SourcePortRange);
            }
            if (Optional.IsDefined(DestinationPortRange))
            {
                writer.WritePropertyName("destinationPortRange"u8);
                writer.WriteStringValue(DestinationPortRange);
            }
            if (Optional.IsCollectionDefined(SourcePortRanges))
            {
                writer.WritePropertyName("sourcePortRanges"u8);
                writer.WriteStartArray();
                foreach (var item in SourcePortRanges)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DestinationPortRanges))
            {
                writer.WritePropertyName("destinationPortRanges"u8);
                writer.WriteStartArray();
                foreach (var item in DestinationPortRanges)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(SourceAddressPrefix))
            {
                writer.WritePropertyName("sourceAddressPrefix"u8);
                writer.WriteStringValue(SourceAddressPrefix);
            }
            if (Optional.IsDefined(DestinationAddressPrefix))
            {
                writer.WritePropertyName("destinationAddressPrefix"u8);
                writer.WriteStringValue(DestinationAddressPrefix);
            }
            if (Optional.IsCollectionDefined(SourceAddressPrefixes))
            {
                writer.WritePropertyName("sourceAddressPrefixes"u8);
                writer.WriteStartArray();
                foreach (var item in SourceAddressPrefixes)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DestinationAddressPrefixes))
            {
                writer.WritePropertyName("destinationAddressPrefixes"u8);
                writer.WriteStartArray();
                foreach (var item in DestinationAddressPrefixes)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ExpandedSourceAddressPrefix))
            {
                writer.WritePropertyName("expandedSourceAddressPrefix"u8);
                writer.WriteStartArray();
                foreach (var item in ExpandedSourceAddressPrefix)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ExpandedDestinationAddressPrefix))
            {
                writer.WritePropertyName("expandedDestinationAddressPrefix"u8);
                writer.WriteStartArray();
                foreach (var item in ExpandedDestinationAddressPrefix)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Access))
            {
                writer.WritePropertyName("access"u8);
                writer.WriteStringValue(Access.Value.ToString());
            }
            if (Optional.IsDefined(Priority))
            {
                writer.WritePropertyName("priority"u8);
                writer.WriteNumberValue(Priority.Value);
            }
            if (Optional.IsDefined(Direction))
            {
                writer.WritePropertyName("direction"u8);
                writer.WriteStringValue(Direction.Value.ToString());
            }
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static EffectiveNetworkSecurityRule DeserializeEffectiveNetworkSecurityRule(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<EffectiveSecurityRuleProtocol> protocol = default;
            Optional<string> sourcePortRange = default;
            Optional<string> destinationPortRange = default;
            Optional<IReadOnlyList<string>> sourcePortRanges = default;
            Optional<IReadOnlyList<string>> destinationPortRanges = default;
            Optional<string> sourceAddressPrefix = default;
            Optional<string> destinationAddressPrefix = default;
            Optional<IReadOnlyList<string>> sourceAddressPrefixes = default;
            Optional<IReadOnlyList<string>> destinationAddressPrefixes = default;
            Optional<IReadOnlyList<string>> expandedSourceAddressPrefix = default;
            Optional<IReadOnlyList<string>> expandedDestinationAddressPrefix = default;
            Optional<SecurityRuleAccess> access = default;
            Optional<int> priority = default;
            Optional<SecurityRuleDirection> direction = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("protocol"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protocol = new EffectiveSecurityRuleProtocol(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourcePortRange"u8))
                {
                    sourcePortRange = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destinationPortRange"u8))
                {
                    destinationPortRange = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourcePortRanges"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    sourcePortRanges = array;
                    continue;
                }
                if (property.NameEquals("destinationPortRanges"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    destinationPortRanges = array;
                    continue;
                }
                if (property.NameEquals("sourceAddressPrefix"u8))
                {
                    sourceAddressPrefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destinationAddressPrefix"u8))
                {
                    destinationAddressPrefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourceAddressPrefixes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    sourceAddressPrefixes = array;
                    continue;
                }
                if (property.NameEquals("destinationAddressPrefixes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    destinationAddressPrefixes = array;
                    continue;
                }
                if (property.NameEquals("expandedSourceAddressPrefix"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    expandedSourceAddressPrefix = array;
                    continue;
                }
                if (property.NameEquals("expandedDestinationAddressPrefix"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    expandedDestinationAddressPrefix = array;
                    continue;
                }
                if (property.NameEquals("access"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    access = new SecurityRuleAccess(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("priority"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    priority = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("direction"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    direction = new SecurityRuleDirection(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new EffectiveNetworkSecurityRule(name.Value, Optional.ToNullable(protocol), sourcePortRange.Value, destinationPortRange.Value, Optional.ToList(sourcePortRanges), Optional.ToList(destinationPortRanges), sourceAddressPrefix.Value, destinationAddressPrefix.Value, Optional.ToList(sourceAddressPrefixes), Optional.ToList(destinationAddressPrefixes), Optional.ToList(expandedSourceAddressPrefix), Optional.ToList(expandedDestinationAddressPrefix), Optional.ToNullable(access), Optional.ToNullable(priority), Optional.ToNullable(direction), rawData);
        }

        EffectiveNetworkSecurityRule IModelJsonSerializable<EffectiveNetworkSecurityRule>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeEffectiveNetworkSecurityRule(doc.RootElement, options);
        }

        BinaryData IModelSerializable<EffectiveNetworkSecurityRule>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        EffectiveNetworkSecurityRule IModelSerializable<EffectiveNetworkSecurityRule>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeEffectiveNetworkSecurityRule(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="EffectiveNetworkSecurityRule"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="EffectiveNetworkSecurityRule"/> to convert. </param>
        public static implicit operator RequestContent(EffectiveNetworkSecurityRule model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="EffectiveNetworkSecurityRule"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator EffectiveNetworkSecurityRule(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeEffectiveNetworkSecurityRule(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
