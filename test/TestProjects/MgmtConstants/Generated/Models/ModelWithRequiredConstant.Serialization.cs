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

namespace MgmtConstants.Models
{
    public partial class ModelWithRequiredConstant : IUtf8JsonSerializable, IModelJsonSerializable<ModelWithRequiredConstant>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelWithRequiredConstant>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ModelWithRequiredConstant>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("requiredStringConstant"u8);
            writer.WriteStringValue(RequiredStringConstant.ToString());
            writer.WritePropertyName("requiredIntConstant"u8);
            writer.WriteNumberValue(RequiredIntConstant.ToSerialInt32());
            writer.WritePropertyName("requiredBooleanConstant"u8);
            writer.WriteBooleanValue(RequiredBooleanConstant);
            writer.WritePropertyName("requiredFloatConstant"u8);
            writer.WriteNumberValue(RequiredFloatConstant.ToSerialSingle());
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

        internal static ModelWithRequiredConstant DeserializeModelWithRequiredConstant(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            StringConstant requiredStringConstant = default;
            IntConstant requiredIntConstant = default;
            bool requiredBooleanConstant = default;
            FloatConstant requiredFloatConstant = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredStringConstant"u8))
                {
                    requiredStringConstant = new StringConstant(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredIntConstant"u8))
                {
                    requiredIntConstant = new IntConstant(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("requiredBooleanConstant"u8))
                {
                    requiredBooleanConstant = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("requiredFloatConstant"u8))
                {
                    requiredFloatConstant = new FloatConstant(property.Value.GetSingle());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ModelWithRequiredConstant(requiredStringConstant, requiredIntConstant, requiredBooleanConstant, requiredFloatConstant, rawData);
        }

        ModelWithRequiredConstant IModelJsonSerializable<ModelWithRequiredConstant>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithRequiredConstant(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ModelWithRequiredConstant>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ModelWithRequiredConstant IModelSerializable<ModelWithRequiredConstant>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeModelWithRequiredConstant(doc.RootElement, options);
        }

        public static implicit operator RequestContent(ModelWithRequiredConstant model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ModelWithRequiredConstant(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeModelWithRequiredConstant(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
