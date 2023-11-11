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
    public partial class AnalyzeResult : IUtf8JsonSerializable, IJsonModel<AnalyzeResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AnalyzeResult>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<AnalyzeResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<AnalyzeResult>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<AnalyzeResult>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("version"u8);
            writer.WriteStringValue(Version);
            writer.WritePropertyName("readResults"u8);
            writer.WriteStartArray();
            foreach (var item in ReadResults)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsCollectionDefined(PageResults))
            {
                writer.WritePropertyName("pageResults"u8);
                writer.WriteStartArray();
                foreach (var item in PageResults)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DocumentResults))
            {
                writer.WritePropertyName("documentResults"u8);
                writer.WriteStartArray();
                foreach (var item in DocumentResults)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Errors))
            {
                writer.WritePropertyName("errors"u8);
                writer.WriteStartArray();
                foreach (var item in Errors)
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

        AnalyzeResult IJsonModel<AnalyzeResult>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AnalyzeResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAnalyzeResult(document.RootElement, options);
        }

        internal static AnalyzeResult DeserializeAnalyzeResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string version = default;
            IReadOnlyList<ReadResult> readResults = default;
            Optional<IReadOnlyList<PageResult>> pageResults = default;
            Optional<IReadOnlyList<DocumentResult>> documentResults = default;
            Optional<IReadOnlyList<ErrorInformation>> errors = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("version"u8))
                {
                    version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("readResults"u8))
                {
                    List<ReadResult> array = new List<ReadResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ReadResult.DeserializeReadResult(item));
                    }
                    readResults = array;
                    continue;
                }
                if (property.NameEquals("pageResults"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PageResult> array = new List<PageResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PageResult.DeserializePageResult(item));
                    }
                    pageResults = array;
                    continue;
                }
                if (property.NameEquals("documentResults"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DocumentResult> array = new List<DocumentResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DocumentResult.DeserializeDocumentResult(item));
                    }
                    documentResults = array;
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ErrorInformation> array = new List<ErrorInformation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ErrorInformation.DeserializeErrorInformation(item));
                    }
                    errors = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new AnalyzeResult(version, readResults, Optional.ToList(pageResults), Optional.ToList(documentResults), Optional.ToList(errors), serializedAdditionalRawData);
        }

        BinaryData IModel<AnalyzeResult>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AnalyzeResult)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        AnalyzeResult IModel<AnalyzeResult>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AnalyzeResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAnalyzeResult(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<AnalyzeResult>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
