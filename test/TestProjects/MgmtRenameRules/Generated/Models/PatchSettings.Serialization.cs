// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    internal partial class PatchSettings : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(PatchMode))
            {
                writer.WritePropertyName("patchMode"u8);
                writer.WriteStringValue(PatchMode.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static PatchSettings DeserializePatchSettings(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<InGuestPatchMode> patchMode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("patchMode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    patchMode = new InGuestPatchMode(property.Value.GetString());
                    continue;
                }
            }
            return new PatchSettings(Optional.ToNullable(patchMode));
        }
    }
}
