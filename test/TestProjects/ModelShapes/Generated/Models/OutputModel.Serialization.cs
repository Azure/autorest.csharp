// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace ModelShapes.Models
{
    public partial class OutputModel : IUtf8JsonSerializable, IJsonModel<OutputModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OutputModel>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<OutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OutputModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OutputModel)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
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
            if (NonRequiredString != null)
            {
                writer.WritePropertyName("NonRequiredString"u8);
                writer.WriteStringValue(NonRequiredString);
            }
            if (NonRequiredInt.HasValue)
            {
                writer.WritePropertyName("NonRequiredInt"u8);
                writer.WriteNumberValue(NonRequiredInt.Value);
            }
            if (!(NonRequiredStringList is ChangeTrackingList<string> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("NonRequiredStringList"u8);
                writer.WriteStartArray();
                foreach (var item in NonRequiredStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(NonRequiredIntList is ChangeTrackingList<int> collection0 && collection0.IsUndefined))
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
            if (RequiredNullableStringList != null && !(RequiredNullableStringList is ChangeTrackingList<string> collection1 && collection1.IsUndefined))
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
            if (RequiredNullableIntList != null && !(RequiredNullableIntList is ChangeTrackingList<int> collection2 && collection2.IsUndefined))
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
            if (NonRequiredNullableString != null)
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
            if (NonRequiredNullableInt.HasValue)
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
            if (!(NonRequiredNullableStringList is ChangeTrackingList<string> collection3 && collection3.IsUndefined))
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
            if (!(NonRequiredNullableIntList is ChangeTrackingList<int> collection4 && collection4.IsUndefined))
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
            if (options.Format != "W" && NonRequiredReadonlyInt.HasValue)
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
            if (VectorNullable.HasValue)
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
            if (options.Format != "W" && VectorReadOnlyNullable.HasValue)
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
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        OutputModel IJsonModel<OutputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OutputModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OutputModel)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOutputModel(document.RootElement, options);
        }

        internal static OutputModel DeserializeOutputModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredString = default;
            int requiredInt = default;
            IReadOnlyList<string> requiredStringList = default;
            IReadOnlyList<int> requiredIntList = default;
            Optional<string> nonRequiredString = default;
            Optional<int> nonRequiredInt = default;
            IReadOnlyList<string> nonRequiredStringList = default;
            IReadOnlyList<int> nonRequiredIntList = default;
            string requiredNullableString = default;
            int? requiredNullableInt = default;
            IReadOnlyList<string> requiredNullableStringList = default;
            IReadOnlyList<int> requiredNullableIntList = default;
            Optional<string> nonRequiredNullableString = default;
            Optional<int?> nonRequiredNullableInt = default;
            IReadOnlyList<string> nonRequiredNullableStringList = default;
            IReadOnlyList<int> nonRequiredNullableIntList = default;
            int requiredReadonlyInt = default;
            Optional<int> nonRequiredReadonlyInt = default;
            ReadOnlyMemory<float> vector = default;
            ReadOnlyMemory<float> vectorReadOnly = default;
            ReadOnlyMemory<float> vectorReadOnlyRequired = default;
            ReadOnlyMemory<float> vectorRequired = default;
            ReadOnlyMemory<float>? vectorNullable = default;
            ReadOnlyMemory<float>? vectorReadOnlyNullable = default;
            ReadOnlyMemory<float>? vectorReadOnlyRequiredNullable = default;
            ReadOnlyMemory<float>? vectorRequiredNullable = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new OutputModel(requiredString, requiredInt, requiredStringList ?? new ChangeTrackingList<string>(), requiredIntList ?? new ChangeTrackingList<int>(), nonRequiredString.Value, Optional.ToNullable(nonRequiredInt), nonRequiredStringList ?? new ChangeTrackingList<string>(), nonRequiredIntList ?? new ChangeTrackingList<int>(), requiredNullableString, requiredNullableInt, requiredNullableStringList ?? new ChangeTrackingList<string>(), requiredNullableIntList ?? new ChangeTrackingList<int>(), nonRequiredNullableString.Value, Optional.ToNullable(nonRequiredNullableInt), nonRequiredNullableStringList ?? new ChangeTrackingList<string>(), nonRequiredNullableIntList ?? new ChangeTrackingList<int>(), requiredReadonlyInt, Optional.ToNullable(nonRequiredReadonlyInt), vector, vectorReadOnly, vectorReadOnlyRequired, vectorRequired, vectorNullable, vectorReadOnlyNullable, vectorReadOnlyRequiredNullable, vectorRequiredNullable, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<OutputModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OutputModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(OutputModel)} does not support '{options.Format}' format.");
            }
        }

        OutputModel IPersistableModel<OutputModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OutputModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOutputModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OutputModel)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<OutputModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
