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

namespace FlattenedParameters.Models
{
    internal partial class PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable, IJsonModel<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Items))
            {
                writer.WritePropertyName("items"u8);
                writer.WriteStartArray();
                foreach (var item in Items)
                {
                    writer.WriteStringValue(item);
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

        PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema IJsonModel<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema(document.RootElement, options);
        }

        internal static PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema DeserializePathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> items = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("items"u8))
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
                    items = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema(Optional.ToList(items), serializedAdditionalRawData);
        }

        BinaryData IModel<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema IModel<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
