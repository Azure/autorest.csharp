// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class AutomaticRepairsPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Enabled))
            {
                writer.WritePropertyName("enabled");
                writer.WriteBooleanValue(Enabled.Value);
            }
            if (Optional.IsDefined(GracePeriod))
            {
                writer.WritePropertyName("gracePeriod");
                writer.WriteStringValue(GracePeriod);
            }
            writer.WriteEndObject();
        }

        internal static AutomaticRepairsPolicy DeserializeAutomaticRepairsPolicy(JsonElement element)
        {
            Optional<bool> enabled = default;
            Optional<string> gracePeriod = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("gracePeriod"))
                {
                    gracePeriod = property.Value.GetString();
                    continue;
                }
            }
            return new AutomaticRepairsPolicy(Optional.ToNullable(enabled), gracePeriod.Value);
        }
    }
}
