// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class CustomDomain : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(UseSubDomainName))
            {
                writer.WritePropertyName("useSubDomainName"u8);
                writer.WriteBooleanValue(UseSubDomainName.Value);
            }
            writer.WriteEndObject();
        }

        internal static CustomDomain DeserializeCustomDomain(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<bool> useSubDomainName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("useSubDomainName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    useSubDomainName = property.Value.GetBoolean();
                    continue;
                }
            }
            return new CustomDomain(name, Optional.ToNullable(useSubDomainName));
        }
    }
}
