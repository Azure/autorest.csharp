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
    public partial class AnalyzeRequest : IUtf8JsonSerializable, IJsonModel<AnalyzeRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AnalyzeRequest>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<AnalyzeRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<AnalyzeRequest>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<AnalyzeRequest>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("text"u8);
            writer.WriteStringValue(Text);
            if (Optional.IsDefined(Analyzer))
            {
                writer.WritePropertyName("analyzer"u8);
                writer.WriteStringValue(Analyzer.Value.ToString());
            }
            if (Optional.IsDefined(Tokenizer))
            {
                writer.WritePropertyName("tokenizer"u8);
                writer.WriteStringValue(Tokenizer.Value.ToString());
            }
            if (Optional.IsCollectionDefined(TokenFilters))
            {
                writer.WritePropertyName("tokenFilters"u8);
                writer.WriteStartArray();
                foreach (var item in TokenFilters)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(CharFilters))
            {
                writer.WritePropertyName("charFilters"u8);
                writer.WriteStartArray();
                foreach (var item in CharFilters)
                {
                    writer.WriteStringValue(item.ToString());
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

        AnalyzeRequest IJsonModel<AnalyzeRequest>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AnalyzeRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAnalyzeRequest(document.RootElement, options);
        }

        internal static AnalyzeRequest DeserializeAnalyzeRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string text = default;
            Optional<AnalyzerName> analyzer = default;
            Optional<TokenizerName> tokenizer = default;
            Optional<IList<TokenFilterName>> tokenFilters = default;
            Optional<IList<CharFilterName>> charFilters = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("analyzer"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    analyzer = new AnalyzerName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tokenizer"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tokenizer = new TokenizerName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tokenFilters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TokenFilterName> array = new List<TokenFilterName>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new TokenFilterName(item.GetString()));
                    }
                    tokenFilters = array;
                    continue;
                }
                if (property.NameEquals("charFilters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CharFilterName> array = new List<CharFilterName>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new CharFilterName(item.GetString()));
                    }
                    charFilters = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new AnalyzeRequest(text, Optional.ToNullable(analyzer), Optional.ToNullable(tokenizer), Optional.ToList(tokenFilters), Optional.ToList(charFilters), serializedAdditionalRawData);
        }

        BinaryData IModel<AnalyzeRequest>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AnalyzeRequest)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        AnalyzeRequest IModel<AnalyzeRequest>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AnalyzeRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAnalyzeRequest(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<AnalyzeRequest>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
