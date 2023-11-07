// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    [ModelReaderProxy(typeof(UnknownDeliveryRuleCondition))]
    public partial class DeliveryRuleCondition : IUtf8JsonSerializable, IJsonModel<DeliveryRuleCondition>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeliveryRuleCondition>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<DeliveryRuleCondition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Foo))
                {
                    writer.WritePropertyName("foo"u8);
                    writer.WriteStringValue(Foo);
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
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

        DeliveryRuleCondition IJsonModel<DeliveryRuleCondition>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DeliveryRuleCondition)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleCondition(document.RootElement, options);
        }

        internal static DeliveryRuleCondition DeserializeDeliveryRuleCondition(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("name", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "QueryString": return DeliveryRuleQueryStringCondition.DeserializeDeliveryRuleQueryStringCondition(element);
                    case "RemoteAddress": return DeliveryRuleRemoteAddressCondition.DeserializeDeliveryRuleRemoteAddressCondition(element);
                    case "RequestMethod": return DeliveryRuleRequestMethodCondition.DeserializeDeliveryRuleRequestMethodCondition(element);
                }
            }
            return UnknownDeliveryRuleCondition.DeserializeUnknownDeliveryRuleCondition(element);
        }

        BinaryData IModel<DeliveryRuleCondition>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DeliveryRuleCondition)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DeliveryRuleCondition IModel<DeliveryRuleCondition>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DeliveryRuleCondition)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDeliveryRuleCondition(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<DeliveryRuleCondition>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
