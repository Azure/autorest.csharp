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
    public partial class RoundTripModel : IUtf8JsonSerializable, IJsonModel<RoundTripModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RoundTripModel>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<RoundTripModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredString"u8);
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            if (Optional.IsDefined(NonRequiredString))
            {
                writer.WritePropertyName("nonRequiredString"u8);
                writer.WriteStringValue(NonRequiredString);
            }
            if (Optional.IsDefined(NonRequiredInt))
            {
                writer.WritePropertyName("nonRequiredInt"u8);
                writer.WriteNumberValue(NonRequiredInt.Value);
            }
            if (RequiredNullableInt != null)
            {
                writer.WritePropertyName("requiredNullableInt"u8);
                writer.WriteNumberValue(RequiredNullableInt.Value);
            }
            else
            {
                writer.WriteNull("requiredNullableInt");
            }
            if (RequiredNullableString != null)
            {
                writer.WritePropertyName("requiredNullableString"u8);
                writer.WriteStringValue(RequiredNullableString);
            }
            else
            {
                writer.WriteNull("requiredNullableString");
            }
            if (Optional.IsDefined(NonRequiredNullableInt))
            {
                if (NonRequiredNullableInt != null)
                {
                    writer.WritePropertyName("nonRequiredNullableInt"u8);
                    writer.WriteNumberValue(NonRequiredNullableInt.Value);
                }
                else
                {
                    writer.WriteNull("nonRequiredNullableInt");
                }
            }
            if (Optional.IsDefined(NonRequiredNullableString))
            {
                if (NonRequiredNullableString != null)
                {
                    writer.WritePropertyName("nonRequiredNullableString"u8);
                    writer.WriteStringValue(NonRequiredNullableString);
                }
                else
                {
                    writer.WriteNull("nonRequiredNullableString");
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("requiredReadonlyInt"u8);
                writer.WriteNumberValue(RequiredReadonlyInt);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(NonRequiredReadonlyInt))
                {
                    writer.WritePropertyName("nonRequiredReadonlyInt"u8);
                    writer.WriteNumberValue(NonRequiredReadonlyInt.Value);
                }
            }
            writer.WritePropertyName("requiredModel"u8);
            writer.WriteObjectValue(RequiredModel);
            writer.WritePropertyName("requiredFixedStringEnum"u8);
            writer.WriteStringValue(RequiredFixedStringEnum.ToSerialString());
            writer.WritePropertyName("requiredFixedIntEnum"u8);
            writer.WriteNumberValue((int)RequiredFixedIntEnum);
            writer.WritePropertyName("requiredExtensibleEnum"u8);
            writer.WriteStringValue(RequiredExtensibleEnum.ToString());
            writer.WritePropertyName("requiredList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredList)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredIntRecord"u8);
            writer.WriteStartObject();
            foreach (var item in RequiredIntRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteNumberValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("requiredStringRecord"u8);
            writer.WriteStartObject();
            foreach (var item in RequiredStringRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("requiredModelRecord"u8);
            writer.WriteStartObject();
            foreach (var item in RequiredModelRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("requiredBytes"u8);
            writer.WriteBase64StringValue(RequiredBytes.ToArray(), "D");
            if (Optional.IsDefined(OptionalBytes))
            {
                writer.WritePropertyName("optionalBytes"u8);
                writer.WriteBase64StringValue(OptionalBytes.ToArray(), "D");
            }
            writer.WritePropertyName("requiredUint8Array"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredUint8Array)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsCollectionDefined(OptionalUint8Array))
            {
                writer.WritePropertyName("optionalUint8Array"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalUint8Array)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("requiredUnknown"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(RequiredUnknown);
#else
            using (JsonDocument document = JsonDocument.Parse(RequiredUnknown))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            if (Optional.IsDefined(OptionalUnknown))
            {
                writer.WritePropertyName("optionalUnknown"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(OptionalUnknown);
#else
                using (JsonDocument document = JsonDocument.Parse(OptionalUnknown))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            writer.WritePropertyName("requiredInt8Array"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredInt8Array)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsCollectionDefined(OptionalInt8Array))
            {
                writer.WritePropertyName("optionalInt8Array"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalInt8Array)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
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
            if (RequiredNullableStringList != null && Optional.IsCollectionDefined(RequiredNullableStringList))
            {
                writer.WritePropertyName("requiredNullableStringList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredNullableStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("requiredNullableStringList");
            }
            if (Optional.IsCollectionDefined(NonRequiredNullableIntList))
            {
                if (NonRequiredNullableIntList != null)
                {
                    writer.WritePropertyName("nonRequiredNullableIntList"u8);
                    writer.WriteStartArray();
                    foreach (var item in NonRequiredNullableIntList)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("nonRequiredNullableIntList");
                }
            }
            if (Optional.IsCollectionDefined(NonRequiredNullableStringList))
            {
                if (NonRequiredNullableStringList != null)
                {
                    writer.WritePropertyName("nonRequiredNullableStringList"u8);
                    writer.WriteStartArray();
                    foreach (var item in NonRequiredNullableStringList)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("nonRequiredNullableStringList");
                }
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

        RoundTripModel IJsonModel<RoundTripModel>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoundTripModel(document.RootElement, options);
        }

        internal static RoundTripModel DeserializeRoundTripModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredString = default;
            int requiredInt = default;
            Optional<string> nonRequiredString = default;
            Optional<int> nonRequiredInt = default;
            int? requiredNullableInt = default;
            string requiredNullableString = default;
            Optional<int?> nonRequiredNullableInt = default;
            Optional<string> nonRequiredNullableString = default;
            int requiredReadonlyInt = default;
            Optional<int> nonRequiredReadonlyInt = default;
            BaseModelWithDiscriminator requiredModel = default;
            FixedStringEnum requiredFixedStringEnum = default;
            FixedIntEnum requiredFixedIntEnum = default;
            ExtensibleEnum requiredExtensibleEnum = default;
            IList<CollectionItem> requiredList = default;
            IDictionary<string, int> requiredIntRecord = default;
            IDictionary<string, string> requiredStringRecord = default;
            IDictionary<string, RecordItem> requiredModelRecord = default;
            BinaryData requiredBytes = default;
            Optional<BinaryData> optionalBytes = default;
            IList<int> requiredUint8Array = default;
            Optional<IList<int>> optionalUint8Array = default;
            BinaryData requiredUnknown = default;
            Optional<BinaryData> optionalUnknown = default;
            IList<int> requiredInt8Array = default;
            Optional<IList<int>> optionalInt8Array = default;
            IList<int> requiredNullableIntList = default;
            IList<string> requiredNullableStringList = default;
            Optional<IList<int>> nonRequiredNullableIntList = default;
            Optional<IList<string>> nonRequiredNullableStringList = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredString"u8))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredInt"u8))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("nonRequiredString"u8))
                {
                    nonRequiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nonRequiredInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nonRequiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredNullableInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableInt = null;
                        continue;
                    }
                    requiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredNullableString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableString = null;
                        continue;
                    }
                    requiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nonRequiredNullableInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableInt = null;
                        continue;
                    }
                    nonRequiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("nonRequiredNullableString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableString = null;
                        continue;
                    }
                    nonRequiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredReadonlyInt"u8))
                {
                    requiredReadonlyInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("nonRequiredReadonlyInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nonRequiredReadonlyInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredModel"u8))
                {
                    requiredModel = BaseModelWithDiscriminator.DeserializeBaseModelWithDiscriminator(property.Value);
                    continue;
                }
                if (property.NameEquals("requiredFixedStringEnum"u8))
                {
                    requiredFixedStringEnum = property.Value.GetString().ToFixedStringEnum();
                    continue;
                }
                if (property.NameEquals("requiredFixedIntEnum"u8))
                {
                    requiredFixedIntEnum = property.Value.GetInt32().ToFixedIntEnum();
                    continue;
                }
                if (property.NameEquals("requiredExtensibleEnum"u8))
                {
                    requiredExtensibleEnum = new ExtensibleEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredList"u8))
                {
                    List<CollectionItem> array = new List<CollectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CollectionItem.DeserializeCollectionItem(item));
                    }
                    requiredList = array;
                    continue;
                }
                if (property.NameEquals("requiredIntRecord"u8))
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetInt32());
                    }
                    requiredIntRecord = dictionary;
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
                if (property.NameEquals("requiredModelRecord"u8))
                {
                    Dictionary<string, RecordItem> dictionary = new Dictionary<string, RecordItem>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, RecordItem.DeserializeRecordItem(property0.Value));
                    }
                    requiredModelRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("requiredBytes"u8))
                {
                    requiredBytes = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (property.NameEquals("optionalBytes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalBytes = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (property.NameEquals("requiredUint8Array"u8))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredUint8Array = array;
                    continue;
                }
                if (property.NameEquals("optionalUint8Array"u8))
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
                    optionalUint8Array = array;
                    continue;
                }
                if (property.NameEquals("requiredUnknown"u8))
                {
                    requiredUnknown = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("optionalUnknown"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalUnknown = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("requiredInt8Array"u8))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredInt8Array = array;
                    continue;
                }
                if (property.NameEquals("optionalInt8Array"u8))
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
                    optionalInt8Array = array;
                    continue;
                }
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
                if (property.NameEquals("requiredNullableStringList"u8))
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
                if (property.NameEquals("nonRequiredNullableIntList"u8))
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
                if (property.NameEquals("nonRequiredNullableStringList"u8))
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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RoundTripModel(serializedAdditionalRawData, requiredString, requiredInt, nonRequiredString.Value, Optional.ToNullable(nonRequiredInt), requiredNullableInt, requiredNullableString, Optional.ToNullable(nonRequiredNullableInt), nonRequiredNullableString.Value, requiredReadonlyInt, Optional.ToNullable(nonRequiredReadonlyInt), requiredModel, requiredFixedStringEnum, requiredFixedIntEnum, requiredExtensibleEnum, requiredList, requiredIntRecord, requiredStringRecord, requiredModelRecord, requiredBytes, optionalBytes.Value, requiredUint8Array, Optional.ToList(optionalUint8Array), requiredUnknown, optionalUnknown.Value, requiredInt8Array, Optional.ToList(optionalInt8Array), requiredNullableIntList, requiredNullableStringList, Optional.ToList(nonRequiredNullableIntList), Optional.ToList(nonRequiredNullableStringList));
        }

        BinaryData IModel<RoundTripModel>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        RoundTripModel IModel<RoundTripModel>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRoundTripModel(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<RoundTripModel>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new RoundTripModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRoundTripModel(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
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
