// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateFineTuneRequest : IJsonModel<CreateFineTuneRequest>
    {
        void IJsonModel<CreateFineTuneRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateFineTuneRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateFineTuneRequest)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (!SerializedAdditionalRawData.ContainsKey("training_file"))
            {
                writer.WritePropertyName("training_file"u8);
                writer.WriteStringValue(TrainingFile);
            }
            if (!SerializedAdditionalRawData.ContainsKey("validation_file") && Optional.IsDefined(ValidationFile))
            {
                if (ValidationFile != null)
                {
                    writer.WritePropertyName("validation_file"u8);
                    writer.WriteStringValue(ValidationFile);
                }
                else
                {
                    writer.WriteNull("validation_file");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("model") && Optional.IsDefined(Model))
            {
                if (Model != null)
                {
                    writer.WritePropertyName("model"u8);
                    writer.WriteStringValue(Model.Value.ToString());
                }
                else
                {
                    writer.WriteNull("model");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("n_epochs") && Optional.IsDefined(NEpochs))
            {
                if (NEpochs != null)
                {
                    writer.WritePropertyName("n_epochs"u8);
                    writer.WriteNumberValue(NEpochs.Value);
                }
                else
                {
                    writer.WriteNull("n_epochs");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("batch_size") && Optional.IsDefined(BatchSize))
            {
                if (BatchSize != null)
                {
                    writer.WritePropertyName("batch_size"u8);
                    writer.WriteNumberValue(BatchSize.Value);
                }
                else
                {
                    writer.WriteNull("batch_size");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("learning_rate_multiplier") && Optional.IsDefined(LearningRateMultiplier))
            {
                if (LearningRateMultiplier != null)
                {
                    writer.WritePropertyName("learning_rate_multiplier"u8);
                    writer.WriteNumberValue(LearningRateMultiplier.Value);
                }
                else
                {
                    writer.WriteNull("learning_rate_multiplier");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("prompt_loss_rate") && Optional.IsDefined(PromptLossRate))
            {
                if (PromptLossRate != null)
                {
                    writer.WritePropertyName("prompt_loss_rate"u8);
                    writer.WriteNumberValue(PromptLossRate.Value);
                }
                else
                {
                    writer.WriteNull("prompt_loss_rate");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("compute_classification_metrics") && Optional.IsDefined(ComputeClassificationMetrics))
            {
                if (ComputeClassificationMetrics != null)
                {
                    writer.WritePropertyName("compute_classification_metrics"u8);
                    writer.WriteBooleanValue(ComputeClassificationMetrics.Value);
                }
                else
                {
                    writer.WriteNull("compute_classification_metrics");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("classification_n_classes") && Optional.IsDefined(ClassificationNClasses))
            {
                if (ClassificationNClasses != null)
                {
                    writer.WritePropertyName("classification_n_classes"u8);
                    writer.WriteNumberValue(ClassificationNClasses.Value);
                }
                else
                {
                    writer.WriteNull("classification_n_classes");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("classification_positive_class") && Optional.IsDefined(ClassificationPositiveClass))
            {
                if (ClassificationPositiveClass != null)
                {
                    writer.WritePropertyName("classification_positive_class"u8);
                    writer.WriteStringValue(ClassificationPositiveClass);
                }
                else
                {
                    writer.WriteNull("classification_positive_class");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("classification_betas") && Optional.IsCollectionDefined(ClassificationBetas))
            {
                if (ClassificationBetas != null)
                {
                    writer.WritePropertyName("classification_betas"u8);
                    writer.WriteStartArray();
                    foreach (var item in ClassificationBetas)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("classification_betas");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("suffix") && Optional.IsDefined(Suffix))
            {
                if (Suffix != null)
                {
                    writer.WritePropertyName("suffix"u8);
                    writer.WriteStringValue(Suffix);
                }
                else
                {
                    writer.WriteNull("suffix");
                }
            }
            foreach (var item in SerializedAdditionalRawData)
            {
                if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                {
                    continue;
                }
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
            writer.WriteEndObject();
        }

        CreateFineTuneRequest IJsonModel<CreateFineTuneRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateFineTuneRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateFineTuneRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateFineTuneRequest(document.RootElement, options);
        }

        internal static CreateFineTuneRequest DeserializeCreateFineTuneRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string trainingFile = default;
            string validationFile = default;
            CreateFineTuneRequestModel? model = default;
            long? nEpochs = default;
            long? batchSize = default;
            double? learningRateMultiplier = default;
            double? promptLossRate = default;
            bool? computeClassificationMetrics = default;
            long? classificationNClasses = default;
            string classificationPositiveClass = default;
            IList<double> classificationBetas = default;
            string suffix = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("training_file"u8))
                {
                    trainingFile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("validation_file"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        validationFile = null;
                        continue;
                    }
                    validationFile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        model = null;
                        continue;
                    }
                    model = new CreateFineTuneRequestModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("n_epochs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nEpochs = null;
                        continue;
                    }
                    nEpochs = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("batch_size"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        batchSize = null;
                        continue;
                    }
                    batchSize = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("learning_rate_multiplier"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        learningRateMultiplier = null;
                        continue;
                    }
                    learningRateMultiplier = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("prompt_loss_rate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        promptLossRate = null;
                        continue;
                    }
                    promptLossRate = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("compute_classification_metrics"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        computeClassificationMetrics = null;
                        continue;
                    }
                    computeClassificationMetrics = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("classification_n_classes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        classificationNClasses = null;
                        continue;
                    }
                    classificationNClasses = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("classification_positive_class"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        classificationPositiveClass = null;
                        continue;
                    }
                    classificationPositiveClass = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("classification_betas"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<double> array = new List<double>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetDouble());
                    }
                    classificationBetas = array;
                    continue;
                }
                if (property.NameEquals("suffix"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        suffix = null;
                        continue;
                    }
                    suffix = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CreateFineTuneRequest(
                trainingFile,
                validationFile,
                model,
                nEpochs,
                batchSize,
                learningRateMultiplier,
                promptLossRate,
                computeClassificationMetrics,
                classificationNClasses,
                classificationPositiveClass,
                classificationBetas ?? new ChangeTrackingList<double>(),
                suffix,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateFineTuneRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateFineTuneRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateFineTuneRequest)} does not support writing '{options.Format}' format.");
            }
        }

        CreateFineTuneRequest IPersistableModel<CreateFineTuneRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateFineTuneRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateFineTuneRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateFineTuneRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateFineTuneRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateFineTuneRequest FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateFineTuneRequest(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
