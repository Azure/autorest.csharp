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

namespace ModelShapes.Models
{
    public partial class MixedModel : IUtf8JsonSerializable, IJsonModel<MixedModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MixedModel>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MixedModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MixedModel)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("RequiredString"u8);
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("RequiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("RequiredStringList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredStringList)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("RequiredIntList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredIntList)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(NonRequiredString))
            {
                writer.WritePropertyName("NonRequiredString"u8);
                writer.WriteStringValue(NonRequiredString);
            }
            if (Optional.IsDefined(NonRequiredInt))
            {
                writer.WritePropertyName("NonRequiredInt"u8);
                writer.WriteNumberValue(NonRequiredInt.Value);
            }
            if (Optional.IsCollectionDefined(NonRequiredStringList))
            {
                writer.WritePropertyName("NonRequiredStringList"u8);
                writer.WriteStartArray();
                foreach (var item in NonRequiredStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(NonRequiredIntList))
            {
                writer.WritePropertyName("NonRequiredIntList"u8);
                writer.WriteStartArray();
                foreach (var item in NonRequiredIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (RequiredNullableString != null)
            {
                writer.WritePropertyName("RequiredNullableString"u8);
                writer.WriteStringValue(RequiredNullableString);
            }
            else
            {
                writer.WriteNull("RequiredNullableString");
            }
            if (RequiredNullableInt != null)
            {
                writer.WritePropertyName("RequiredNullableInt"u8);
                writer.WriteNumberValue(RequiredNullableInt.Value);
            }
            else
            {
                writer.WriteNull("RequiredNullableInt");
            }
            if (RequiredNullableStringList != null && Optional.IsCollectionDefined(RequiredNullableStringList))
            {
                writer.WritePropertyName("RequiredNullableStringList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredNullableStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("RequiredNullableStringList");
            }
            if (RequiredNullableIntList != null && Optional.IsCollectionDefined(RequiredNullableIntList))
            {
                writer.WritePropertyName("RequiredNullableIntList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredNullableIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("RequiredNullableIntList");
            }
            if (Optional.IsDefined(NonRequiredNullableString))
            {
                if (NonRequiredNullableString != null)
                {
                    writer.WritePropertyName("NonRequiredNullableString"u8);
                    writer.WriteStringValue(NonRequiredNullableString);
                }
                else
                {
                    writer.WriteNull("NonRequiredNullableString");
                }
            }
            if (Optional.IsDefined(NonRequiredNullableInt))
            {
                if (NonRequiredNullableInt != null)
                {
                    writer.WritePropertyName("NonRequiredNullableInt"u8);
                    writer.WriteNumberValue(NonRequiredNullableInt.Value);
                }
                else
                {
                    writer.WriteNull("NonRequiredNullableInt");
                }
            }
            if (Optional.IsCollectionDefined(NonRequiredNullableStringList))
            {
                if (NonRequiredNullableStringList != null)
                {
                    writer.WritePropertyName("NonRequiredNullableStringList"u8);
                    writer.WriteStartArray();
                    foreach (var item in NonRequiredNullableStringList)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("NonRequiredNullableStringList");
                }
            }
            if (Optional.IsCollectionDefined(NonRequiredNullableIntList))
            {
                if (NonRequiredNullableIntList != null)
                {
                    writer.WritePropertyName("NonRequiredNullableIntList"u8);
                    writer.WriteStartArray();
                    foreach (var item in NonRequiredNullableIntList)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("NonRequiredNullableIntList");
                }
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("RequiredReadonlyInt"u8);
                writer.WriteNumberValue(RequiredReadonlyInt);
            }
            if (options.Format != "W" && Optional.IsDefined(NonRequiredReadonlyInt))
            {
                writer.WritePropertyName("NonRequiredReadonlyInt"u8);
                writer.WriteNumberValue(NonRequiredReadonlyInt.Value);
            }
            writer.WritePropertyName("vector"u8);
            writer.WriteStartArray();
            foreach (var item in Vector.Span)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (options.Format != "W")
            {
                writer.WritePropertyName("vectorReadOnly"u8);
                writer.WriteStartArray();
                foreach (var item in VectorReadOnly.Span)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("vectorReadOnlyRequired"u8);
                writer.WriteStartArray();
                foreach (var item in VectorReadOnlyRequired.Span)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("vectorRequired"u8);
            writer.WriteStartArray();
            foreach (var item in VectorRequired.Span)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(VectorNullable))
            {
                if (VectorNullable != null)
                {
                    writer.WritePropertyName("vectorNullable"u8);
                    writer.WriteStartArray();
                    foreach (var item in VectorNullable.Value.Span)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("vectorNullable");
                }
            }
            if (options.Format != "W" && Optional.IsDefined(VectorReadOnlyNullable))
            {
                if (VectorReadOnlyNullable != null)
                {
                    writer.WritePropertyName("vectorReadOnlyNullable"u8);
                    writer.WriteStartArray();
                    foreach (var item in VectorReadOnlyNullable.Value.Span)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("vectorReadOnlyNullable");
                }
            }
            if (options.Format != "W")
            {
                if (VectorReadOnlyRequiredNullable != null)
                {
                    writer.WritePropertyName("vectorReadOnlyRequiredNullable"u8);
                    writer.WriteStartArray();
                    foreach (var item in VectorReadOnlyRequiredNullable.Value.Span)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("vectorReadOnlyRequiredNullable");
                }
            }
            if (VectorRequiredNullable != null)
            {
                writer.WritePropertyName("vectorRequiredNullable"u8);
                writer.WriteStartArray();
                foreach (var item in VectorRequiredNullable.Value.Span)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("vectorRequiredNullable");
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        MixedModel IJsonModel<MixedModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MixedModel)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMixedModel(document.RootElement, options);
        }

        internal static MixedModel DeserializeMixedModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredString = default;
            int requiredInt = default;
            IList<string> requiredStringList = default;
            IList<int> requiredIntList = default;
            string nonRequiredString = default;
            int? nonRequiredInt = default;
            IList<string> nonRequiredStringList = default;
            IList<int> nonRequiredIntList = default;
            string requiredNullableString = default;
            int? requiredNullableInt = default;
            IList<string> requiredNullableStringList = default;
            IList<int> requiredNullableIntList = default;
            string nonRequiredNullableString = default;
            int? nonRequiredNullableInt = default;
            IList<string> nonRequiredNullableStringList = default;
            IList<int> nonRequiredNullableIntList = default;
            int requiredReadonlyInt = default;
            int? nonRequiredReadonlyInt = default;
            ReadOnlyMemory<float> vector = default;
            ReadOnlyMemory<float> vectorReadOnly = default;
            ReadOnlyMemory<float> vectorReadOnlyRequired = default;
            ReadOnlyMemory<float> vectorRequired = default;
            ReadOnlyMemory<float>? vectorNullable = default;
            ReadOnlyMemory<float>? vectorReadOnlyNullable = default;
            ReadOnlyMemory<float>? vectorReadOnlyRequiredNullable = default;
            ReadOnlyMemory<float>? vectorRequiredNullable = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("RequiredString"u8))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("RequiredInt"u8))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("RequiredStringList"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredStringList = array;
                    continue;
                }
                if (property.NameEquals("RequiredIntList"u8))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredIntList = array;
                    continue;
                }
                if (property.NameEquals("NonRequiredString"u8))
                {
                    nonRequiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("NonRequiredInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nonRequiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("NonRequiredStringList"u8))
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
                    nonRequiredStringList = array;
                    continue;
                }
                if (property.NameEquals("NonRequiredIntList"u8))
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
                    nonRequiredIntList = array;
                    continue;
                }
                if (property.NameEquals("RequiredNullableString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableString = null;
                        continue;
                    }
                    requiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("RequiredNullableInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableInt = null;
                        continue;
                    }
                    requiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("RequiredNullableStringList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableStringList = new ChangeTrackingList<string>();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredNullableStringList = array;
                    continue;
                }
                if (property.NameEquals("RequiredNullableIntList"u8))
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
                if (property.NameEquals("NonRequiredNullableString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableString = null;
                        continue;
                    }
                    nonRequiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("NonRequiredNullableInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableInt = null;
                        continue;
                    }
                    nonRequiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("NonRequiredNullableStringList"u8))
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
                    nonRequiredNullableStringList = array;
                    continue;
                }
                if (property.NameEquals("NonRequiredNullableIntList"u8))
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
                    nonRequiredNullableIntList = array;
                    continue;
                }
                if (property.NameEquals("RequiredReadonlyInt"u8))
                {
                    requiredReadonlyInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("NonRequiredReadonlyInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nonRequiredReadonlyInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("vector"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vector = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorReadOnly"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorReadOnly = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorReadOnlyRequired"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorReadOnlyRequired = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorRequired"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorRequired = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorNullable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorNullable = new ReadOnlyMemory<float>?(array);
                    continue;
                }
                if (property.NameEquals("vectorReadOnlyNullable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorReadOnlyNullable = new ReadOnlyMemory<float>?(array);
                    continue;
                }
                if (property.NameEquals("vectorReadOnlyRequiredNullable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorReadOnlyRequiredNullable = new ReadOnlyMemory<float>?(array);
                    continue;
                }
                if (property.NameEquals("vectorRequiredNullable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorRequiredNullable = new ReadOnlyMemory<float>?(array);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MixedModel(
                requiredString,
                requiredInt,
                requiredStringList,
                requiredIntList,
                nonRequiredString,
                nonRequiredInt,
                nonRequiredStringList ?? new ChangeTrackingList<string>(),
                nonRequiredIntList ?? new ChangeTrackingList<int>(),
                requiredNullableString,
                requiredNullableInt,
                requiredNullableStringList,
                requiredNullableIntList,
                nonRequiredNullableString,
                nonRequiredNullableInt,
                nonRequiredNullableStringList ?? new ChangeTrackingList<string>(),
                nonRequiredNullableIntList ?? new ChangeTrackingList<int>(),
                requiredReadonlyInt,
                nonRequiredReadonlyInt,
                vector,
                vectorReadOnly,
                vectorReadOnlyRequired,
                vectorRequired,
                vectorNullable,
                vectorReadOnlyNullable,
                vectorReadOnlyRequiredNullable,
                vectorRequiredNullable,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MixedModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, ModelShapesContext.Default);
                default:
                    throw new FormatException($"The model {nameof(MixedModel)} does not support writing '{options.Format}' format.");
            }
        }

        MixedModel IPersistableModel<MixedModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeMixedModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MixedModel)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MixedModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MixedModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMixedModel(document.RootElement);
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
