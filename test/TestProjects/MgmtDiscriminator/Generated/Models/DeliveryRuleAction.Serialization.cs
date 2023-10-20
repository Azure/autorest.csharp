// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    public partial class DeliveryRuleAction : IUtf8JsonSerializable, IModelJsonSerializable<DeliveryRuleAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DeliveryRuleAction>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DeliveryRuleAction>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
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

        DeliveryRuleAction IModelJsonSerializable<DeliveryRuleAction>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleAction(document.RootElement, options);
        }

        BinaryData IModelSerializable<DeliveryRuleAction>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        DeliveryRuleAction IModelSerializable<DeliveryRuleAction>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDeliveryRuleAction(document.RootElement, options);
        }

        internal static DeliveryRuleAction DeserializeDeliveryRuleAction(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("name", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "CacheExpiration": return DeliveryRuleCacheExpirationAction.DeserializeDeliveryRuleCacheExpirationAction(element);
                    case "CacheKeyQueryString": return DeliveryRuleCacheKeyQueryStringAction.DeserializeDeliveryRuleCacheKeyQueryStringAction(element);
                    case "ModifyRequestHeader": return DeliveryRuleRequestHeaderAction.DeserializeDeliveryRuleRequestHeaderAction(element);
                    case "ModifyResponseHeader": return DeliveryRuleResponseHeaderAction.DeserializeDeliveryRuleResponseHeaderAction(element);
                    case "OriginGroupOverride": return OriginGroupOverrideAction.DeserializeOriginGroupOverrideAction(element);
                    case "RouteConfigurationOverride": return DeliveryRuleRouteConfigurationOverrideAction.DeserializeDeliveryRuleRouteConfigurationOverrideAction(element);
                    case "UrlRedirect": return UrlRedirectAction.DeserializeUrlRedirectAction(element);
                    case "UrlRewrite": return UrlRewriteAction.DeserializeUrlRewriteAction(element);
                    case "UrlSigning": return UrlSigningAction.DeserializeUrlSigningAction(element);
                }
            }
            return UnknownDeliveryRuleAction.DeserializeUnknownDeliveryRuleAction(element);
        }
    }
}
