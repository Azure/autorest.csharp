// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    public partial class FirstDerivedOutputModel : IUtf8JsonSerializable, IJsonModel<FirstDerivedOutputModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<FirstDerivedOutputModel>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<FirstDerivedOutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<FirstDerivedOutputModel>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<FirstDerivedOutputModel>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("first"u8);
            writer.WriteBooleanValue(First);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        FirstDerivedOutputModel IJsonModel<FirstDerivedOutputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FirstDerivedOutputModel)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFirstDerivedOutputModel(document.RootElement, options);
        }

        internal static FirstDerivedOutputModel DeserializeFirstDerivedOutputModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool first = default;
            string kind = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("first"u8))
                {
                    first = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new FirstDerivedOutputModel(kind, serializedAdditionalRawData, first);
        }

        BinaryData IPersistableModel<FirstDerivedOutputModel>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FirstDerivedOutputModel)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        FirstDerivedOutputModel IPersistableModel<FirstDerivedOutputModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FirstDerivedOutputModel)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFirstDerivedOutputModel(document.RootElement, options);
        }

        string IPersistableModel<FirstDerivedOutputModel>.GetWireFormat(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new FirstDerivedOutputModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFirstDerivedOutputModel(document.RootElement, ModelReaderWriterOptions.Wire);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
