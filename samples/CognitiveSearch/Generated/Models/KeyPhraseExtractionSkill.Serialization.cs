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

namespace CognitiveSearch.Models
{
    public partial class KeyPhraseExtractionSkill : IUtf8JsonSerializable, IJsonModel<KeyPhraseExtractionSkill>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<KeyPhraseExtractionSkill>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<KeyPhraseExtractionSkill>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<KeyPhraseExtractionSkill>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<KeyPhraseExtractionSkill>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(DefaultLanguageCode))
            {
                writer.WritePropertyName("defaultLanguageCode"u8);
                writer.WriteStringValue(DefaultLanguageCode.Value.ToString());
            }
            if (Optional.IsDefined(MaxKeyPhraseCount))
            {
                if (MaxKeyPhraseCount != null)
                {
                    writer.WritePropertyName("maxKeyPhraseCount"u8);
                    writer.WriteNumberValue(MaxKeyPhraseCount.Value);
                }
                else
                {
                    writer.WriteNull("maxKeyPhraseCount");
                }
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(Context))
            {
                writer.WritePropertyName("context"u8);
                writer.WriteStringValue(Context);
            }
            writer.WritePropertyName("inputs"u8);
            writer.WriteStartArray();
            foreach (var item in Inputs)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("outputs"u8);
            writer.WriteStartArray();
            foreach (var item in Outputs)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
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

        KeyPhraseExtractionSkill IJsonModel<KeyPhraseExtractionSkill>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(KeyPhraseExtractionSkill)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeKeyPhraseExtractionSkill(document.RootElement, options);
        }

        internal static KeyPhraseExtractionSkill DeserializeKeyPhraseExtractionSkill(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<KeyPhraseExtractionSkillLanguage> defaultLanguageCode = default;
            Optional<int?> maxKeyPhraseCount = default;
            string odataType = default;
            Optional<string> name = default;
            Optional<string> description = default;
            Optional<string> context = default;
            IList<InputFieldMappingEntry> inputs = default;
            IList<OutputFieldMappingEntry> outputs = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("defaultLanguageCode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    defaultLanguageCode = new KeyPhraseExtractionSkillLanguage(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("maxKeyPhraseCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxKeyPhraseCount = null;
                        continue;
                    }
                    maxKeyPhraseCount = property.Value.GetInt32();
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
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("context"u8))
                {
                    context = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("inputs"u8))
                {
                    List<InputFieldMappingEntry> array = new List<InputFieldMappingEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InputFieldMappingEntry.DeserializeInputFieldMappingEntry(item));
                    }
                    inputs = array;
                    continue;
                }
                if (property.NameEquals("outputs"u8))
                {
                    List<OutputFieldMappingEntry> array = new List<OutputFieldMappingEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OutputFieldMappingEntry.DeserializeOutputFieldMappingEntry(item));
                    }
                    outputs = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new KeyPhraseExtractionSkill(odataType, name.Value, description.Value, context.Value, inputs, outputs, serializedAdditionalRawData, Optional.ToNullable(defaultLanguageCode), Optional.ToNullable(maxKeyPhraseCount));
        }

        BinaryData IModel<KeyPhraseExtractionSkill>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(KeyPhraseExtractionSkill)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        KeyPhraseExtractionSkill IModel<KeyPhraseExtractionSkill>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(KeyPhraseExtractionSkill)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeKeyPhraseExtractionSkill(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<KeyPhraseExtractionSkill>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
