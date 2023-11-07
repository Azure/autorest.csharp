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
    public partial class CustomAnalyzer : IUtf8JsonSerializable, IJsonModel<CustomAnalyzer>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<CustomAnalyzer>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<CustomAnalyzer>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("tokenizer"u8);
            writer.WriteStringValue(Tokenizer.ToString());
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

        CustomAnalyzer IJsonModel<CustomAnalyzer>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CustomAnalyzer)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCustomAnalyzer(document.RootElement, options);
        }

        internal static CustomAnalyzer DeserializeCustomAnalyzer(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            TokenizerName tokenizer = default;
            Optional<IList<TokenFilterName>> tokenFilters = default;
            Optional<IList<CharFilterName>> charFilters = default;
            string odataType = default;
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tokenizer"u8))
                {
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
            return new CustomAnalyzer(odataType, name, serializedAdditionalRawData, tokenizer, Optional.ToList(tokenFilters), Optional.ToList(charFilters));
        }

        BinaryData IModel<CustomAnalyzer>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CustomAnalyzer)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        CustomAnalyzer IModel<CustomAnalyzer>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CustomAnalyzer)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCustomAnalyzer(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<CustomAnalyzer>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
