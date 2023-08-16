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
    public partial class LeaseContainerContent : IUtf8JsonSerializable, IModelJsonSerializable<LeaseContainerContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<LeaseContainerContent>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<LeaseContainerContent>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("action"u8);
            writer.WriteStringValue(Action.ToString());
            if (Optional.IsDefined(LeaseId))
            {
                writer.WritePropertyName("leaseId"u8);
                writer.WriteStringValue(LeaseId);
            }
            if (Optional.IsDefined(BreakPeriod))
            {
                writer.WritePropertyName("breakPeriod"u8);
                writer.WriteNumberValue(BreakPeriod.Value);
            }
            if (Optional.IsDefined(LeaseDuration))
            {
                writer.WritePropertyName("leaseDuration"u8);
                writer.WriteNumberValue(LeaseDuration.Value);
            }
            if (Optional.IsDefined(ProposedLeaseId))
            {
                writer.WritePropertyName("proposedLeaseId"u8);
                writer.WriteStringValue(ProposedLeaseId);
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

        internal static LeaseContainerContent DeserializeLeaseContainerContent(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            LeaseContainerRequestAction action = default;
            Optional<string> leaseId = default;
            Optional<int> breakPeriod = default;
            Optional<int> leaseDuration = default;
            Optional<string> proposedLeaseId = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("action"u8))
                {
                    action = new LeaseContainerRequestAction(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("leaseId"u8))
                {
                    leaseId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("breakPeriod"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    breakPeriod = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("leaseDuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    leaseDuration = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("proposedLeaseId"u8))
                {
                    proposedLeaseId = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new LeaseContainerContent(action, leaseId.Value, Optional.ToNullable(breakPeriod), Optional.ToNullable(leaseDuration), proposedLeaseId.Value, rawData);
        }

        LeaseContainerContent IModelJsonSerializable<LeaseContainerContent>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeLeaseContainerContent(doc.RootElement, options);
        }

        BinaryData IModelSerializable<LeaseContainerContent>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        LeaseContainerContent IModelSerializable<LeaseContainerContent>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeLeaseContainerContent(doc.RootElement, options);
        }

        public static implicit operator RequestContent(LeaseContainerContent model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator LeaseContainerContent(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeLeaseContainerContent(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
