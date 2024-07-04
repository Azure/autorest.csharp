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

namespace _Type.Model.Visibility.Models
{
    public partial class ReadOnlyModel : IUtf8JsonSerializable, IJsonModel<ReadOnlyModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ReadOnlyModel>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ReadOnlyModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ReadOnlyModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ReadOnlyModel)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W")
            {
                if (RequiredNullableIntList != null && Optional.IsCollectionDefined(RequiredNullableIntList))
                {
                    writer.WritePropertyName("requiredNullableIntList"u8);
                    writer.WriteStartArray();
                    foreach (var item in RequiredNullableIntList)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("requiredNullableIntList");
                }
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(OptionalNullableIntList))
            {
                if (OptionalNullableIntList != null)
                {
                    writer.WritePropertyName("optionalNullableIntList"u8);
                    writer.WriteStartArray();
                    foreach (var item in OptionalNullableIntList)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("optionalNullableIntList");
                }
            }
            if (options.Format != "W")
            {
                if (RequiredNullableModelList != null && Optional.IsCollectionDefined(RequiredNullableModelList))
                {
                    writer.WritePropertyName("requiredNullableModelList"u8);
                    writer.WriteStartArray();
                    foreach (var item in RequiredNullableModelList)
                    {
                        writer.WriteObjectValue(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("requiredNullableModelList");
                }
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(OptionalNullableModelList))
            {
                if (OptionalNullableModelList != null)
                {
                    writer.WritePropertyName("optionalNullableModelList"u8);
                    writer.WriteStartArray();
                    foreach (var item in OptionalNullableModelList)
                    {
                        writer.WriteObjectValue(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("optionalNullableModelList");
                }
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("requiredStringRecord"u8);
                writer.WriteStartObject();
                foreach (var item in RequiredStringRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(OptionalStringRecord))
            {
                writer.WritePropertyName("optionalStringRecord"u8);
                writer.WriteStartObject();
                foreach (var item in OptionalStringRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("requiredModelRecord"u8);
                writer.WriteStartObject();
                foreach (var item in RequiredModelRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value, options);
                }
                writer.WriteEndObject();
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(OptionalModelRecord))
            {
                writer.WritePropertyName("optionalModelRecord"u8);
                writer.WriteStartObject();
                foreach (var item in OptionalModelRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value, options);
                }
                writer.WriteEndObject();
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

        ReadOnlyModel IJsonModel<ReadOnlyModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ReadOnlyModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ReadOnlyModel)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeReadOnlyModel(document.RootElement, options);
        }

        internal static ReadOnlyModel DeserializeReadOnlyModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<int> requiredNullableIntList = default;
            IReadOnlyList<int> optionalNullableIntList = default;
            IReadOnlyList<InnerModel> requiredNullableModelList = default;
            IReadOnlyList<InnerModel> optionalNullableModelList = default;
            IReadOnlyDictionary<string, string> requiredStringRecord = default;
            IReadOnlyDictionary<string, string> optionalStringRecord = default;
            IReadOnlyDictionary<string, InnerModel> requiredModelRecord = default;
            IReadOnlyDictionary<string, InnerModel> optionalModelRecord = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredNullableIntList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableIntList = new ChangeTrackingList<int>();
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredNullableIntList = array;
                    continue;
                }
                if (property.NameEquals("optionalNullableIntList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    optionalNullableIntList = array;
                    continue;
                }
                if (property.NameEquals("requiredNullableModelList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableModelList = new ChangeTrackingList<InnerModel>();
                        continue;
                    }
                    List<InnerModel> array = new List<InnerModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InnerModel.DeserializeInnerModel(item, options));
                    }
                    requiredNullableModelList = array;
                    continue;
                }
                if (property.NameEquals("optionalNullableModelList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InnerModel> array = new List<InnerModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InnerModel.DeserializeInnerModel(item, options));
                    }
                    optionalNullableModelList = array;
                    continue;
                }
                if (property.NameEquals("requiredStringRecord"u8))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    requiredStringRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("optionalStringRecord"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    optionalStringRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("requiredModelRecord"u8))
                {
                    Dictionary<string, InnerModel> dictionary = new Dictionary<string, InnerModel>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, InnerModel.DeserializeInnerModel(property0.Value, options));
                    }
                    requiredModelRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("optionalModelRecord"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, InnerModel> dictionary = new Dictionary<string, InnerModel>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, InnerModel.DeserializeInnerModel(property0.Value, options));
                    }
                    optionalModelRecord = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ReadOnlyModel(
                requiredNullableIntList,
                optionalNullableIntList ?? new ChangeTrackingList<int>(),
                requiredNullableModelList,
                optionalNullableModelList ?? new ChangeTrackingList<InnerModel>(),
                requiredStringRecord,
                optionalStringRecord ?? new ChangeTrackingDictionary<string, string>(),
                requiredModelRecord,
                optionalModelRecord ?? new ChangeTrackingDictionary<string, InnerModel>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ReadOnlyModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ReadOnlyModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ReadOnlyModel)} does not support writing '{options.Format}' format.");
            }
        }

        ReadOnlyModel IPersistableModel<ReadOnlyModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ReadOnlyModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeReadOnlyModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ReadOnlyModel)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ReadOnlyModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ReadOnlyModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeReadOnlyModel(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
