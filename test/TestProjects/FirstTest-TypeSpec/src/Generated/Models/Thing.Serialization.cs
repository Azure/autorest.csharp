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

namespace FirstTestTypeSpec.Models
{
    public partial class Thing : IUtf8JsonSerializable, IJsonModel<Thing>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Thing>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<Thing>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Thing>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Thing)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("requiredUnion"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(RequiredUnion);
#else
            using (JsonDocument document = JsonDocument.Parse(RequiredUnion))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("requiredLiteralString"u8);
            writer.WriteStringValue(RequiredLiteralString.ToString());
            writer.WritePropertyName("requiredLiteralInt"u8);
            writer.WriteNumberValue(RequiredLiteralInt.ToSerialInt32());
            writer.WritePropertyName("requiredLiteralFloat"u8);
            writer.WriteNumberValue(RequiredLiteralFloat.ToSerialSingle());
            writer.WritePropertyName("requiredLiteralBool"u8);
            writer.WriteBooleanValue(RequiredLiteralBool);
            if (Optional.IsDefined(OptionalLiteralString))
            {
                writer.WritePropertyName("optionalLiteralString"u8);
                writer.WriteStringValue(OptionalLiteralString.Value.ToString());
            }
            if (Optional.IsDefined(OptionalLiteralInt))
            {
                writer.WritePropertyName("optionalLiteralInt"u8);
                writer.WriteNumberValue(OptionalLiteralInt.Value.ToSerialInt32());
            }
            if (Optional.IsDefined(OptionalLiteralFloat))
            {
                writer.WritePropertyName("optionalLiteralFloat"u8);
                writer.WriteNumberValue(OptionalLiteralFloat.Value.ToSerialSingle());
            }
            if (Optional.IsDefined(OptionalLiteralBool))
            {
                writer.WritePropertyName("optionalLiteralBool"u8);
                writer.WriteBooleanValue(OptionalLiteralBool.Value);
            }
            writer.WritePropertyName("requiredBadDescription"u8);
            writer.WriteStringValue(RequiredBadDescription);
            if (Optional.IsCollectionDefined(OptionalNullableList))
            {
                if (OptionalNullableList != null)
                {
                    writer.WritePropertyName("optionalNullableList"u8);
                    writer.WriteStartArray();
                    foreach (var item in OptionalNullableList)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("optionalNullableList");
                }
            }
            if (RequiredNullableList != null && Optional.IsCollectionDefined(RequiredNullableList))
            {
                writer.WritePropertyName("requiredNullableList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredNullableList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("requiredNullableList");
            }
            writer.WritePropertyName("requiredFloatProperty"u8);
            writer.WriteNumberValue(RequiredFloatProperty);
            if (Optional.IsDefined(OptionalFloatProperty))
            {
                writer.WritePropertyName("optionalFloatProperty"u8);
                writer.WriteNumberValue(OptionalFloatProperty.Value);
            }
            writer.WritePropertyName("embeddingVector"u8);
            writer.WriteStartArray();
            foreach (var item in EmbeddingVector.Span)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(OptionalResourceId))
            {
                writer.WritePropertyName("optionalResourceId"u8);
                writer.WriteStringValue(OptionalResourceId);
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

        Thing IJsonModel<Thing>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Thing>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Thing)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeThing(document.RootElement, options);
        }

        internal static Thing DeserializeThing(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            BinaryData requiredUnion = default;
            ThingRequiredLiteralString requiredLiteralString = default;
            ThingRequiredLiteralInt requiredLiteralInt = default;
            ThingRequiredLiteralFloat requiredLiteralFloat = default;
            bool requiredLiteralBool = default;
            ThingOptionalLiteralString? optionalLiteralString = default;
            ThingOptionalLiteralInt? optionalLiteralInt = default;
            ThingOptionalLiteralFloat? optionalLiteralFloat = default;
            bool? optionalLiteralBool = default;
            string requiredBadDescription = default;
            IList<int> optionalNullableList = default;
            IList<int> requiredNullableList = default;
            double requiredFloatProperty = default;
            double? optionalFloatProperty = default;
            ReadOnlyMemory<int> embeddingVector = default;
            string optionalResourceId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredUnion"u8))
                {
                    requiredUnion = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("requiredLiteralString"u8))
                {
                    requiredLiteralString = new ThingRequiredLiteralString(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredLiteralInt"u8))
                {
                    requiredLiteralInt = new ThingRequiredLiteralInt(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("requiredLiteralFloat"u8))
                {
                    requiredLiteralFloat = new ThingRequiredLiteralFloat(property.Value.GetSingle());
                    continue;
                }
                if (property.NameEquals("requiredLiteralBool"u8))
                {
                    requiredLiteralBool = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("optionalLiteralString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalLiteralString = new ThingOptionalLiteralString(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("optionalLiteralInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalLiteralInt = new ThingOptionalLiteralInt(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("optionalLiteralFloat"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalLiteralFloat = new ThingOptionalLiteralFloat(property.Value.GetSingle());
                    continue;
                }
                if (property.NameEquals("optionalLiteralBool"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalLiteralBool = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("requiredBadDescription"u8))
                {
                    requiredBadDescription = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("optionalNullableList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        optionalNullableList = null;
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    optionalNullableList = array;
                    continue;
                }
                if (property.NameEquals("requiredNullableList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableList = null;
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredNullableList = array;
                    continue;
                }
                if (property.NameEquals("requiredFloatProperty"u8))
                {
                    requiredFloatProperty = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("optionalFloatProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalFloatProperty = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("embeddingVector"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    int[] array = new int[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetInt32();
                        index++;
                    }
                    embeddingVector = new ReadOnlyMemory<int>(array);
                    continue;
                }
                if (property.NameEquals("optionalResourceId"u8))
                {
                    optionalResourceId = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new Thing(
                name,
                requiredUnion,
                requiredLiteralString,
                requiredLiteralInt,
                requiredLiteralFloat,
                requiredLiteralBool,
                optionalLiteralString,
                optionalLiteralInt,
                optionalLiteralFloat,
                optionalLiteralBool,
                requiredBadDescription,
                optionalNullableList ?? new ChangeTrackingList<int>(),
                requiredNullableList,
                requiredFloatProperty,
                optionalFloatProperty,
                embeddingVector,
                optionalResourceId,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<Thing>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Thing>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(Thing)} does not support writing '{options.Format}' format.");
            }
        }

        Thing IPersistableModel<Thing>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Thing>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeThing(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(Thing)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<Thing>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static Thing FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeThing(document.RootElement);
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
