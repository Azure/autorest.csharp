// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ObjectReplicationPolicyRule : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
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
                writer.WriteObjectValue(Filters);
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeObjectReplicationPolicyRule(doc.RootElement, options);
        }

        internal static ObjectReplicationPolicyRule DeserializeObjectReplicationPolicyRule(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> ruleId = default;
            string sourceContainer = default;
            string destinationContainer = default;
            Optional<ObjectReplicationPolicyFilter> filters = default;
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
            }
            return new ObjectReplicationPolicyRule(ruleId.Value, sourceContainer, destinationContainer, filters.Value);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeObjectReplicationPolicyRule(doc.RootElement, options);
        }
    }
}
