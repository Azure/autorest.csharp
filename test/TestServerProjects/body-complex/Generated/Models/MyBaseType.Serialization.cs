// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace body_complex.Models
{
    public partial class MyBaseType : IUtf8JsonSerializable, IModelJsonSerializable<MyBaseType>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<MyBaseType>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<MyBaseType>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());
            if (Optional.IsDefined(PropB1))
            {
                writer.WritePropertyName("propB1"u8);
                writer.WriteStringValue(PropB1);
            }
            writer.WritePropertyName("helper"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(PropBH1))
            {
                writer.WritePropertyName("propBH1"u8);
                writer.WriteStringValue(PropBH1);
            }
            writer.WriteEndObject();
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

        internal static MyBaseType DeserializeMyBaseType(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Kind1": return MyDerivedType.DeserializeMyDerivedType(element);
                }
            }

            // Unknown type found so we will deserialize the base properties only
            MyKind kind = default;
            Optional<string> propB1 = default;
            Optional<string> propBH1 = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = new MyKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("propB1"u8))
                {
                    propB1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("helper"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("propBH1"u8))
                        {
                            propBH1 = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new UnknownMyBaseType(kind, propB1.Value, propBH1.Value, rawData);
        }

        MyBaseType IModelJsonSerializable<MyBaseType>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeMyBaseType(doc.RootElement, options);
        }

        BinaryData IModelSerializable<MyBaseType>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        MyBaseType IModelSerializable<MyBaseType>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeMyBaseType(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="MyBaseType"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="MyBaseType"/> to convert. </param>
        public static implicit operator RequestContent(MyBaseType model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="MyBaseType"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator MyBaseType(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeMyBaseType(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
