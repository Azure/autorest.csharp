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
    public partial class CreateCategories : IUtf8JsonWriteable, IJsonModel<CreateCategories>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<CreateCategories>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<CreateCategories>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCategories>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(CreateCategories)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("hate"u8);
            writer.WriteBooleanValue(Hate);
            writer.WritePropertyName("hate/threatening"u8);
            writer.WriteBooleanValue(HateThreatening);
            writer.WritePropertyName("harassment"u8);
            writer.WriteBooleanValue(Harassment);
            writer.WritePropertyName("harassment/threatening"u8);
            writer.WriteBooleanValue(HarassmentThreatening);
            writer.WritePropertyName("self-harm"u8);
            writer.WriteBooleanValue(SelfHarm);
            writer.WritePropertyName("self-harm/intent"u8);
            writer.WriteBooleanValue(SelfHarmIntent);
            writer.WritePropertyName("self-harm/instructive"u8);
            writer.WriteBooleanValue(SelfHarmInstructive);
            writer.WritePropertyName("sexual"u8);
            writer.WriteBooleanValue(Sexual);
            writer.WritePropertyName("sexual/minors"u8);
            writer.WriteBooleanValue(SexualMinors);
            writer.WritePropertyName("violence"u8);
            writer.WriteBooleanValue(Violence);
            writer.WritePropertyName("violence/graphic"u8);
            writer.WriteBooleanValue(ViolenceGraphic);
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        CreateCategories IJsonModel<CreateCategories>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCategories>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(CreateCategories)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateCategories(document.RootElement, options);
        }

        internal static CreateCategories DeserializeCreateCategories(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool hate = default;
            bool hateThreatening = default;
            bool harassment = default;
            bool harassmentThreatening = default;
            bool selfHarm = default;
            bool selfHarmIntent = default;
            bool selfHarmInstructive = default;
            bool sexual = default;
            bool sexualMinors = default;
            bool violence = default;
            bool violenceGraphic = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hate"u8))
                {
                    hate = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("hate/threatening"u8))
                {
                    hateThreatening = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("harassment"u8))
                {
                    harassment = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("harassment/threatening"u8))
                {
                    harassmentThreatening = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("self-harm"u8))
                {
                    selfHarm = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("self-harm/intent"u8))
                {
                    selfHarmIntent = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("self-harm/instructive"u8))
                {
                    selfHarmInstructive = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("sexual"u8))
                {
                    sexual = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("sexual/minors"u8))
                {
                    sexualMinors = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("violence"u8))
                {
                    violence = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("violence/graphic"u8))
                {
                    violenceGraphic = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CreateCategories(hate, hateThreatening, harassment, harassmentThreatening, selfHarm, selfHarmIntent, selfHarmInstructive, sexual, sexualMinors, violence, violenceGraphic, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateCategories>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCategories>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(CreateCategories)} does not support '{options.Format}' format.");
            }
        }

        CreateCategories IPersistableModel<CreateCategories>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCategories>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateCategories(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(CreateCategories)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateCategories>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateCategories FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateCategories(document.RootElement, new ModelReaderWriterOptions("W"));
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
