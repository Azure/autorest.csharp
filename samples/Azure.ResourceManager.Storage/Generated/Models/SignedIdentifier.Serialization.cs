// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class SignedIdentifier : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(AccessPolicy))
            {
                writer.WritePropertyName("accessPolicy"u8);
                writer.WriteObjectValue(AccessPolicy);
            }
            writer.WriteEndObject();
        }

        internal static SignedIdentifier DeserializeSignedIdentifier(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> id = default;
            Optional<AccessPolicy> accessPolicy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("accessPolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    accessPolicy = AccessPolicy.DeserializeAccessPolicy(property.Value);
                    continue;
                }
            }
            return new SignedIdentifier(id.Value, accessPolicy.Value);
        }
    }
}
