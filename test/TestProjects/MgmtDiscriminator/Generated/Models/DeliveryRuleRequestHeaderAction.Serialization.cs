// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    public partial class DeliveryRuleRequestHeaderAction : IUtf8JsonSerializable, IModelJsonSerializable<DeliveryRuleRequestHeaderAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DeliveryRuleRequestHeaderAction>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DeliveryRuleRequestHeaderAction>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("parameters"u8);
            writer.WriteObjectValue(Parameters);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Foo))
            {
                writer.WritePropertyName("foo"u8);
                writer.WriteStringValue(Foo);
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

        DeliveryRuleRequestHeaderAction IModelJsonSerializable<DeliveryRuleRequestHeaderAction>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleRequestHeaderAction(document.RootElement, options);
        }

        internal static DeliveryRuleRequestHeaderAction DeserializeDeliveryRuleRequestHeaderAction(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            HeaderActionParameters parameters = default;
            DeliveryRuleActionType name = default;
            Optional<string> foo = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parameters"u8))
                {
                    parameters = HeaderActionParameters.DeserializeHeaderActionParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = new DeliveryRuleActionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("foo"u8))
                {
                    foo = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DeliveryRuleRequestHeaderAction(name, foo.Value, serializedAdditionalRawData, parameters);
        }

        BinaryData IModelSerializable<DeliveryRuleRequestHeaderAction>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DeliveryRuleRequestHeaderAction IModelSerializable<DeliveryRuleRequestHeaderAction>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDeliveryRuleRequestHeaderAction(document.RootElement, options);
        }
    }
}
