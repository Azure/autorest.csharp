// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtAcronymMapping.Models
{
    public partial class OrchestrationServiceStateContent : IUtf8JsonSerializable, IModelJsonSerializable<OrchestrationServiceStateContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<OrchestrationServiceStateContent>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<OrchestrationServiceStateContent>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("serviceName"u8);
            writer.WriteStringValue(ServiceName.ToString());
            writer.WritePropertyName("action"u8);
            writer.WriteStringValue(Action.ToString());
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        OrchestrationServiceStateContent IModelJsonSerializable<OrchestrationServiceStateContent>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOrchestrationServiceStateContent(document.RootElement, options);
        }

        BinaryData IModelSerializable<OrchestrationServiceStateContent>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        OrchestrationServiceStateContent IModelSerializable<OrchestrationServiceStateContent>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeOrchestrationServiceStateContent(document.RootElement, options);
        }

        internal static OrchestrationServiceStateContent DeserializeOrchestrationServiceStateContent(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OrchestrationServiceName serviceName = default;
            OrchestrationServiceStateAction action = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("serviceName"u8))
                {
                    serviceName = new OrchestrationServiceName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("action"u8))
                {
                    action = new OrchestrationServiceStateAction(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new OrchestrationServiceStateContent(serviceName, action, serializedAdditionalRawData);
        }
    }
}
