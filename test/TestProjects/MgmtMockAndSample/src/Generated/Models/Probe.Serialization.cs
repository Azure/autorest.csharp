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

namespace MgmtMockAndSample.Models
{
    public partial class Probe : IUtf8JsonSerializable, IJsonModel<Probe>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Probe>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<Probe>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<Probe>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<Probe>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("disableProbe"u8);
            writer.WriteBooleanValue(DisableProbe);
            if (Optional.IsDefined(InitialDelaySeconds))
            {
                writer.WritePropertyName("initialDelaySeconds"u8);
                writer.WriteNumberValue(InitialDelaySeconds.Value);
            }
            if (Optional.IsDefined(PeriodSeconds))
            {
                writer.WritePropertyName("periodSeconds"u8);
                writer.WriteNumberValue(PeriodSeconds.Value);
            }
            if (Optional.IsDefined(TimeoutSeconds))
            {
                writer.WritePropertyName("timeoutSeconds"u8);
                writer.WriteNumberValue(TimeoutSeconds.Value);
            }
            if (Optional.IsDefined(FailureThreshold))
            {
                writer.WritePropertyName("failureThreshold"u8);
                writer.WriteNumberValue(FailureThreshold.Value);
            }
            if (Optional.IsDefined(SuccessThreshold))
            {
                writer.WritePropertyName("successThreshold"u8);
                writer.WriteNumberValue(SuccessThreshold.Value);
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

        Probe IJsonModel<Probe>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Probe)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeProbe(document.RootElement, options);
        }

        internal static Probe DeserializeProbe(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool disableProbe = default;
            Optional<int> initialDelaySeconds = default;
            Optional<int> periodSeconds = default;
            Optional<int> timeoutSeconds = default;
            Optional<int> failureThreshold = default;
            Optional<int> successThreshold = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("disableProbe"u8))
                {
                    disableProbe = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("initialDelaySeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    initialDelaySeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("periodSeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    periodSeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("timeoutSeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    timeoutSeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failureThreshold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failureThreshold = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("successThreshold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    successThreshold = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Probe(disableProbe, Optional.ToNullable(initialDelaySeconds), Optional.ToNullable(periodSeconds), Optional.ToNullable(timeoutSeconds), Optional.ToNullable(failureThreshold), Optional.ToNullable(successThreshold), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<Probe>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Probe)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        Probe IPersistableModel<Probe>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Probe)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeProbe(document.RootElement, options);
        }

        string IPersistableModel<Probe>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
