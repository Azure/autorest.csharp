// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtDiscriminator.Models
{
    public partial class DeliveryRuleAction : IUtf8JsonSerializable, IJsonModel<DeliveryRuleAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeliveryRuleAction>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DeliveryRuleAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryRuleAction)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            if (options.Format != "W" && Optional.IsDefined(Foo))
            {
                writer.WritePropertyName("foo"u8);
                writer.WriteStringValue(Foo);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        DeliveryRuleAction IJsonModel<DeliveryRuleAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryRuleAction)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleAction(document.RootElement, options);
        }

        internal static DeliveryRuleAction DeserializeDeliveryRuleAction(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("name", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "UrlRedirect": return UrlRedirectAction.DeserializeUrlRedirectAction(element, options);
                    case "UrlSigning": return UrlSigningAction.DeserializeUrlSigningAction(element, options);
                    case "OriginGroupOverride": return OriginGroupOverrideAction.DeserializeOriginGroupOverrideAction(element, options);
                    case "UrlRewrite": return UrlRewriteAction.DeserializeUrlRewriteAction(element, options);
                    case "ModifyRequestHeader": return DeliveryRuleRequestHeaderAction.DeserializeDeliveryRuleRequestHeaderAction(element, options);
                    case "ModifyResponseHeader": return DeliveryRuleResponseHeaderAction.DeserializeDeliveryRuleResponseHeaderAction(element, options);
                    case "CacheExpiration": return DeliveryRuleCacheExpirationAction.DeserializeDeliveryRuleCacheExpirationAction(element, options);
                    case "CacheKeyQueryString": return DeliveryRuleCacheKeyQueryStringAction.DeserializeDeliveryRuleCacheKeyQueryStringAction(element, options);
                    case "RouteConfigurationOverride": return DeliveryRuleRouteConfigurationOverrideAction.DeserializeDeliveryRuleRouteConfigurationOverrideAction(element, options);
                }
            }
            return UnknownDeliveryRuleAction.DeserializeUnknownDeliveryRuleAction(element, options);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Name), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  name: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                builder.Append("  name: ");
                builder.AppendLine($"'{Name.ToString()}'");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Foo), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  foo: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Foo))
                {
                    builder.Append("  foo: ");
                    if (Foo.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Foo}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Foo}'");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<DeliveryRuleAction>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleAction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(DeliveryRuleAction)} does not support writing '{options.Format}' format.");
            }
        }

        DeliveryRuleAction IPersistableModel<DeliveryRuleAction>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleAction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDeliveryRuleAction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DeliveryRuleAction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeliveryRuleAction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
