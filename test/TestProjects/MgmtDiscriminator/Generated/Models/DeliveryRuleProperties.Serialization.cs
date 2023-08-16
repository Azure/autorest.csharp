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

namespace MgmtDiscriminator.Models
{
    public partial class DeliveryRuleProperties : IUtf8JsonSerializable, IModelJsonSerializable<DeliveryRuleProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DeliveryRuleProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DeliveryRuleProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Order))
            {
                writer.WritePropertyName("order"u8);
                writer.WriteNumberValue(Order.Value);
            }
            if (Optional.IsDefined(Conditions))
            {
                writer.WritePropertyName("conditions"u8);
                writer.WriteObjectValue(Conditions);
            }
            if (Optional.IsCollectionDefined(Actions))
            {
                writer.WritePropertyName("actions"u8);
                writer.WriteStartArray();
                foreach (var item in Actions)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ExtraMappingInfo))
            {
                writer.WritePropertyName("extraMappingInfo"u8);
                writer.WriteStartObject();
                foreach (var item in ExtraMappingInfo)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Pet))
            {
                writer.WritePropertyName("pet"u8);
                writer.WriteObjectValue(Pet);
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

        internal static DeliveryRuleProperties DeserializeDeliveryRuleProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> order = default;
            Optional<DeliveryRuleCondition> conditions = default;
            Optional<IList<DeliveryRuleAction>> actions = default;
            Optional<IDictionary<string, DeliveryRuleAction>> extraMappingInfo = default;
            Optional<Pet> pet = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("order"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    order = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("conditions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    conditions = DeliveryRuleCondition.DeserializeDeliveryRuleCondition(property.Value);
                    continue;
                }
                if (property.NameEquals("actions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DeliveryRuleAction> array = new List<DeliveryRuleAction>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeliveryRuleAction.DeserializeDeliveryRuleAction(item));
                    }
                    actions = array;
                    continue;
                }
                if (property.NameEquals("extraMappingInfo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, DeliveryRuleAction> dictionary = new Dictionary<string, DeliveryRuleAction>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, DeliveryRuleAction.DeserializeDeliveryRuleAction(property0.Value));
                    }
                    extraMappingInfo = dictionary;
                    continue;
                }
                if (property.NameEquals("pet"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    pet = Pet.DeserializePet(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DeliveryRuleProperties(Optional.ToNullable(order), conditions.Value, Optional.ToList(actions), Optional.ToDictionary(extraMappingInfo), pet.Value, rawData);
        }

        DeliveryRuleProperties IModelJsonSerializable<DeliveryRuleProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DeliveryRuleProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DeliveryRuleProperties IModelSerializable<DeliveryRuleProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDeliveryRuleProperties(doc.RootElement, options);
        }

        public static implicit operator RequestContent(DeliveryRuleProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator DeliveryRuleProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDeliveryRuleProperties(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
