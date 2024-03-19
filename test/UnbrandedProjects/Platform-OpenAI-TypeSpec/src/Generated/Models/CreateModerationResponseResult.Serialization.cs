// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Models
{
    public partial class CreateModerationResponseResult : IJsonModel<CreateModerationResponseResult>
    {
        void IJsonModel<CreateModerationResponseResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateModerationResponseResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateModerationResponseResult)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("flagged"u8);
            writer.WriteBooleanValue(Flagged);
            writer.WritePropertyName("categories"u8);
            writer.WriteObjectValue(Categories);
            writer.WritePropertyName("category_scores"u8);
            writer.WriteObjectValue(CategoryScores);
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        CreateModerationResponseResult IJsonModel<CreateModerationResponseResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateModerationResponseResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateModerationResponseResult)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateModerationResponseResult(document.RootElement, options);
        }

        internal static CreateModerationResponseResult DeserializeCreateModerationResponseResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool flagged = default;
            CreateModerationResponseResultCategories categories = default;
            CreateModerationResponseResultCategoryScores categoryScores = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("flagged"u8))
                {
                    flagged = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("categories"u8))
                {
                    categories = CreateModerationResponseResultCategories.DeserializeCreateModerationResponseResultCategories(property.Value, options);
                    continue;
                }
                if (property.NameEquals("category_scores"u8))
                {
                    categoryScores = CreateModerationResponseResultCategoryScores.DeserializeCreateModerationResponseResultCategoryScores(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CreateModerationResponseResult(flagged, categories, categoryScores, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateModerationResponseResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateModerationResponseResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateModerationResponseResult)} does not support '{options.Format}' format.");
            }
        }

        CreateModerationResponseResult IPersistableModel<CreateModerationResponseResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateModerationResponseResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateModerationResponseResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateModerationResponseResult)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateModerationResponseResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateModerationResponseResult FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateModerationResponseResult(document.RootElement);
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
