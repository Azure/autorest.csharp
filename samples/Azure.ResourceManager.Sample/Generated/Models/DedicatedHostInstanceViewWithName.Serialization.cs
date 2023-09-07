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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class DedicatedHostInstanceViewWithName : IUtf8JsonSerializable, IModelJsonSerializable<DedicatedHostInstanceViewWithName>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DedicatedHostInstanceViewWithName>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DedicatedHostInstanceViewWithName>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DedicatedHostInstanceViewWithName>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(AvailableCapacity))
            {
                writer.WritePropertyName("availableCapacity"u8);
                if (AvailableCapacity is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<DedicatedHostAvailableCapacity>)AvailableCapacity).Serialize(writer, options);
                }
            }
            if (Optional.IsCollectionDefined(Statuses))
            {
                writer.WritePropertyName("statuses"u8);
                writer.WriteStartArray();
                foreach (var item in Statuses)
                {
                    if (item is null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        ((IModelJsonSerializable<InstanceViewStatus>)item).Serialize(writer, options);
                    }
                }
                writer.WriteEndArray();
            }
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static DedicatedHostInstanceViewWithName DeserializeDedicatedHostInstanceViewWithName(JsonElement element, ModelSerializerOptions options = default)
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
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
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
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DedicatedHostInstanceViewWithName(assetId.Value, availableCapacity.Value, Optional.ToList(statuses), name.Value, serializedAdditionalRawData);
        }

        DedicatedHostInstanceViewWithName IModelJsonSerializable<DedicatedHostInstanceViewWithName>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DedicatedHostInstanceViewWithName>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDedicatedHostInstanceViewWithName(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DedicatedHostInstanceViewWithName>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DedicatedHostInstanceViewWithName>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DedicatedHostInstanceViewWithName IModelSerializable<DedicatedHostInstanceViewWithName>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DedicatedHostInstanceViewWithName>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDedicatedHostInstanceViewWithName(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="DedicatedHostInstanceViewWithName"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="DedicatedHostInstanceViewWithName"/> to convert. </param>
        public static implicit operator RequestContent(DedicatedHostInstanceViewWithName model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="DedicatedHostInstanceViewWithName"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator DedicatedHostInstanceViewWithName(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDedicatedHostInstanceViewWithName(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
