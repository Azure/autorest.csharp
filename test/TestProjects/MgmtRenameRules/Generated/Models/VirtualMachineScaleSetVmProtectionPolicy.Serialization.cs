// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class VirtualMachineScaleSetVmProtectionPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ProtectFromScaleIn))
            {
                writer.WritePropertyName("protectFromScaleIn"u8);
                writer.WriteBooleanValue(ProtectFromScaleIn.Value);
            }
            if (Optional.IsDefined(ProtectFromScaleSetActions))
            {
                writer.WritePropertyName("protectFromScaleSetActions"u8);
                writer.WriteBooleanValue(ProtectFromScaleSetActions.Value);
            }
            writer.WriteEndObject();
        }

        internal static VirtualMachineScaleSetVmProtectionPolicy DeserializeVirtualMachineScaleSetVmProtectionPolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> protectFromScaleIn = default;
            Optional<bool> protectFromScaleSetActions = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("protectFromScaleIn"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectFromScaleIn = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("protectFromScaleSetActions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectFromScaleSetActions = property.Value.GetBoolean();
                    continue;
                }
            }
            return new VirtualMachineScaleSetVmProtectionPolicy(Optional.ToNullable(protectFromScaleIn), Optional.ToNullable(protectFromScaleSetActions));
        }
    }
}
