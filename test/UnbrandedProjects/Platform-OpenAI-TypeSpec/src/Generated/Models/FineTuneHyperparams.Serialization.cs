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
    public partial class FineTuneHyperparams : IUtf8JsonWriteable, IJsonModel<FineTuneHyperparams>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<FineTuneHyperparams>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<FineTuneHyperparams>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<FineTuneHyperparams>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<FineTuneHyperparams>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("n_epochs"u8);
            writer.WriteNumberValue(NEpochs);
            writer.WritePropertyName("batch_size"u8);
            writer.WriteNumberValue(BatchSize);
            writer.WritePropertyName("prompt_loss_weight"u8);
            writer.WriteNumberValue(PromptLossWeight);
            writer.WritePropertyName("learning_rate_multiplier"u8);
            writer.WriteNumberValue(LearningRateMultiplier);
            if (OptionalProperty.IsDefined(ComputeClassificationMetrics))
            {
                writer.WritePropertyName("compute_classification_metrics"u8);
                writer.WriteBooleanValue(ComputeClassificationMetrics.Value);
            }
            if (OptionalProperty.IsDefined(ClassificationPositiveClass))
            {
                writer.WritePropertyName("classification_positive_class"u8);
                writer.WriteStringValue(ClassificationPositiveClass);
            }
            if (OptionalProperty.IsDefined(ClassificationNClasses))
            {
                writer.WritePropertyName("classification_n_classes"u8);
                writer.WriteNumberValue(ClassificationNClasses.Value);
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

        FineTuneHyperparams IJsonModel<FineTuneHyperparams>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FineTuneHyperparams)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTuneHyperparams(document.RootElement, options);
        }

        internal static FineTuneHyperparams DeserializeFineTuneHyperparams(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            long nEpochs = default;
            long batchSize = default;
            double promptLossWeight = default;
            double learningRateMultiplier = default;
            OptionalProperty<bool> computeClassificationMetrics = default;
            OptionalProperty<string> classificationPositiveClass = default;
            OptionalProperty<long> classificationNClasses = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("n_epochs"u8))
                {
                    nEpochs = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("batch_size"u8))
                {
                    batchSize = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("prompt_loss_weight"u8))
                {
                    promptLossWeight = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("learning_rate_multiplier"u8))
                {
                    learningRateMultiplier = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("compute_classification_metrics"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    computeClassificationMetrics = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("classification_positive_class"u8))
                {
                    classificationPositiveClass = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("classification_n_classes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    classificationNClasses = property.Value.GetInt64();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new FineTuneHyperparams(nEpochs, batchSize, promptLossWeight, learningRateMultiplier, OptionalProperty.ToNullable(computeClassificationMetrics), classificationPositiveClass.Value, OptionalProperty.ToNullable(classificationNClasses), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FineTuneHyperparams>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FineTuneHyperparams)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        FineTuneHyperparams IPersistableModel<FineTuneHyperparams>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FineTuneHyperparams)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFineTuneHyperparams(document.RootElement, options);
        }

        string IPersistableModel<FineTuneHyperparams>.GetWireFormat(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static FineTuneHyperparams FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFineTuneHyperparams(document.RootElement, ModelReaderWriterOptions.Wire);
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
