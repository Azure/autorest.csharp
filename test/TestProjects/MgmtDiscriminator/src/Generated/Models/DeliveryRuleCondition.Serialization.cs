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
    [PersistableModelProxy(typeof(UnknownDeliveryRuleCondition))]
    public partial class DeliveryRuleCondition : IUtf8JsonSerializable, IJsonModel<DeliveryRuleCondition>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeliveryRuleCondition>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DeliveryRuleCondition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleCondition>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryRuleCondition)} does not support writing '{format}' format.");
            }

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
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        DeliveryRuleCondition IJsonModel<DeliveryRuleCondition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleCondition>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryRuleCondition)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleCondition(document.RootElement, options);
        }

        internal static DeliveryRuleCondition DeserializeDeliveryRuleCondition(JsonElement element, ModelReaderWriterOptions options = null)
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
                    case "QueryString": return DeliveryRuleQueryStringCondition.DeserializeDeliveryRuleQueryStringCondition(element, options);
                    case "RemoteAddress": return DeliveryRuleRemoteAddressCondition.DeserializeDeliveryRuleRemoteAddressCondition(element, options);
                    case "RequestMethod": return DeliveryRuleRequestMethodCondition.DeserializeDeliveryRuleRequestMethodCondition(element, options);
                }
            }
            return UnknownDeliveryRuleCondition.DeserializeUnknownDeliveryRuleCondition(element, options);
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

        BinaryData IPersistableModel<DeliveryRuleCondition>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleCondition>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, MgmtDiscriminatorContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(DeliveryRuleCondition)} does not support writing '{options.Format}' format.");
            }
        }

        DeliveryRuleCondition IPersistableModel<DeliveryRuleCondition>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeliveryRuleCondition>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeDeliveryRuleCondition(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DeliveryRuleCondition)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeliveryRuleCondition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
