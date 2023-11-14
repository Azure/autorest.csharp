// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class UrlSigningAction : IUtf8JsonSerializable, IJsonModel<UrlSigningAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<UrlSigningAction>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<UrlSigningAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<UrlSigningAction>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<UrlSigningAction>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("parameters"u8);
            writer.WriteObjectValue(Parameters);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Foo))
                {
                    writer.WritePropertyName("foo"u8);
                    writer.WriteStringValue(Foo);
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        UrlSigningAction IJsonModel<UrlSigningAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(UrlSigningAction)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUrlSigningAction(document.RootElement, options);
        }

        internal static UrlSigningAction DeserializeUrlSigningAction(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            UrlSigningActionParameters parameters = default;
            DeliveryRuleActionType name = default;
            Optional<string> foo = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parameters"u8))
                {
                    parameters = UrlSigningActionParameters.DeserializeUrlSigningActionParameters(property.Value);
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
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UrlSigningAction(name, foo.Value, serializedAdditionalRawData, parameters);
        }

        BinaryData IPersistableModel<UrlSigningAction>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(UrlSigningAction)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        UrlSigningAction IPersistableModel<UrlSigningAction>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(UrlSigningAction)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeUrlSigningAction(document.RootElement, options);
        }

        string IPersistableModel<UrlSigningAction>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
