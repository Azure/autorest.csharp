// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class DedicatedHostInstanceViewWithName : IUtf8JsonSerializable, IModelJsonSerializable<DedicatedHostInstanceViewWithName>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DedicatedHostInstanceViewWithName>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DedicatedHostInstanceViewWithName>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(AssetId))
            {
                writer.WritePropertyName("assetId"u8);
                writer.WriteStringValue(AssetId);
            }
            if (Optional.IsDefined(AvailableCapacity))
            {
                writer.WritePropertyName("availableCapacity"u8);
                writer.WriteObjectValue(AvailableCapacity);
            }
            if (Optional.IsCollectionDefined(Statuses))
            {
                writer.WritePropertyName("statuses"u8);
                writer.WriteStartArray();
                foreach (var item in Statuses)
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

        DedicatedHostInstanceViewWithName IModelJsonSerializable<DedicatedHostInstanceViewWithName>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDedicatedHostInstanceViewWithName(document.RootElement, options);
        }

        internal static DedicatedHostInstanceViewWithName DeserializeDedicatedHostInstanceViewWithName(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> assetId = default;
            Optional<DedicatedHostAvailableCapacity> availableCapacity = default;
            Optional<IReadOnlyList<InstanceViewStatus>> statuses = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("assetId"u8))
                {
                    assetId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("availableCapacity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    availableCapacity = DedicatedHostAvailableCapacity.DeserializeDedicatedHostAvailableCapacity(property.Value);
                    continue;
                }
                if (property.NameEquals("statuses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InstanceViewStatus> array = new List<InstanceViewStatus>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InstanceViewStatus.DeserializeInstanceViewStatus(item));
                    }
                    statuses = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DedicatedHostInstanceViewWithName(assetId.Value, availableCapacity.Value, Optional.ToList(statuses), serializedAdditionalRawData, name.Value);
        }

        BinaryData IModelSerializable<DedicatedHostInstanceViewWithName>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DedicatedHostInstanceViewWithName IModelSerializable<DedicatedHostInstanceViewWithName>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDedicatedHostInstanceViewWithName(document.RootElement, options);
        }
    }
}
