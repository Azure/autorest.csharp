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

namespace ConfidentLevelsInTsp.Models
{
    public partial class NonConfidentModelWithSelfReference : IUtf8JsonSerializable, IJsonModel<NonConfidentModelWithSelfReference>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<NonConfidentModelWithSelfReference>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<NonConfidentModelWithSelfReference>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<NonConfidentModelWithSelfReference>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<NonConfidentModelWithSelfReference>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("selfReference"u8);
            writer.WriteStartArray();
            foreach (var item in SelfReference)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("unionProperty"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(UnionProperty);
#else
            using (JsonDocument document = JsonDocument.Parse(UnionProperty))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
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

        NonConfidentModelWithSelfReference IJsonModel<NonConfidentModelWithSelfReference>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(NonConfidentModelWithSelfReference)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNonConfidentModelWithSelfReference(document.RootElement, options);
        }

        internal static NonConfidentModelWithSelfReference DeserializeNonConfidentModelWithSelfReference(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IList<NonConfidentModelWithSelfReference> selfReference = default;
            BinaryData unionProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("selfReference"u8))
                {
                    List<NonConfidentModelWithSelfReference> array = new List<NonConfidentModelWithSelfReference>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeNonConfidentModelWithSelfReference(item));
                    }
                    selfReference = array;
                    continue;
                }
                if (property.NameEquals("unionProperty"u8))
                {
                    unionProperty = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new NonConfidentModelWithSelfReference(name, selfReference, unionProperty, serializedAdditionalRawData);
        }

        BinaryData IModel<NonConfidentModelWithSelfReference>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(NonConfidentModelWithSelfReference)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        NonConfidentModelWithSelfReference IModel<NonConfidentModelWithSelfReference>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(NonConfidentModelWithSelfReference)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeNonConfidentModelWithSelfReference(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<NonConfidentModelWithSelfReference>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static NonConfidentModelWithSelfReference FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeNonConfidentModelWithSelfReference(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
