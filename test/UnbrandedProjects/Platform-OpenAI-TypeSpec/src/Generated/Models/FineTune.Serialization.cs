// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class FineTune : IUtf8JsonWriteable, IJsonModel<FineTune>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<FineTune>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<FineTune>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<FineTune>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<FineTune>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(Object.ToString());
            writer.WritePropertyName("created_at"u8);
            writer.WriteNumberValue(CreatedAt, "U");
            writer.WritePropertyName("updated_at"u8);
            writer.WriteNumberValue(UpdatedAt, "U");
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
            writer.WritePropertyName("hyperparams"u8);
            writer.WriteObjectValue(Hyperparams);
            writer.WritePropertyName("training_files"u8);
            writer.WriteStartArray();
            foreach (var item in TrainingFiles)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("validation_files"u8);
            writer.WriteStartArray();
            foreach (var item in ValidationFiles)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("result_files"u8);
            writer.WriteStartArray();
            foreach (var item in ResultFiles)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (OptionalProperty.IsCollectionDefined(Events))
            {
                writer.WritePropertyName("events"u8);
                writer.WriteStartArray();
                foreach (var item in Events)
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

        FineTune IJsonModel<FineTune>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FineTune)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTune(document.RootElement, options);
        }

        internal static FineTune DeserializeFineTune(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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
            OptionalProperty<IReadOnlyList<FineTuneEvent>> events = default;
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
                    status = new FineTuneStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("hyperparams"u8))
                {
                    hyperparams = FineTuneHyperparams.DeserializeFineTuneHyperparams(property.Value);
                    continue;
                }
                if (property.NameEquals("training_files"u8))
                {
                    List<OpenAIFile> array = new List<OpenAIFile>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OpenAIFile.DeserializeOpenAIFile(item));
                    }
                    trainingFiles = array;
                    continue;
                }
                if (property.NameEquals("validation_files"u8))
                {
                    List<OpenAIFile> array = new List<OpenAIFile>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OpenAIFile.DeserializeOpenAIFile(item));
                    }
                    validationFiles = array;
                    continue;
                }
                if (property.NameEquals("result_files"u8))
                {
                    List<OpenAIFile> array = new List<OpenAIFile>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OpenAIFile.DeserializeOpenAIFile(item));
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
                        array.Add(FineTuneEvent.DeserializeFineTuneEvent(item));
                    }
                    events = array;
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new FineTune(id, @object, createdAt, updatedAt, model, fineTunedModel, organizationId, status, hyperparams, trainingFiles, validationFiles, resultFiles, OptionalProperty.ToList(events), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FineTune>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FineTune)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        FineTune IPersistableModel<FineTune>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FineTune)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFineTune(document.RootElement, options);
        }

        string IPersistableModel<FineTune>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static FineTune FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFineTune(document.RootElement, new ModelReaderWriterOptions("W"));
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
