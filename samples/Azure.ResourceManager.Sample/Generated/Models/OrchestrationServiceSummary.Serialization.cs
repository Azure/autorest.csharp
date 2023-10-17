// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class OrchestrationServiceSummary : IUtf8JsonSerializable, IModelJsonSerializable<OrchestrationServiceSummary>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<OrchestrationServiceSummary>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<OrchestrationServiceSummary>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(ServiceName))
            {
                writer.WritePropertyName("serviceName"u8);
                writer.WriteStringValue(ServiceName.Value.ToString());
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(ServiceState))
            {
                writer.WritePropertyName("serviceState"u8);
                writer.WriteStringValue(ServiceState.Value.ToString());
            }
            writer.WriteEndObject();
        }

        OrchestrationServiceSummary IModelJsonSerializable<OrchestrationServiceSummary>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOrchestrationServiceSummary(document.RootElement, options);
        }

        BinaryData IModelSerializable<OrchestrationServiceSummary>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        OrchestrationServiceSummary IModelSerializable<OrchestrationServiceSummary>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeOrchestrationServiceSummary(document.RootElement, options);
        }

        internal static OrchestrationServiceSummary DeserializeOrchestrationServiceSummary(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<OrchestrationServiceName> serviceName = default;
            Optional<OrchestrationServiceState> serviceState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("serviceName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serviceName = new OrchestrationServiceName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("serviceState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serviceState = new OrchestrationServiceState(property.Value.GetString());
                    continue;
                }
            }
            return new OrchestrationServiceSummary(Optional.ToNullable(serviceName), Optional.ToNullable(serviceState));
        }
    }
}
