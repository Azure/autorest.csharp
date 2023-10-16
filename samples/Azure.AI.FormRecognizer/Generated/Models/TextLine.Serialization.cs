// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class TextLine : IUtf8JsonSerializable, IModelJsonSerializable<TextLine>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TextLine>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TextLine>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("text"u8);
            writer.WriteStringValue(Text);
            writer.WritePropertyName("boundingBox"u8);
            writer.WriteStartArray();
            foreach (var item in BoundingBox)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(Language))
            {
                writer.WritePropertyName("language"u8);
                writer.WriteStringValue(Language.Value.ToString());
            }
            writer.WritePropertyName("words"u8);
            writer.WriteStartArray();
            foreach (var item in Words)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        TextLine IModelJsonSerializable<TextLine>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeTextLine(doc.RootElement, options);
        }

        BinaryData IModelSerializable<TextLine>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        TextLine IModelSerializable<TextLine>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeTextLine(document.RootElement, options);
        }

        internal static TextLine DeserializeTextLine(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string text = default;
            IReadOnlyList<float> boundingBox = default;
            Optional<Language> language = default;
            IReadOnlyList<TextWord> words = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boundingBox"u8))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    boundingBox = array;
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
                if (property.NameEquals("words"u8))
                {
                    List<TextWord> array = new List<TextWord>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TextWord.DeserializeTextWord(item));
                    }
                    words = array;
                    continue;
                }
            }
            return new TextLine(text, boundingBox, Optional.ToNullable(language), words);
        }
    }
}
