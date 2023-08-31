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

namespace MgmtScopeResource.Models
{
    public partial class DeploymentWhatIfProperties : IUtf8JsonSerializable, IModelJsonSerializable<DeploymentWhatIfProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DeploymentWhatIfProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DeploymentWhatIfProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeploymentWhatIfProperties>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(WhatIfSettings))
            {
                writer.WritePropertyName("whatIfSettings"u8);
                ((IModelJsonSerializable<DeploymentWhatIfSettings>)WhatIfSettings).Serialize(writer, options);
            }
            if (Optional.IsDefined(Template))
            {
                writer.WritePropertyName("template"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Template);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(Template.ToString()).RootElement);
#endif
            }
            if (Optional.IsDefined(Parameters))
            {
                writer.WritePropertyName("parameters"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Parameters);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(Parameters.ToString()).RootElement);
#endif
            }
            writer.WritePropertyName("mode"u8);
            writer.WriteStringValue(Mode.ToSerialString());
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

        internal static DeploymentWhatIfProperties DeserializeDeploymentWhatIfProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DeploymentWhatIfSettings> whatIfSettings = default;
            Optional<BinaryData> template = default;
            Optional<BinaryData> parameters = default;
            DeploymentMode mode = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("whatIfSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    whatIfSettings = DeploymentWhatIfSettings.DeserializeDeploymentWhatIfSettings(property.Value);
                    continue;
                }
                if (property.NameEquals("template"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    template = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("parameters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    parameters = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("mode"u8))
                {
                    mode = property.Value.GetString().ToDeploymentMode();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DeploymentWhatIfProperties(template.Value, parameters.Value, mode, whatIfSettings.Value, rawData);
        }

        DeploymentWhatIfProperties IModelJsonSerializable<DeploymentWhatIfProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeploymentWhatIfProperties>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDeploymentWhatIfProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DeploymentWhatIfProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeploymentWhatIfProperties>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DeploymentWhatIfProperties IModelSerializable<DeploymentWhatIfProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DeploymentWhatIfProperties>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDeploymentWhatIfProperties(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="DeploymentWhatIfProperties"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="DeploymentWhatIfProperties"/> to convert. </param>
        public static implicit operator RequestContent(DeploymentWhatIfProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="DeploymentWhatIfProperties"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator DeploymentWhatIfProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDeploymentWhatIfProperties(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
