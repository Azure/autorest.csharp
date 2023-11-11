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
    public partial class MagnitudeScoringParameters : IUtf8JsonSerializable, IJsonModel<MagnitudeScoringParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MagnitudeScoringParameters>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<MagnitudeScoringParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<MagnitudeScoringParameters>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<MagnitudeScoringParameters>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("boostingRangeStart"u8);
            writer.WriteNumberValue(BoostingRangeStart);
            writer.WritePropertyName("boostingRangeEnd"u8);
            writer.WriteNumberValue(BoostingRangeEnd);
            if (Optional.IsDefined(ShouldBoostBeyondRangeByConstant))
            {
                writer.WritePropertyName("constantBoostBeyondRange"u8);
                writer.WriteBooleanValue(ShouldBoostBeyondRangeByConstant.Value);
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

        MagnitudeScoringParameters IJsonModel<MagnitudeScoringParameters>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(MagnitudeScoringParameters)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMagnitudeScoringParameters(document.RootElement, options);
        }

        internal static MagnitudeScoringParameters DeserializeMagnitudeScoringParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            double boostingRangeStart = default;
            double boostingRangeEnd = default;
            Optional<bool> constantBoostBeyondRange = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("boostingRangeStart"u8))
                {
                    boostingRangeStart = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("boostingRangeEnd"u8))
                {
                    boostingRangeEnd = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("constantBoostBeyondRange"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    constantBoostBeyondRange = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new MagnitudeScoringParameters(boostingRangeStart, boostingRangeEnd, Optional.ToNullable(constantBoostBeyondRange), serializedAdditionalRawData);
        }

        BinaryData IModel<MagnitudeScoringParameters>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(MagnitudeScoringParameters)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        MagnitudeScoringParameters IModel<MagnitudeScoringParameters>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(MagnitudeScoringParameters)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeMagnitudeScoringParameters(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<MagnitudeScoringParameters>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
