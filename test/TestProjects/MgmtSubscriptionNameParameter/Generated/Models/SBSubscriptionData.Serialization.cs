// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtSubscriptionNameParameter.Models;

namespace MgmtSubscriptionNameParameter
{
    public partial class SBSubscriptionData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
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
                writer.WriteObjectValue(ClientAffineProperties);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static SBSubscriptionData DeserializeSBSubscriptionData(JsonElement element)
        {
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
                        property.ThrowNonNullablePropertyIsNull();
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
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            messageCount = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("createdAt"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            createdAt = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("accessedAt"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            accessedAt = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("updatedAt"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            updatedAt = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("lockDuration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            lockDuration = property0.Value.GetTimeSpan("P");
                            continue;
                        }
                        if (property0.NameEquals("requiresSession"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            requiresSession = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("defaultMessageTimeToLive"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            defaultMessageTimeToLive = property0.Value.GetTimeSpan("P");
                            continue;
                        }
                        if (property0.NameEquals("deadLetteringOnFilterEvaluationExceptions"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            deadLetteringOnFilterEvaluationExceptions = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("deadLetteringOnMessageExpiration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            deadLetteringOnMessageExpiration = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("duplicateDetectionHistoryTimeWindow"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            duplicateDetectionHistoryTimeWindow = property0.Value.GetTimeSpan("P");
                            continue;
                        }
                        if (property0.NameEquals("maxDeliveryCount"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            maxDeliveryCount = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("enableBatchedOperations"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            enableBatchedOperations = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("autoDeleteOnIdle"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            isClientAffine = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("clientAffineProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            clientAffineProperties = SBClientAffineProperties.DeserializeSBClientAffineProperties(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new SBSubscriptionData(id, name, type, systemData.Value, Optional.ToNullable(messageCount), Optional.ToNullable(createdAt), Optional.ToNullable(accessedAt), Optional.ToNullable(updatedAt), Optional.ToNullable(lockDuration), Optional.ToNullable(requiresSession), Optional.ToNullable(defaultMessageTimeToLive), Optional.ToNullable(deadLetteringOnFilterEvaluationExceptions), Optional.ToNullable(deadLetteringOnMessageExpiration), Optional.ToNullable(duplicateDetectionHistoryTimeWindow), Optional.ToNullable(maxDeliveryCount), Optional.ToNullable(enableBatchedOperations), Optional.ToNullable(autoDeleteOnIdle), forwardTo.Value, forwardDeadLetteredMessagesTo.Value, Optional.ToNullable(isClientAffine), clientAffineProperties.Value);
        }
    }
}
