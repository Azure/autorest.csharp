// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace AdditionalPropertiesEx.Models
{
    public partial struct OutputAdditionalPropertiesModelStruct : IUtf8JsonSerializable, IModelJsonSerializable<OutputAdditionalPropertiesModelStruct>, IModelJsonSerializable<object>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<OutputAdditionalPropertiesModelStruct>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<OutputAdditionalPropertiesModelStruct>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteNumberValue(Id);
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
        }

        OutputAdditionalPropertiesModelStruct IModelJsonSerializable<OutputAdditionalPropertiesModelStruct>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeOutputAdditionalPropertiesModelStruct(doc.RootElement, options);
        }

        BinaryData IModelSerializable<OutputAdditionalPropertiesModelStruct>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        OutputAdditionalPropertiesModelStruct IModelSerializable<OutputAdditionalPropertiesModelStruct>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeOutputAdditionalPropertiesModelStruct(document.RootElement, options);
        }

        void IModelJsonSerializable<object>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => ((IModelJsonSerializable<OutputAdditionalPropertiesModelStruct>)this).Serialize(writer, options);

        object IModelJsonSerializable<object>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options) => ((IModelJsonSerializable<OutputAdditionalPropertiesModelStruct>)this).Deserialize(ref reader, options);

        BinaryData IModelSerializable<object>.Serialize(ModelSerializerOptions options) => ((IModelJsonSerializable<OutputAdditionalPropertiesModelStruct>)this).Serialize(options);

        object IModelSerializable<object>.Deserialize(BinaryData data, ModelSerializerOptions options) => ((IModelJsonSerializable<OutputAdditionalPropertiesModelStruct>)this).Deserialize(data, options);

        internal static OutputAdditionalPropertiesModelStruct DeserializeOutputAdditionalPropertiesModelStruct(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            int id = default;
            IReadOnlyDictionary<string, string> additionalProperties = default;
            Dictionary<string, string> additionalPropertiesDictionary = new Dictionary<string, string>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetInt32();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetString());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new OutputAdditionalPropertiesModelStruct(id, additionalProperties);
        }
    }
}
