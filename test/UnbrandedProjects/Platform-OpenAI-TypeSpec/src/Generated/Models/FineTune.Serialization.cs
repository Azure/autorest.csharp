// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class FineTune : IJsonModel<FineTune>
    {
        void IJsonModel<FineTune>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTune>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTune)} does not support writing '{format}' format.");
            }

            if (SerializedAdditionalRawData?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (SerializedAdditionalRawData?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("created_at") != true)
            {
                writer.WritePropertyName("created_at"u8);
                writer.WriteNumberValue(CreatedAt, "U");
            }
            if (SerializedAdditionalRawData?.ContainsKey("updated_at") != true)
            {
                writer.WritePropertyName("updated_at"u8);
                writer.WriteNumberValue(UpdatedAt, "U");
            }
            if (SerializedAdditionalRawData?.ContainsKey("model") != true)
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model);
            }
            if (SerializedAdditionalRawData?.ContainsKey("fine_tuned_model") != true)
            {
                if (FineTunedModel != null)
                {
                    writer.WritePropertyName("fine_tuned_model"u8);
                    writer.WriteStringValue(FineTunedModel);
                }
                else
                {
                    writer.WriteNull("fine_tuned_model");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("organization_id") != true)
            {
                writer.WritePropertyName("organization_id"u8);
                writer.WriteStringValue(OrganizationId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("status") != true)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.ToSerialString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("hyperparams") != true)
            {
                writer.WritePropertyName("hyperparams"u8);
                writer.WriteObjectValue(Hyperparams, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("training_files") != true)
            {
                writer.WritePropertyName("training_files"u8);
                writer.WriteStartArray();
                foreach (var item in TrainingFiles)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("validation_files") != true)
            {
                writer.WritePropertyName("validation_files"u8);
                writer.WriteStartArray();
                foreach (var item in ValidationFiles)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("result_files") != true)
            {
                writer.WritePropertyName("result_files"u8);
                writer.WriteStartArray();
                foreach (var item in ResultFiles)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("events") != true && Optional.IsCollectionDefined(Events))
            {
                writer.WritePropertyName("events"u8);
                writer.WriteStartArray();
                foreach (var item in Events)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData != null)
            {
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
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        FineTune IJsonModel<FineTune>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTune>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTune)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTune(document.RootElement, options);
        }

        internal static FineTune DeserializeFineTune(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            FineTuneObject @object = default;
            DateTimeOffset createdAt = default;
            DateTimeOffset updatedAt = default;
            string model = default;
            string fineTunedModel = default;
            string organizationId = default;
            FineTuneStatus status = default;
            FineTuneHyperparams hyperparams = default;
            IReadOnlyList<OpenAIFile> trainingFiles = default;
            IReadOnlyList<OpenAIFile> validationFiles = default;
            IReadOnlyList<OpenAIFile> resultFiles = default;
            IReadOnlyList<FineTuneEvent> events = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = new FineTuneObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("updated_at"u8))
                {
                    updatedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
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
                    status = property.Value.GetString().ToFineTuneStatus();
                    continue;
                }
                if (property.NameEquals("hyperparams"u8))
                {
                    hyperparams = FineTuneHyperparams.DeserializeFineTuneHyperparams(property.Value, options);
                    continue;
                }
                if (property.NameEquals("training_files"u8))
                {
                    List<OpenAIFile> array = new List<OpenAIFile>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OpenAIFile.DeserializeOpenAIFile(item, options));
                    }
                    trainingFiles = array;
                    continue;
                }
                if (property.NameEquals("validation_files"u8))
                {
                    List<OpenAIFile> array = new List<OpenAIFile>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OpenAIFile.DeserializeOpenAIFile(item, options));
                    }
                    validationFiles = array;
                    continue;
                }
                if (property.NameEquals("result_files"u8))
                {
                    List<OpenAIFile> array = new List<OpenAIFile>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OpenAIFile.DeserializeOpenAIFile(item, options));
                    }
                    resultFiles = array;
                    continue;
                }
                if (property.NameEquals("events"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FineTuneEvent> array = new List<FineTuneEvent>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FineTuneEvent.DeserializeFineTuneEvent(item, options));
                    }
                    events = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FineTune(
                id,
                @object,
                createdAt,
                updatedAt,
                model,
                fineTunedModel,
                organizationId,
                status,
                hyperparams,
                trainingFiles,
                validationFiles,
                resultFiles,
                events ?? new ChangeTrackingList<FineTuneEvent>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FineTune>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTune>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FineTune)} does not support writing '{options.Format}' format.");
            }
        }

        FineTune IPersistableModel<FineTune>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTune>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeFineTune(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FineTune)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FineTune>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static FineTune FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeFineTune(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
