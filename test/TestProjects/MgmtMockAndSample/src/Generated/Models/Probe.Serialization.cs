// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class Probe : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("disableProbe"u8);
            writer.WriteBooleanValue(DisableProbe);
            if (Optional.IsDefined(InitialDelaySeconds))
            {
                writer.WritePropertyName("initialDelaySeconds"u8);
                writer.WriteNumberValue(InitialDelaySeconds.Value);
            }
            if (Optional.IsDefined(PeriodSeconds))
            {
                writer.WritePropertyName("periodSeconds"u8);
                writer.WriteNumberValue(PeriodSeconds.Value);
            }
            if (Optional.IsDefined(TimeoutSeconds))
            {
                writer.WritePropertyName("timeoutSeconds"u8);
                writer.WriteNumberValue(TimeoutSeconds.Value);
            }
            if (Optional.IsDefined(FailureThreshold))
            {
                writer.WritePropertyName("failureThreshold"u8);
                writer.WriteNumberValue(FailureThreshold.Value);
            }
            if (Optional.IsDefined(SuccessThreshold))
            {
                writer.WritePropertyName("successThreshold"u8);
                writer.WriteNumberValue(SuccessThreshold.Value);
            }
            writer.WriteEndObject();
        }

        internal static Probe DeserializeProbe(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool disableProbe = default;
            Optional<int> initialDelaySeconds = default;
            Optional<int> periodSeconds = default;
            Optional<int> timeoutSeconds = default;
            Optional<int> failureThreshold = default;
            Optional<int> successThreshold = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("disableProbe"u8))
                {
                    disableProbe = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("initialDelaySeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    initialDelaySeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("periodSeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    periodSeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("timeoutSeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    timeoutSeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failureThreshold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failureThreshold = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("successThreshold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    successThreshold = property.Value.GetInt32();
                    continue;
                }
            }
            return new Probe(disableProbe, Optional.ToNullable(initialDelaySeconds), Optional.ToNullable(periodSeconds), Optional.ToNullable(timeoutSeconds), Optional.ToNullable(failureThreshold), Optional.ToNullable(successThreshold));
        }
    }
}
