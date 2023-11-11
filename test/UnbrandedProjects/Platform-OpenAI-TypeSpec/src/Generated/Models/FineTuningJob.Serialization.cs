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
    public partial class FineTuningJob : IUtf8JsonWriteable, IJsonModel<FineTuningJob>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<FineTuningJob>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<FineTuningJob>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<FineTuningJob>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<FineTuningJob>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(Object.ToString());
            writer.WritePropertyName("created_at"u8);
            writer.WriteNumberValue(CreatedAt, "U");
            if (FinishedAt != null)
            {
                writer.WritePropertyName("finished_at"u8);
                writer.WriteStringValue(FinishedAt.Value, "O");
            }
            else
            {
                writer.WriteNull("finished_at");
            }
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(Model);
            if (FineTunedModel != null)
            {
                writer.WritePropertyName("fine_tuned_model"u8);
                writer.WriteStringValue(FineTunedModel);
            }
            else
            {
                writer.WriteNull("fine_tuned_model");
            }
            writer.WritePropertyName("organization_id"u8);
            writer.WriteStringValue(OrganizationId);
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status.ToString());
            writer.WritePropertyName("hyperparameters"u8);
            writer.WriteObjectValue(Hyperparameters);
            writer.WritePropertyName("training_file"u8);
            writer.WriteStringValue(TrainingFile);
            if (ValidationFile != null)
            {
                writer.WritePropertyName("validation_file"u8);
                writer.WriteStringValue(ValidationFile);
            }
            else
            {
                writer.WriteNull("validation_file");
            }
            writer.WritePropertyName("result_files"u8);
            writer.WriteStartArray();
            foreach (var item in ResultFiles)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (TrainedTokens != null)
            {
                writer.WritePropertyName("trained_tokens"u8);
                writer.WriteNumberValue(TrainedTokens.Value);
            }
            else
            {
                writer.WriteNull("trained_tokens");
            }
            if (Error != null)
            {
                writer.WritePropertyName("error"u8);
                writer.WriteObjectValue(Error);
            }
            else
            {
                writer.WriteNull("error");
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

        FineTuningJob IJsonModel<FineTuningJob>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FineTuningJob)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTuningJob(document.RootElement, options);
        }

        internal static FineTuningJob DeserializeFineTuningJob(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            FineTuningJobObject @object = default;
            DateTimeOffset createdAt = default;
            DateTimeOffset? finishedAt = default;
            string model = default;
            string fineTunedModel = default;
            string organizationId = default;
            FineTuningJobStatus status = default;
            FineTuningJobHyperparameters hyperparameters = default;
            string trainingFile = default;
            string validationFile = default;
            IReadOnlyList<string> resultFiles = default;
            long? trainedTokens = default;
            FineTuningJobError error = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = new FineTuningJobObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("finished_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        finishedAt = null;
                        continue;
                    }
                    finishedAt = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fine_tuned_model"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        fineTunedModel = null;
                        continue;
                    }
                    fineTunedModel = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("organization_id"u8))
                {
                    organizationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new FineTuningJobStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("hyperparameters"u8))
                {
                    hyperparameters = FineTuningJobHyperparameters.DeserializeFineTuningJobHyperparameters(property.Value);
                    continue;
                }
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
                if (property.NameEquals("result_files"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    resultFiles = array;
                    continue;
                }
                if (property.NameEquals("trained_tokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        trainedTokens = null;
                        continue;
                    }
                    trainedTokens = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        error = null;
                        continue;
                    }
                    error = FineTuningJobError.DeserializeFineTuningJobError(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new FineTuningJob(id, @object, createdAt, finishedAt, model, fineTunedModel, organizationId, status, hyperparameters, trainingFile, validationFile, resultFiles, trainedTokens, error, serializedAdditionalRawData);
        }

        BinaryData IModel<FineTuningJob>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FineTuningJob)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        FineTuningJob IModel<FineTuningJob>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FineTuningJob)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFineTuningJob(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<FineTuningJob>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static FineTuningJob FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeFineTuningJob(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
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
