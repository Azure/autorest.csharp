// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Microsoft.Extensions.Options;

namespace Payload.JsonMergePatch.Models
{
    public partial class ResourcePatch : IUtf8JsonSerializable, IJsonModel<ResourcePatch>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ResourcePatch>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ResourcePatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourcePatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResourcePatch)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsCollectionDefined(Map))
            {
                writer.WritePropertyName("map"u8);
                writer.WriteStartObject();
                foreach (var item in Map)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(Array))
            {
                writer.WritePropertyName("array"u8);
                writer.WriteStartArray();
                foreach (var item in Array)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(NestedModel))
            {
                writer.WritePropertyName("nestedModel"u8);
                writer.WriteObjectValue(NestedModel);
            }
            if (Optional.IsCollectionDefined(IntArray))
            {
                writer.WritePropertyName("intArray"u8);
                writer.WriteStartArray();
                foreach (var item in IntArray)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        internal void WriteJson(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsCollectionDefined(Map))
            {
                writer.WritePropertyName("map"u8);
                writer.WriteStartObject();
                foreach (var item in Map)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(Array))
            {
                writer.WritePropertyName("array"u8);
                writer.WriteStartArray();
                foreach (var item in Array)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(NestedModel))
            {
                writer.WritePropertyName("nestedModel"u8);
                writer.WriteObjectValue(NestedModel);
            }
            if (Optional.IsCollectionDefined(IntArray))
            {
                writer.WritePropertyName("intArray"u8);
                writer.WriteStartArray();
                foreach (var item in IntArray)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (_serializedAdditionalRawData != null)
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

        internal void WritePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (_description != null)
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(_description);
            }
            else if (_descriptionChanged)
            {
                writer.WritePropertyName("description"u8);
                writer.WriteNullValue();
            }

            if (Optional.IsCollectionDefined(_map))
            {
                writer.WritePropertyName("map"u8);
                writer.WriteStartObject();
                foreach (var item in _map)
                {
                    writer.WritePropertyName(item.Key);
                    item.Value.WriteJson(writer);
                }
                writer.WriteEndObject();
            }
            else if (_mapChanged && _map == null)
            {
                writer.WritePropertyName("map"u8);
                writer.WriteNullValue();
            }

            if (Optional.IsCollectionDefined(_array))
            {
                writer.WriteStartArray();
                foreach (var item in _array)
                {
                    item.WriteJson(writer);
                }
                writer.WriteEndArray();
            }
            else if (_arrayChanged && _array == null)
            {
                writer.WritePropertyName("array"u8);
                writer.WriteNullValue();
            }

            if (_nestedModel != null)
            {
                writer.WritePropertyName("nestedModel"u8);
                _nestedModel.WritePatch(writer);
            }
            else if (_nestedModelChanged)
            {
                writer.WritePropertyName("nestedModel"u8);
                writer.WriteNullValue();
            }

            if (Optional.IsCollectionDefined(_intArray))
            {
                writer.WritePropertyName("intArray"u8);
                writer.WriteStartArray();
                foreach (var item in _intArray)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            else if (_intArrayChanged && _intArray == null)
            {
                writer.WritePropertyName("intArray"u8);
                writer.WriteNullValue();
            }
        }

        ResourcePatch IJsonModel<ResourcePatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourcePatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResourcePatch)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeResourcePatch(document.RootElement, options);
        }

        internal static ResourcePatch DeserializeResourcePatch(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> description = default;
            Optional<IDictionary<string, InnerModel>> map = default;
            Optional<IList<InnerModel>> array = default;
            Optional<NestedModel> nestedModel = default;
            Optional<IList<int>> intArray = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("map"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, InnerModel> dictionary = new Dictionary<string, InnerModel>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, InnerModel.DeserializeInnerModel(property0.Value));
                    }
                    map = dictionary;
                    continue;
                }
                if (property.NameEquals("array"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InnerModel> array0 = new List<InnerModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array0.Add(InnerModel.DeserializeInnerModel(item));
                    }
                    array = array0;
                    continue;
                }
                if (property.NameEquals("nestedModel"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nestedModel = NestedModel.DeserializeNestedModel(property.Value);
                    continue;
                }
                if (property.NameEquals("intArray"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<int> array0 = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array0.Add(item.GetInt32());
                    }
                    intArray = array0;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ResourcePatch(description.Value, Optional.ToDictionary(map), Optional.ToList(array), nestedModel.Value, Optional.ToList(intArray), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ResourcePatch>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourcePatch>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ResourcePatch)} does not support '{options.Format}' format.");
            }
        }

        ResourcePatch IPersistableModel<ResourcePatch>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourcePatch>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeResourcePatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ResourcePatch)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ResourcePatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ResourcePatch FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeResourcePatch(document.RootElement);
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
