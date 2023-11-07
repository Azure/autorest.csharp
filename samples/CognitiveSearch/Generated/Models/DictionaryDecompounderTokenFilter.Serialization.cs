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
    public partial class DictionaryDecompounderTokenFilter : IUtf8JsonSerializable, IJsonModel<DictionaryDecompounderTokenFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DictionaryDecompounderTokenFilter>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<DictionaryDecompounderTokenFilter>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("wordList"u8);
            writer.WriteStartArray();
            foreach (var item in WordList)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(MinWordSize))
            {
                writer.WritePropertyName("minWordSize"u8);
                writer.WriteNumberValue(MinWordSize.Value);
            }
            if (Optional.IsDefined(MinSubwordSize))
            {
                writer.WritePropertyName("minSubwordSize"u8);
                writer.WriteNumberValue(MinSubwordSize.Value);
            }
            if (Optional.IsDefined(MaxSubwordSize))
            {
                writer.WritePropertyName("maxSubwordSize"u8);
                writer.WriteNumberValue(MaxSubwordSize.Value);
            }
            if (Optional.IsDefined(OnlyLongestMatch))
            {
                writer.WritePropertyName("onlyLongestMatch"u8);
                writer.WriteBooleanValue(OnlyLongestMatch.Value);
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

        DictionaryDecompounderTokenFilter IJsonModel<DictionaryDecompounderTokenFilter>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DictionaryDecompounderTokenFilter)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDictionaryDecompounderTokenFilter(document.RootElement, options);
        }

        internal static DictionaryDecompounderTokenFilter DeserializeDictionaryDecompounderTokenFilter(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> wordList = default;
            Optional<int> minWordSize = default;
            Optional<int> minSubwordSize = default;
            Optional<int> maxSubwordSize = default;
            Optional<bool> onlyLongestMatch = default;
            string odataType = default;
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("wordList"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    wordList = array;
                    continue;
                }
                if (property.NameEquals("minWordSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minWordSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("minSubwordSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minSubwordSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxSubwordSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxSubwordSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("onlyLongestMatch"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    onlyLongestMatch = property.Value.GetBoolean();
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
            return new DictionaryDecompounderTokenFilter(odataType, name, serializedAdditionalRawData, wordList, Optional.ToNullable(minWordSize), Optional.ToNullable(minSubwordSize), Optional.ToNullable(maxSubwordSize), Optional.ToNullable(onlyLongestMatch));
        }

        BinaryData IModel<DictionaryDecompounderTokenFilter>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DictionaryDecompounderTokenFilter)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DictionaryDecompounderTokenFilter IModel<DictionaryDecompounderTokenFilter>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DictionaryDecompounderTokenFilter)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDictionaryDecompounderTokenFilter(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<DictionaryDecompounderTokenFilter>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
