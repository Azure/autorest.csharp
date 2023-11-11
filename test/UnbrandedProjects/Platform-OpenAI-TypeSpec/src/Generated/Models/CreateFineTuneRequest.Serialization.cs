// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateFineTuneRequest : IUtf8JsonWriteable, IJsonModel<CreateFineTuneRequest>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<CreateFineTuneRequest>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<CreateFineTuneRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<CreateFineTuneRequest>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<CreateFineTuneRequest>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("training_file"u8);
            writer.WriteStringValue(TrainingFile);
            if (OptionalProperty.IsDefined(ValidationFile))
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
            if (OptionalProperty.IsDefined(Model))
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model.Value.ToString());
            }
            if (OptionalProperty.IsDefined(NEpochs))
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
            if (OptionalProperty.IsDefined(BatchSize))
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
            if (OptionalProperty.IsDefined(LearningRateMultiplier))
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
            if (OptionalProperty.IsDefined(PromptLossRate))
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
            if (OptionalProperty.IsDefined(ComputeClassificationMetrics))
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
            if (OptionalProperty.IsDefined(ClassificationNClasses))
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
            if (OptionalProperty.IsDefined(ClassificationPositiveClass))
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
            if (OptionalProperty.IsCollectionDefined(ClassificationBetas))
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
            if (OptionalProperty.IsDefined(Suffix))
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

        CreateFineTuneRequest IJsonModel<CreateFineTuneRequest>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateFineTuneRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateFineTuneRequest(document.RootElement, options);
        }

        internal static CreateFineTuneRequest DeserializeCreateFineTuneRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string trainingFile = default;
            OptionalProperty<string> validationFile = default;
            OptionalProperty<CreateFineTuneRequestModel> model = default;
            OptionalProperty<long?> nEpochs = default;
            OptionalProperty<long?> batchSize = default;
            OptionalProperty<double?> learningRateMultiplier = default;
            OptionalProperty<double?> promptLossRate = default;
            OptionalProperty<bool?> computeClassificationMetrics = default;
            OptionalProperty<long?> classificationNClasses = default;
            OptionalProperty<string> classificationPositiveClass = default;
            OptionalProperty<IList<double>> classificationBetas = default;
            OptionalProperty<string> suffix = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CreateFineTuneRequest(trainingFile, validationFile.Value, OptionalProperty.ToNullable(model), OptionalProperty.ToNullable(nEpochs), OptionalProperty.ToNullable(batchSize), OptionalProperty.ToNullable(learningRateMultiplier), OptionalProperty.ToNullable(promptLossRate), OptionalProperty.ToNullable(computeClassificationMetrics), OptionalProperty.ToNullable(classificationNClasses), classificationPositiveClass.Value, OptionalProperty.ToList(classificationBetas), suffix.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<CreateFineTuneRequest>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateFineTuneRequest)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        CreateFineTuneRequest IModel<CreateFineTuneRequest>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateFineTuneRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCreateFineTuneRequest(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<CreateFineTuneRequest>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static CreateFineTuneRequest FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeCreateFineTuneRequest(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual RequestBody ToRequestBody()
        {
            var content = new Utf8JsonRequestBody();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
