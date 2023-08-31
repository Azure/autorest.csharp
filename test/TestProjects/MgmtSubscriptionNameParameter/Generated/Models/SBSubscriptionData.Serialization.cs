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
using Azure.ResourceManager.Models;
using MgmtSubscriptionNameParameter.Models;

namespace MgmtSubscriptionNameParameter
{
    public partial class SBSubscriptionData : IUtf8JsonSerializable, IModelJsonSerializable<SBSubscriptionData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SBSubscriptionData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<SBSubscriptionData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(LockDuration))
            {
                writer.WritePropertyName("lockDuration"u8);
                writer.WriteStringValue(LockDuration.Value, "P");
            }
            if (Optional.IsDefined(RequiresSession))
            {
                writer.WritePropertyName("requiresSession"u8);
                writer.WriteBooleanValue(RequiresSession.Value);
            }
            if (Optional.IsDefined(DefaultMessageTimeToLive))
            {
                writer.WritePropertyName("defaultMessageTimeToLive"u8);
                writer.WriteStringValue(DefaultMessageTimeToLive.Value, "P");
            }
            if (Optional.IsDefined(DeadLetteringOnFilterEvaluationExceptions))
            {
                writer.WritePropertyName("deadLetteringOnFilterEvaluationExceptions"u8);
                writer.WriteBooleanValue(DeadLetteringOnFilterEvaluationExceptions.Value);
            }
            if (Optional.IsDefined(DeadLetteringOnMessageExpiration))
            {
                writer.WritePropertyName("deadLetteringOnMessageExpiration"u8);
                writer.WriteBooleanValue(DeadLetteringOnMessageExpiration.Value);
            }
            if (Optional.IsDefined(DuplicateDetectionHistoryTimeWindow))
            {
                writer.WritePropertyName("duplicateDetectionHistoryTimeWindow"u8);
                writer.WriteStringValue(DuplicateDetectionHistoryTimeWindow.Value, "P");
            }
            if (Optional.IsDefined(MaxDeliveryCount))
            {
                writer.WritePropertyName("maxDeliveryCount"u8);
                writer.WriteNumberValue(MaxDeliveryCount.Value);
            }
            if (Optional.IsDefined(EnableBatchedOperations))
            {
                writer.WritePropertyName("enableBatchedOperations"u8);
                writer.WriteBooleanValue(EnableBatchedOperations.Value);
            }
            if (Optional.IsDefined(AutoDeleteOnIdle))
            {
                writer.WritePropertyName("autoDeleteOnIdle"u8);
                writer.WriteStringValue(AutoDeleteOnIdle.Value, "P");
            }
            if (Optional.IsDefined(ForwardTo))
            {
                writer.WritePropertyName("forwardTo"u8);
                writer.WriteStringValue(ForwardTo);
            }
            if (Optional.IsDefined(ForwardDeadLetteredMessagesTo))
            {
                writer.WritePropertyName("forwardDeadLetteredMessagesTo"u8);
                writer.WriteStringValue(ForwardDeadLetteredMessagesTo);
            }
            if (Optional.IsDefined(IsClientAffine))
            {
                writer.WritePropertyName("isClientAffine"u8);
                writer.WriteBooleanValue(IsClientAffine.Value);
            }
            if (Optional.IsDefined(ClientAffineProperties))
            {
                writer.WritePropertyName("clientAffineProperties"u8);
                ((IModelJsonSerializable<SBClientAffineProperties>)ClientAffineProperties).Serialize(writer, options);
            }
            writer.WriteEndObject();
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

        internal static SBSubscriptionData DeserializeSBSubscriptionData(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<long> messageCount = default;
            Optional<DateTimeOffset> createdAt = default;
            Optional<DateTimeOffset> accessedAt = default;
            Optional<DateTimeOffset> updatedAt = default;
            Optional<TimeSpan> lockDuration = default;
            Optional<bool> requiresSession = default;
            Optional<TimeSpan> defaultMessageTimeToLive = default;
            Optional<bool> deadLetteringOnFilterEvaluationExceptions = default;
            Optional<bool> deadLetteringOnMessageExpiration = default;
            Optional<TimeSpan> duplicateDetectionHistoryTimeWindow = default;
            Optional<int> maxDeliveryCount = default;
            Optional<bool> enableBatchedOperations = default;
            Optional<TimeSpan> autoDeleteOnIdle = default;
            Optional<string> forwardTo = default;
            Optional<string> forwardDeadLetteredMessagesTo = default;
            Optional<bool> isClientAffine = default;
            Optional<SBClientAffineProperties> clientAffineProperties = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("messageCount"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            messageCount = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("createdAt"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            createdAt = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("accessedAt"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            accessedAt = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("updatedAt"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            updatedAt = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("lockDuration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            lockDuration = property0.Value.GetTimeSpan("P");
                            continue;
                        }
                        if (property0.NameEquals("requiresSession"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            requiresSession = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("defaultMessageTimeToLive"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            defaultMessageTimeToLive = property0.Value.GetTimeSpan("P");
                            continue;
                        }
                        if (property0.NameEquals("deadLetteringOnFilterEvaluationExceptions"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            deadLetteringOnFilterEvaluationExceptions = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("deadLetteringOnMessageExpiration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            deadLetteringOnMessageExpiration = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("duplicateDetectionHistoryTimeWindow"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            duplicateDetectionHistoryTimeWindow = property0.Value.GetTimeSpan("P");
                            continue;
                        }
                        if (property0.NameEquals("maxDeliveryCount"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            maxDeliveryCount = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("enableBatchedOperations"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enableBatchedOperations = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("autoDeleteOnIdle"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            autoDeleteOnIdle = property0.Value.GetTimeSpan("P");
                            continue;
                        }
                        if (property0.NameEquals("forwardTo"u8))
                        {
                            forwardTo = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("forwardDeadLetteredMessagesTo"u8))
                        {
                            forwardDeadLetteredMessagesTo = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("isClientAffine"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            isClientAffine = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("clientAffineProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            clientAffineProperties = SBClientAffineProperties.DeserializeSBClientAffineProperties(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new SBSubscriptionData(id, name, type, systemData.Value, Optional.ToNullable(messageCount), Optional.ToNullable(createdAt), Optional.ToNullable(accessedAt), Optional.ToNullable(updatedAt), Optional.ToNullable(lockDuration), Optional.ToNullable(requiresSession), Optional.ToNullable(defaultMessageTimeToLive), Optional.ToNullable(deadLetteringOnFilterEvaluationExceptions), Optional.ToNullable(deadLetteringOnMessageExpiration), Optional.ToNullable(duplicateDetectionHistoryTimeWindow), Optional.ToNullable(maxDeliveryCount), Optional.ToNullable(enableBatchedOperations), Optional.ToNullable(autoDeleteOnIdle), forwardTo.Value, forwardDeadLetteredMessagesTo.Value, Optional.ToNullable(isClientAffine), clientAffineProperties.Value, rawData);
        }

        SBSubscriptionData IModelJsonSerializable<SBSubscriptionData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeSBSubscriptionData(doc.RootElement, options);
        }

        BinaryData IModelSerializable<SBSubscriptionData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        SBSubscriptionData IModelSerializable<SBSubscriptionData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeSBSubscriptionData(doc.RootElement, options);
        }

        public static implicit operator RequestContent(SBSubscriptionData model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator SBSubscriptionData(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeSBSubscriptionData(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
