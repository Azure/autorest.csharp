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
using MgmtPartialResource;

namespace MgmtPartialResource.Models
{
    internal partial class ConfigurationProfileAssignmentList : IUtf8JsonSerializable, IModelJsonSerializable<ConfigurationProfileAssignmentList>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ConfigurationProfileAssignmentList>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ConfigurationProfileAssignmentList>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStartArray();
                foreach (var item in Value)
                {
                    ((IModelJsonSerializable<ConfigurationProfileAssignmentData>)item).Serialize(writer, options);
                }
                writer.WriteEndArray();
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

        internal static ConfigurationProfileAssignmentList DeserializeConfigurationProfileAssignmentList(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<ConfigurationProfileAssignmentData>> value = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ConfigurationProfileAssignmentData> array = new List<ConfigurationProfileAssignmentData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConfigurationProfileAssignmentData.DeserializeConfigurationProfileAssignmentData(item));
                    }
                    value = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ConfigurationProfileAssignmentList(Optional.ToList(value), rawData);
        }

        ConfigurationProfileAssignmentList IModelJsonSerializable<ConfigurationProfileAssignmentList>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeConfigurationProfileAssignmentList(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ConfigurationProfileAssignmentList>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ConfigurationProfileAssignmentList IModelSerializable<ConfigurationProfileAssignmentList>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeConfigurationProfileAssignmentList(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ConfigurationProfileAssignmentList"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ConfigurationProfileAssignmentList"/> to convert. </param>
        public static implicit operator RequestContent(ConfigurationProfileAssignmentList model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ConfigurationProfileAssignmentList"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ConfigurationProfileAssignmentList(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeConfigurationProfileAssignmentList(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
