// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class SecurityProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(EncryptionAtHost))
            {
                writer.WritePropertyName("encryptionAtHost"u8);
                writer.WriteBooleanValue(EncryptionAtHost.Value);
            }
            writer.WriteEndObject();
        }

        internal static SecurityProfile DeserializeSecurityProfile(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> encryptionAtHost = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("encryptionAtHost"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    encryptionAtHost = property.Value.GetBoolean();
                    continue;
                }
            }
            return new SecurityProfile(Optional.ToNullable(encryptionAtHost));
        }
    }
}
