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

namespace MgmtExactMatchInheritance.Models
{
    public partial class ExactMatchModel2 : IUtf8JsonSerializable, IModelJsonSerializable<ExactMatchModel2>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ExactMatchModel2>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ExactMatchModel2>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ExactMatchModel2>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(New))
            {
                writer.WritePropertyName("new"u8);
                writer.WriteStringValue(New);
            }
            if (Optional.IsDefined(ID))
            {
                writer.WritePropertyName("iD"u8);
                writer.WriteStringValue(ID);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(ExactMatchModel7Type))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ExactMatchModel7Type);
            }
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static ExactMatchModel2 DeserializeExactMatchModel2(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> @new = default;
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<string> type = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("new"u8))
                {
                    @new = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("iD"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ExactMatchModel2(id.Value, name.Value, type.Value, @new.Value, serializedAdditionalRawData);
        }

        ExactMatchModel2 IModelJsonSerializable<ExactMatchModel2>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ExactMatchModel2>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeExactMatchModel2(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ExactMatchModel2>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ExactMatchModel2>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ExactMatchModel2 IModelSerializable<ExactMatchModel2>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ExactMatchModel2>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeExactMatchModel2(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ExactMatchModel2"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ExactMatchModel2"/> to convert. </param>
        public static implicit operator RequestContent(ExactMatchModel2 model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ExactMatchModel2"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ExactMatchModel2(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeExactMatchModel2(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
