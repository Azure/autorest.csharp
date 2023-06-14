// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ImmutableStorageAccount : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Enabled))
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(Enabled.Value);
            }
            if (Optional.IsDefined(ImmutabilityPolicy))
            {
                writer.WritePropertyName("immutabilityPolicy"u8);
                writer.WriteObjectValue(ImmutabilityPolicy);
            }
            writer.WriteEndObject();
        }

        internal static ImmutableStorageAccount DeserializeImmutableStorageAccount(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> enabled = default;
            Optional<AccountImmutabilityPolicyProperties> immutabilityPolicy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("immutabilityPolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    immutabilityPolicy = AccountImmutabilityPolicyProperties.DeserializeAccountImmutabilityPolicyProperties(property.Value);
                    continue;
                }
            }
            return new ImmutableStorageAccount(Optional.ToNullable(enabled), immutabilityPolicy.Value);
        }
    }
}
