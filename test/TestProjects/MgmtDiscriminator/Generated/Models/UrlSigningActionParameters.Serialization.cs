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

namespace MgmtDiscriminator.Models
{
    public partial class UrlSigningActionParameters : IUtf8JsonSerializable, IModelJsonSerializable<UrlSigningActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<UrlSigningActionParameters>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<UrlSigningActionParameters>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            if (Optional.IsDefined(Algorithm))
            {
                writer.WritePropertyName("algorithm"u8);
                writer.WriteStringValue(Algorithm.Value.ToString());
            }
            if (Optional.IsCollectionDefined(ParameterNameOverride))
            {
                writer.WritePropertyName("parameterNameOverride"u8);
                writer.WriteStartArray();
                foreach (var item in ParameterNameOverride)
                {
                    if (item is null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        ((IModelJsonSerializable<UrlSigningParamIdentifier>)item).Serialize(writer, options);
                    }
                }
                writer.WriteEndArray();
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

        internal static UrlSigningActionParameters DeserializeUrlSigningActionParameters(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            UrlSigningActionParametersTypeName typeName = default;
            Optional<Algorithm> algorithm = default;
            Optional<IList<UrlSigningParamIdentifier>> parameterNameOverride = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new UrlSigningActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("algorithm"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    algorithm = new Algorithm(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("parameterNameOverride"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<UrlSigningParamIdentifier> array = new List<UrlSigningParamIdentifier>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(UrlSigningParamIdentifier.DeserializeUrlSigningParamIdentifier(item));
                    }
                    parameterNameOverride = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new UrlSigningActionParameters(typeName, Optional.ToNullable(algorithm), Optional.ToList(parameterNameOverride), serializedAdditionalRawData);
        }

        UrlSigningActionParameters IModelJsonSerializable<UrlSigningActionParameters>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUrlSigningActionParameters(doc.RootElement, options);
        }

        BinaryData IModelSerializable<UrlSigningActionParameters>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        UrlSigningActionParameters IModelSerializable<UrlSigningActionParameters>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeUrlSigningActionParameters(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="UrlSigningActionParameters"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="UrlSigningActionParameters"/> to convert. </param>
        public static implicit operator RequestContent(UrlSigningActionParameters model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="UrlSigningActionParameters"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator UrlSigningActionParameters(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeUrlSigningActionParameters(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
