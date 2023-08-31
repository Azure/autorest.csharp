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
    public partial class DeliveryRuleResponseHeaderAction : IUtf8JsonSerializable, IModelJsonSerializable<DeliveryRuleResponseHeaderAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DeliveryRuleResponseHeaderAction>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DeliveryRuleResponseHeaderAction>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeliveryRuleResponseHeaderAction>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("parameters"u8);
            ((IModelJsonSerializable<HeaderActionParameters>)Parameters).Serialize(writer, options);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
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

        internal static DeliveryRuleResponseHeaderAction DeserializeDeliveryRuleResponseHeaderAction(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            HeaderActionParameters parameters = default;
            DeliveryRuleActionType name = default;
            Optional<string> foo = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
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
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DeliveryRuleResponseHeaderAction(name, foo.Value, parameters, rawData);
        }

        DeliveryRuleResponseHeaderAction IModelJsonSerializable<DeliveryRuleResponseHeaderAction>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeliveryRuleResponseHeaderAction>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleResponseHeaderAction(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DeliveryRuleResponseHeaderAction>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeliveryRuleResponseHeaderAction>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DeliveryRuleResponseHeaderAction IModelSerializable<DeliveryRuleResponseHeaderAction>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeliveryRuleResponseHeaderAction>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDeliveryRuleResponseHeaderAction(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="DeliveryRuleResponseHeaderAction"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="DeliveryRuleResponseHeaderAction"/> to convert. </param>
        public static implicit operator RequestContent(DeliveryRuleResponseHeaderAction model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="DeliveryRuleResponseHeaderAction"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator DeliveryRuleResponseHeaderAction(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDeliveryRuleResponseHeaderAction(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
