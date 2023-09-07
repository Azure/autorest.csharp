// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class ReadResult : IUtf8JsonSerializable, IModelJsonSerializable<ReadResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ReadResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ReadResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

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
                    if (item is null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        ((IModelJsonSerializable<TextLine>)item).Serialize(writer, options);
                    }
                }
                writer.WriteEndArray();
            }
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static ReadResult DeserializeReadResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ReadResult(page, angle, width, height, unit, Optional.ToNullable(language), Optional.ToList(lines), serializedAdditionalRawData);
        }

        ReadResult IModelJsonSerializable<ReadResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeReadResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ReadResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ReadResult IModelSerializable<ReadResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeReadResult(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ReadResult"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ReadResult"/> to convert. </param>
        public static implicit operator RequestContent(ReadResult model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ReadResult"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ReadResult(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeReadResult(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
