// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    public partial class TerminateNotificationProfile : IUtf8JsonSerializable, IJsonModel<TerminateNotificationProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<TerminateNotificationProfile>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<TerminateNotificationProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<TerminateNotificationProfile>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<TerminateNotificationProfile>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(NotBeforeTimeout))
            {
                writer.WritePropertyName("notBeforeTimeout"u8);
                writer.WriteStringValue(NotBeforeTimeout);
            }
            if (Optional.IsDefined(Enable))
            {
                writer.WritePropertyName("enable"u8);
                writer.WriteBooleanValue(Enable.Value);
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

        TerminateNotificationProfile IJsonModel<TerminateNotificationProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(TerminateNotificationProfile)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTerminateNotificationProfile(document.RootElement, options);
        }

        internal static TerminateNotificationProfile DeserializeTerminateNotificationProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> notBeforeTimeout = default;
            Optional<bool> enable = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("notBeforeTimeout"u8))
                {
                    notBeforeTimeout = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("enable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enable = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new TerminateNotificationProfile(notBeforeTimeout.Value, Optional.ToNullable(enable), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<TerminateNotificationProfile>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(TerminateNotificationProfile)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        TerminateNotificationProfile IPersistableModel<TerminateNotificationProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(TerminateNotificationProfile)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeTerminateNotificationProfile(document.RootElement, options);
        }

        string IPersistableModel<TerminateNotificationProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
