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
    public partial class CreateImageEditRequest : IUtf8JsonWriteable, IJsonModel<CreateImageEditRequest>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<CreateImageEditRequest>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<CreateImageEditRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<CreateImageEditRequest>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<CreateImageEditRequest>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("prompt"u8);
            writer.WriteStringValue(Prompt);
            writer.WritePropertyName("image"u8);
            writer.WriteBase64StringValue(Image.ToArray(), "D");
            if (OptionalProperty.IsDefined(Mask))
            {
                writer.WritePropertyName("mask"u8);
                writer.WriteBase64StringValue(Mask.ToArray(), "D");
            }
            if (OptionalProperty.IsDefined(N))
            {
                if (N != null)
                {
                    writer.WritePropertyName("n"u8);
                    writer.WriteNumberValue(N.Value);
                }
                else
                {
                    writer.WriteNull("n");
                }
            }
            if (OptionalProperty.IsDefined(Size))
            {
                writer.WritePropertyName("size"u8);
                writer.WriteStringValue(Size.Value.ToString());
            }
            if (OptionalProperty.IsDefined(ResponseFormat))
            {
                writer.WritePropertyName("response_format"u8);
                writer.WriteStringValue(ResponseFormat.Value.ToString());
            }
            if (OptionalProperty.IsDefined(User))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(User);
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

        CreateImageEditRequest IJsonModel<CreateImageEditRequest>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateImageEditRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateImageEditRequest(document.RootElement, options);
        }

        internal static CreateImageEditRequest DeserializeCreateImageEditRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string prompt = default;
            BinaryData image = default;
            OptionalProperty<BinaryData> mask = default;
            OptionalProperty<long?> n = default;
            OptionalProperty<CreateImageEditRequestSize> size = default;
            OptionalProperty<CreateImageEditRequestResponseFormat> responseFormat = default;
            OptionalProperty<string> user = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("prompt"u8))
                {
                    prompt = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("image"u8))
                {
                    image = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (property.NameEquals("mask"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mask = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (property.NameEquals("n"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        n = null;
                        continue;
                    }
                    n = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("size"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    size = new CreateImageEditRequestSize(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("response_format"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    responseFormat = new CreateImageEditRequestResponseFormat(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("user"u8))
                {
                    user = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CreateImageEditRequest(prompt, image, mask.Value, OptionalProperty.ToNullable(n), OptionalProperty.ToNullable(size), OptionalProperty.ToNullable(responseFormat), user.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<CreateImageEditRequest>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateImageEditRequest)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        CreateImageEditRequest IModel<CreateImageEditRequest>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateImageEditRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCreateImageEditRequest(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<CreateImageEditRequest>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static CreateImageEditRequest FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeCreateImageEditRequest(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
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
