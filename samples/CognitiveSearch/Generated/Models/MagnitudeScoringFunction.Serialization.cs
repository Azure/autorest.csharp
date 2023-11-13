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

namespace CognitiveSearch.Models
{
    public partial class MagnitudeScoringFunction : IUtf8JsonSerializable, IJsonModel<MagnitudeScoringFunction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MagnitudeScoringFunction>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<MagnitudeScoringFunction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<MagnitudeScoringFunction>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<MagnitudeScoringFunction>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("magnitude"u8);
            writer.WriteObjectValue(Parameters);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type);
            writer.WritePropertyName("fieldName"u8);
            writer.WriteStringValue(FieldName);
            writer.WritePropertyName("boost"u8);
            writer.WriteNumberValue(Boost);
            if (Optional.IsDefined(Interpolation))
            {
                writer.WritePropertyName("interpolation"u8);
                writer.WriteStringValue(Interpolation.Value.ToSerialString());
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

        MagnitudeScoringFunction IJsonModel<MagnitudeScoringFunction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(MagnitudeScoringFunction)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMagnitudeScoringFunction(document.RootElement, options);
        }

        internal static MagnitudeScoringFunction DeserializeMagnitudeScoringFunction(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MagnitudeScoringParameters magnitude = default;
            string type = default;
            string fieldName = default;
            double boost = default;
            Optional<ScoringFunctionInterpolation> interpolation = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("magnitude"u8))
                {
                    magnitude = MagnitudeScoringParameters.DeserializeMagnitudeScoringParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fieldName"u8))
                {
                    fieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boost"u8))
                {
                    boost = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("interpolation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    interpolation = property.Value.GetString().ToScoringFunctionInterpolation();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new MagnitudeScoringFunction(type, fieldName, boost, Optional.ToNullable(interpolation), serializedAdditionalRawData, magnitude);
        }

        BinaryData IPersistableModel<MagnitudeScoringFunction>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(MagnitudeScoringFunction)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        MagnitudeScoringFunction IPersistableModel<MagnitudeScoringFunction>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(MagnitudeScoringFunction)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeMagnitudeScoringFunction(document.RootElement, options);
        }

        string IPersistableModel<MagnitudeScoringFunction>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
