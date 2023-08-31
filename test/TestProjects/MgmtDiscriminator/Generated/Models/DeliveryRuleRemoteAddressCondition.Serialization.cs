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
    public partial class DeliveryRuleRemoteAddressCondition : IUtf8JsonSerializable, IModelJsonSerializable<DeliveryRuleRemoteAddressCondition>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DeliveryRuleRemoteAddressCondition>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DeliveryRuleRemoteAddressCondition>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeliveryRuleRemoteAddressCondition>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("parameters"u8);
            ((IModelJsonSerializable<RemoteAddressMatchConditionParameters>)Parameters).Serialize(writer, options);
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

        internal static DeliveryRuleRemoteAddressCondition DeserializeDeliveryRuleRemoteAddressCondition(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            RemoteAddressMatchConditionParameters parameters = default;
            MatchVariable name = default;
            Optional<string> foo = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parameters"u8))
                {
                    parameters = RemoteAddressMatchConditionParameters.DeserializeRemoteAddressMatchConditionParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = new MatchVariable(property.Value.GetString());
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
            return new DeliveryRuleRemoteAddressCondition(name, foo.Value, parameters, rawData);
        }

        DeliveryRuleRemoteAddressCondition IModelJsonSerializable<DeliveryRuleRemoteAddressCondition>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeliveryRuleRemoteAddressCondition>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleRemoteAddressCondition(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DeliveryRuleRemoteAddressCondition>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeliveryRuleRemoteAddressCondition>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DeliveryRuleRemoteAddressCondition IModelSerializable<DeliveryRuleRemoteAddressCondition>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeliveryRuleRemoteAddressCondition>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDeliveryRuleRemoteAddressCondition(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="DeliveryRuleRemoteAddressCondition"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="DeliveryRuleRemoteAddressCondition"/> to convert. </param>
        public static implicit operator RequestContent(DeliveryRuleRemoteAddressCondition model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="DeliveryRuleRemoteAddressCondition"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator DeliveryRuleRemoteAddressCondition(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDeliveryRuleRemoteAddressCondition(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
