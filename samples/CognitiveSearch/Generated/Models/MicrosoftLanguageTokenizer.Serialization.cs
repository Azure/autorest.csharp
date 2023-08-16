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

namespace CognitiveSearch.Models
{
    public partial class MicrosoftLanguageTokenizer : IUtf8JsonSerializable, IModelJsonSerializable<MicrosoftLanguageTokenizer>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<MicrosoftLanguageTokenizer>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<MicrosoftLanguageTokenizer>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MicrosoftLanguageTokenizer>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(MaxTokenLength))
            {
                writer.WritePropertyName("maxTokenLength"u8);
                writer.WriteNumberValue(MaxTokenLength.Value);
            }
            if (Optional.IsDefined(IsSearchTokenizer))
            {
                writer.WritePropertyName("isSearchTokenizer"u8);
                writer.WriteBooleanValue(IsSearchTokenizer.Value);
            }
            if (Optional.IsDefined(Language))
            {
                writer.WritePropertyName("language"u8);
                writer.WriteStringValue(Language.Value.ToSerialString());
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
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

        internal static MicrosoftLanguageTokenizer DeserializeMicrosoftLanguageTokenizer(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> maxTokenLength = default;
            Optional<bool> isSearchTokenizer = default;
            Optional<MicrosoftTokenizerLanguage> language = default;
            string odataType = default;
            string name = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxTokenLength"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenLength = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("isSearchTokenizer"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isSearchTokenizer = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("language"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    language = property.Value.GetString().ToMicrosoftTokenizerLanguage();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new MicrosoftLanguageTokenizer(odataType, name, Optional.ToNullable(maxTokenLength), Optional.ToNullable(isSearchTokenizer), Optional.ToNullable(language), rawData);
        }

        MicrosoftLanguageTokenizer IModelJsonSerializable<MicrosoftLanguageTokenizer>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MicrosoftLanguageTokenizer>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeMicrosoftLanguageTokenizer(doc.RootElement, options);
        }

        BinaryData IModelSerializable<MicrosoftLanguageTokenizer>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MicrosoftLanguageTokenizer>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        MicrosoftLanguageTokenizer IModelSerializable<MicrosoftLanguageTokenizer>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MicrosoftLanguageTokenizer>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeMicrosoftLanguageTokenizer(doc.RootElement, options);
        }

        public static implicit operator RequestContent(MicrosoftLanguageTokenizer model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator MicrosoftLanguageTokenizer(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeMicrosoftLanguageTokenizer(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
