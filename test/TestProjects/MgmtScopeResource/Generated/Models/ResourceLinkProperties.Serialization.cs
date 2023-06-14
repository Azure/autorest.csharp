// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    public partial class ResourceLinkProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("targetId"u8);
            writer.WriteStringValue(TargetId);
            if (Optional.IsDefined(Notes))
            {
                writer.WritePropertyName("notes"u8);
                writer.WriteStringValue(Notes);
            }
            writer.WriteEndObject();
        }

        internal static ResourceLinkProperties DeserializeResourceLinkProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> sourceId = default;
            string targetId = default;
            Optional<string> notes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sourceId"u8))
                {
                    sourceId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetId"u8))
                {
                    targetId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("notes"u8))
                {
                    notes = property.Value.GetString();
                    continue;
                }
            }
            return new ResourceLinkProperties(sourceId.Value, targetId, notes.Value);
        }
    }
}
