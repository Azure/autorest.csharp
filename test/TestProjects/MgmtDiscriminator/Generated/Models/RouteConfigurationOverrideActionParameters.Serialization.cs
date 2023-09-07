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
    public partial class RouteConfigurationOverrideActionParameters : IUtf8JsonSerializable, IModelJsonSerializable<RouteConfigurationOverrideActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RouteConfigurationOverrideActionParameters>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RouteConfigurationOverrideActionParameters>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            if (Optional.IsDefined(OriginGroupOverride))
            {
                writer.WritePropertyName("originGroupOverride"u8);
                if (OriginGroupOverride is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<OriginGroupOverride>)OriginGroupOverride).Serialize(writer, options);
                }
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

        internal static RouteConfigurationOverrideActionParameters DeserializeRouteConfigurationOverrideActionParameters(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            RouteConfigurationOverrideActionParametersTypeName typeName = default;
            Optional<OriginGroupOverride> originGroupOverride = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new RouteConfigurationOverrideActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("originGroupOverride"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    originGroupOverride = OriginGroupOverride.DeserializeOriginGroupOverride(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new RouteConfigurationOverrideActionParameters(typeName, originGroupOverride.Value, serializedAdditionalRawData);
        }

        RouteConfigurationOverrideActionParameters IModelJsonSerializable<RouteConfigurationOverrideActionParameters>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRouteConfigurationOverrideActionParameters(doc.RootElement, options);
        }

        BinaryData IModelSerializable<RouteConfigurationOverrideActionParameters>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        RouteConfigurationOverrideActionParameters IModelSerializable<RouteConfigurationOverrideActionParameters>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeRouteConfigurationOverrideActionParameters(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="RouteConfigurationOverrideActionParameters"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="RouteConfigurationOverrideActionParameters"/> to convert. </param>
        public static implicit operator RequestContent(RouteConfigurationOverrideActionParameters model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="RouteConfigurationOverrideActionParameters"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator RouteConfigurationOverrideActionParameters(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeRouteConfigurationOverrideActionParameters(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
