// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text.Json;

namespace NoTestTypeSpec.Models
{
    public partial class Thing : IUtf8JsonWriteable, IJsonModel<Thing>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<Thing>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<Thing>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
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
            if (OptionalProperty.IsDefined(OptionalLiteralString))
            {
                writer.WritePropertyName("optionalLiteralString"u8);
                writer.WriteStringValue(OptionalLiteralString.Value.ToString());
            }
            if (OptionalProperty.IsDefined(OptionalLiteralInt))
            {
                writer.WritePropertyName("optionalLiteralInt"u8);
                writer.WriteNumberValue(OptionalLiteralInt.Value.ToSerialInt32());
            }
            if (OptionalProperty.IsDefined(OptionalLiteralFloat))
            {
                writer.WritePropertyName("optionalLiteralFloat"u8);
                writer.WriteNumberValue(OptionalLiteralFloat.Value.ToSerialSingle());
            }
            if (OptionalProperty.IsDefined(OptionalLiteralBool))
            {
                writer.WritePropertyName("optionalLiteralBool"u8);
                writer.WriteBooleanValue(OptionalLiteralBool.Value);
            }
            writer.WritePropertyName("requiredBadDescription"u8);
            writer.WriteStringValue(RequiredBadDescription);
            if (OptionalProperty.IsCollectionDefined(OptionalNullableList))
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
            if (RequiredNullableList != null && OptionalProperty.IsCollectionDefined(RequiredNullableList))
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

        Thing IJsonModel<Thing>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeThing(document.RootElement, options);
        }

        internal static Thing DeserializeThing(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

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
            OptionalProperty<ThingOptionalLiteralString> optionalLiteralString = default;
            OptionalProperty<ThingOptionalLiteralInt> optionalLiteralInt = default;
            OptionalProperty<ThingOptionalLiteralFloat> optionalLiteralFloat = default;
            OptionalProperty<bool> optionalLiteralBool = default;
            string requiredBadDescription = default;
            OptionalProperty<IReadOnlyList<int>> optionalNullableList = default;
            IReadOnlyList<int> requiredNullableList = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Thing(name, requiredUnion, requiredLiteralString, requiredLiteralInt, requiredLiteralFloat, requiredLiteralBool, OptionalProperty.ToNullable(optionalLiteralString), OptionalProperty.ToNullable(optionalLiteralInt), OptionalProperty.ToNullable(optionalLiteralFloat), OptionalProperty.ToNullable(optionalLiteralBool), requiredBadDescription, OptionalProperty.ToList(optionalNullableList), requiredNullableList, serializedAdditionalRawData);
        }

        BinaryData IModel<Thing>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        Thing IModel<Thing>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeThing(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<Thing>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static Thing FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeThing(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual RequestBody ToRequestBody()
        {
            var content = new Utf8JsonRequestBody();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
