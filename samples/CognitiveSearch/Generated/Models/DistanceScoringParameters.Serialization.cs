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
    public partial class DistanceScoringParameters : IUtf8JsonSerializable, IJsonModel<DistanceScoringParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DistanceScoringParameters>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<DistanceScoringParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("referencePointParameter"u8);
            writer.WriteStringValue(ReferencePointParameter);
            writer.WritePropertyName("boostingDistance"u8);
            writer.WriteNumberValue(BoostingDistance);
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

        DistanceScoringParameters IJsonModel<DistanceScoringParameters>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDistanceScoringParameters(document.RootElement, options);
        }

        internal static DistanceScoringParameters DeserializeDistanceScoringParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string referencePointParameter = default;
            double boostingDistance = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("referencePointParameter"u8))
                {
                    referencePointParameter = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boostingDistance"u8))
                {
                    boostingDistance = property.Value.GetDouble();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DistanceScoringParameters(referencePointParameter, boostingDistance, serializedAdditionalRawData);
        }

        BinaryData IModel<DistanceScoringParameters>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.WriteCore(this, options);
        }

        DistanceScoringParameters IModel<DistanceScoringParameters>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDistanceScoringParameters(document.RootElement, options);
        }
    }
}
