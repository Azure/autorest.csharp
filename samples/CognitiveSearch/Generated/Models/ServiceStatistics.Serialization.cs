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
    public partial class ServiceStatistics : IUtf8JsonSerializable, IModelJsonSerializable<ServiceStatistics>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ServiceStatistics>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ServiceStatistics>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("counters"u8);
            writer.WriteObjectValue(Counters);
            writer.WritePropertyName("limits"u8);
            writer.WriteObjectValue(Limits);
            writer.WriteEndObject();
        }

        ServiceStatistics IModelJsonSerializable<ServiceStatistics>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeServiceStatistics(document.RootElement, options);
        }

        BinaryData IModelSerializable<ServiceStatistics>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ServiceStatistics IModelSerializable<ServiceStatistics>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeServiceStatistics(document.RootElement, options);
        }

        internal static ServiceStatistics DeserializeServiceStatistics(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
    }
}
