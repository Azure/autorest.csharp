// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace ModelWithConverterUsage.Models
{
    [JsonConverter(typeof(ModelClassConverter))]
    public partial class ModelClass : IUtf8JsonSerializable, IModelJsonSerializable<ModelClass>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelClass>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ModelClass>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(StringProperty))
            {
                writer.WritePropertyName("String_Property"u8);
                writer.WriteStringValue(StringProperty);
            }
            writer.WritePropertyName("Enum_Property"u8);
            writer.WriteStringValue(EnumProperty.ToSerialString());
            if (Optional.IsDefined(ObjProperty))
            {
                writer.WritePropertyName("Obj_Property"u8);
                if (ObjProperty is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<Product>)ObjProperty).Serialize(writer, options);
                }
            }
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static ModelClass DeserializeModelClass(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> stringProperty = default;
            EnumProperty enumProperty = default;
            Optional<Product> objProperty = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("String_Property"u8))
                {
                    stringProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Enum_Property"u8))
                {
                    enumProperty = property.Value.GetString().ToEnumProperty();
                    continue;
                }
                if (property.NameEquals("Obj_Property"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    objProperty = Product.DeserializeProduct(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ModelClass(stringProperty.Value, enumProperty, objProperty.Value, rawData);
        }

        ModelClass IModelJsonSerializable<ModelClass>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelClass(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ModelClass>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ModelClass IModelSerializable<ModelClass>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeModelClass(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ModelClass"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ModelClass"/> to convert. </param>
        public static implicit operator RequestContent(ModelClass model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ModelClass"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ModelClass(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeModelClass(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        internal partial class ModelClassConverter : JsonConverter<ModelClass>
        {
            public override void Write(Utf8JsonWriter writer, ModelClass model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ModelClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeModelClass(document.RootElement);
            }
        }
    }
}
