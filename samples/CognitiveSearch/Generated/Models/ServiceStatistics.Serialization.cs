// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class ServiceStatistics : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("counters"u8);
            writer.WriteObjectValue(Counters);
            writer.WritePropertyName("limits"u8);
            writer.WriteObjectValue(Limits);
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeServiceStatistics(doc.RootElement, options);
        }

        internal static ServiceStatistics DeserializeServiceStatistics(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ServiceCounters counters = default;
            ServiceLimits limits = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("counters"u8))
                {
                    counters = ServiceCounters.DeserializeServiceCounters(property.Value);
                    continue;
                }
                if (property.NameEquals("limits"u8))
                {
                    limits = ServiceLimits.DeserializeServiceLimits(property.Value);
                    continue;
                }
            }
            return new ServiceStatistics(counters, limits);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeServiceStatistics(doc.RootElement, options);
        }
    }
}
