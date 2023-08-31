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

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ObjectReplicationPolicyRule : IUtf8JsonSerializable, IModelJsonSerializable<ObjectReplicationPolicyRule>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ObjectReplicationPolicyRule>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ObjectReplicationPolicyRule>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(RuleId))
            {
                writer.WritePropertyName("ruleId"u8);
                writer.WriteStringValue(RuleId);
            }
            writer.WritePropertyName("sourceContainer"u8);
            writer.WriteStringValue(SourceContainer);
            writer.WritePropertyName("destinationContainer"u8);
            writer.WriteStringValue(DestinationContainer);
            if (Optional.IsDefined(Filters))
            {
                writer.WritePropertyName("filters"u8);
                ((IModelJsonSerializable<ObjectReplicationPolicyFilter>)Filters).Serialize(writer, options);
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

        internal static ObjectReplicationPolicyRule DeserializeObjectReplicationPolicyRule(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> ruleId = default;
            string sourceContainer = default;
            string destinationContainer = default;
            Optional<ObjectReplicationPolicyFilter> filters = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ruleId"u8))
                {
                    ruleId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourceContainer"u8))
                {
                    sourceContainer = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destinationContainer"u8))
                {
                    destinationContainer = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("filters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    filters = ObjectReplicationPolicyFilter.DeserializeObjectReplicationPolicyFilter(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ObjectReplicationPolicyRule(ruleId.Value, sourceContainer, destinationContainer, filters.Value, rawData);
        }

        ObjectReplicationPolicyRule IModelJsonSerializable<ObjectReplicationPolicyRule>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeObjectReplicationPolicyRule(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ObjectReplicationPolicyRule>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ObjectReplicationPolicyRule IModelSerializable<ObjectReplicationPolicyRule>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeObjectReplicationPolicyRule(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ObjectReplicationPolicyRule"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ObjectReplicationPolicyRule"/> to convert. </param>
        public static implicit operator RequestContent(ObjectReplicationPolicyRule model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ObjectReplicationPolicyRule"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ObjectReplicationPolicyRule(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeObjectReplicationPolicyRule(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
