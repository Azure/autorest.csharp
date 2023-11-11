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
    public partial class WordDelimiterTokenFilter : IUtf8JsonSerializable, IJsonModel<WordDelimiterTokenFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<WordDelimiterTokenFilter>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<WordDelimiterTokenFilter>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<WordDelimiterTokenFilter>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<WordDelimiterTokenFilter>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(GenerateWordParts))
            {
                writer.WritePropertyName("generateWordParts"u8);
                writer.WriteBooleanValue(GenerateWordParts.Value);
            }
            if (Optional.IsDefined(GenerateNumberParts))
            {
                writer.WritePropertyName("generateNumberParts"u8);
                writer.WriteBooleanValue(GenerateNumberParts.Value);
            }
            if (Optional.IsDefined(CatenateWords))
            {
                writer.WritePropertyName("catenateWords"u8);
                writer.WriteBooleanValue(CatenateWords.Value);
            }
            if (Optional.IsDefined(CatenateNumbers))
            {
                writer.WritePropertyName("catenateNumbers"u8);
                writer.WriteBooleanValue(CatenateNumbers.Value);
            }
            if (Optional.IsDefined(CatenateAll))
            {
                writer.WritePropertyName("catenateAll"u8);
                writer.WriteBooleanValue(CatenateAll.Value);
            }
            if (Optional.IsDefined(SplitOnCaseChange))
            {
                writer.WritePropertyName("splitOnCaseChange"u8);
                writer.WriteBooleanValue(SplitOnCaseChange.Value);
            }
            if (Optional.IsDefined(PreserveOriginal))
            {
                writer.WritePropertyName("preserveOriginal"u8);
                writer.WriteBooleanValue(PreserveOriginal.Value);
            }
            if (Optional.IsDefined(SplitOnNumerics))
            {
                writer.WritePropertyName("splitOnNumerics"u8);
                writer.WriteBooleanValue(SplitOnNumerics.Value);
            }
            if (Optional.IsDefined(StemEnglishPossessive))
            {
                writer.WritePropertyName("stemEnglishPossessive"u8);
                writer.WriteBooleanValue(StemEnglishPossessive.Value);
            }
            if (Optional.IsCollectionDefined(ProtectedWords))
            {
                writer.WritePropertyName("protectedWords"u8);
                writer.WriteStartArray();
                foreach (var item in ProtectedWords)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
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

        WordDelimiterTokenFilter IJsonModel<WordDelimiterTokenFilter>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(WordDelimiterTokenFilter)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWordDelimiterTokenFilter(document.RootElement, options);
        }

        internal static WordDelimiterTokenFilter DeserializeWordDelimiterTokenFilter(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> generateWordParts = default;
            Optional<bool> generateNumberParts = default;
            Optional<bool> catenateWords = default;
            Optional<bool> catenateNumbers = default;
            Optional<bool> catenateAll = default;
            Optional<bool> splitOnCaseChange = default;
            Optional<bool> preserveOriginal = default;
            Optional<bool> splitOnNumerics = default;
            Optional<bool> stemEnglishPossessive = default;
            Optional<IList<string>> protectedWords = default;
            string odataType = default;
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("generateWordParts"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    generateWordParts = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("generateNumberParts"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    generateNumberParts = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("catenateWords"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    catenateWords = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("catenateNumbers"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    catenateNumbers = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("catenateAll"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    catenateAll = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("splitOnCaseChange"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    splitOnCaseChange = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("preserveOriginal"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    preserveOriginal = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("splitOnNumerics"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    splitOnNumerics = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("stemEnglishPossessive"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    stemEnglishPossessive = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("protectedWords"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    protectedWords = array;
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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new WordDelimiterTokenFilter(odataType, name, serializedAdditionalRawData, Optional.ToNullable(generateWordParts), Optional.ToNullable(generateNumberParts), Optional.ToNullable(catenateWords), Optional.ToNullable(catenateNumbers), Optional.ToNullable(catenateAll), Optional.ToNullable(splitOnCaseChange), Optional.ToNullable(preserveOriginal), Optional.ToNullable(splitOnNumerics), Optional.ToNullable(stemEnglishPossessive), Optional.ToList(protectedWords));
        }

        BinaryData IModel<WordDelimiterTokenFilter>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(WordDelimiterTokenFilter)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        WordDelimiterTokenFilter IModel<WordDelimiterTokenFilter>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(WordDelimiterTokenFilter)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeWordDelimiterTokenFilter(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<WordDelimiterTokenFilter>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
