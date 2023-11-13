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

namespace Azure.AI.FormRecognizer.Models
{
    public partial class TrainResult : IUtf8JsonSerializable, IJsonModel<TrainResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<TrainResult>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<TrainResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<TrainResult>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<TrainResult>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("trainingDocuments"u8);
            writer.WriteStartArray();
            foreach (var item in TrainingDocuments)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsCollectionDefined(Fields))
            {
                writer.WritePropertyName("fields"u8);
                writer.WriteStartArray();
                foreach (var item in Fields)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(AverageModelAccuracy))
            {
                writer.WritePropertyName("averageModelAccuracy"u8);
                writer.WriteNumberValue(AverageModelAccuracy.Value);
            }
            if (Optional.IsCollectionDefined(Errors))
            {
                writer.WritePropertyName("errors"u8);
                writer.WriteStartArray();
                foreach (var item in Errors)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
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

        TrainResult IJsonModel<TrainResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(TrainResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTrainResult(document.RootElement, options);
        }

        internal static TrainResult DeserializeTrainResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<TrainingDocumentInfo> trainingDocuments = default;
            Optional<IReadOnlyList<FormFieldsReport>> fields = default;
            Optional<float> averageModelAccuracy = default;
            Optional<IReadOnlyList<ErrorInformation>> errors = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("trainingDocuments"u8))
                {
                    List<TrainingDocumentInfo> array = new List<TrainingDocumentInfo>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TrainingDocumentInfo.DeserializeTrainingDocumentInfo(item));
                    }
                    trainingDocuments = array;
                    continue;
                }
                if (property.NameEquals("fields"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FormFieldsReport> array = new List<FormFieldsReport>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FormFieldsReport.DeserializeFormFieldsReport(item));
                    }
                    fields = array;
                    continue;
                }
                if (property.NameEquals("averageModelAccuracy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    averageModelAccuracy = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ErrorInformation> array = new List<ErrorInformation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ErrorInformation.DeserializeErrorInformation(item));
                    }
                    errors = array;
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new TrainResult(trainingDocuments, Optional.ToList(fields), Optional.ToNullable(averageModelAccuracy), Optional.ToList(errors), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<TrainResult>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(TrainResult)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        TrainResult IPersistableModel<TrainResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(TrainResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeTrainResult(document.RootElement, options);
        }

        string IPersistableModel<TrainResult>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
