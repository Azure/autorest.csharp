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
    public partial class ReadResult : IUtf8JsonSerializable, IJsonModel<ReadResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ReadResult>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ReadResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("page"u8);
            writer.WriteNumberValue(Page);
            writer.WritePropertyName("angle"u8);
            writer.WriteNumberValue(Angle);
            writer.WritePropertyName("width"u8);
            writer.WriteNumberValue(Width);
            writer.WritePropertyName("height"u8);
            writer.WriteNumberValue(Height);
            writer.WritePropertyName("unit"u8);
            writer.WriteStringValue(Unit.ToSerialString());
            if (Optional.IsDefined(Language))
            {
                writer.WritePropertyName("language"u8);
                writer.WriteStringValue(Language.Value.ToString());
            }
            if (Optional.IsCollectionDefined(Lines))
            {
                writer.WritePropertyName("lines"u8);
                writer.WriteStartArray();
                foreach (var item in Lines)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
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

        ReadResult IJsonModel<ReadResult>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeReadResult(document.RootElement, options);
        }

        internal static ReadResult DeserializeReadResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int page = default;
            float angle = default;
            float width = default;
            float height = default;
            LengthUnit unit = default;
            Optional<Language> language = default;
            Optional<IReadOnlyList<TextLine>> lines = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("page"u8))
                {
                    page = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("angle"u8))
                {
                    angle = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("width"u8))
                {
                    width = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("height"u8))
                {
                    height = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("unit"u8))
                {
                    unit = property.Value.GetString().ToLengthUnit();
                    continue;
                }
                if (property.NameEquals("language"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    language = new Language(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("lines"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TextLine> array = new List<TextLine>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TextLine.DeserializeTextLine(item));
                    }
                    lines = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ReadResult(page, angle, width, height, unit, Optional.ToNullable(language), Optional.ToList(lines), serializedAdditionalRawData);
        }

        BinaryData IModel<ReadResult>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.WriteCore(this, options);
        }

        ReadResult IModel<ReadResult>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeReadResult(document.RootElement, options);
        }
    }
}
