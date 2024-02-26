// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    public partial class OSProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (ComputerName != null)
            {
                writer.WritePropertyName("computerName"u8);
                writer.WriteStringValue(ComputerName);
            }
            if (AdminUsername != null)
            {
                writer.WritePropertyName("adminUsername"u8);
                writer.WriteStringValue(AdminUsername);
            }
            if (AdminPassword != null)
            {
                writer.WritePropertyName("adminPassword"u8);
                writer.WriteStringValue(AdminPassword);
            }
            if (CustomData != null)
            {
                writer.WritePropertyName("customData"u8);
                writer.WriteStringValue(CustomData);
            }
            if (WindowsConfiguration != null)
            {
                writer.WritePropertyName("windowsConfiguration"u8);
                writer.WriteObjectValue(WindowsConfiguration);
            }
            if (LinuxConfiguration != null)
            {
                writer.WritePropertyName("linuxConfiguration"u8);
                writer.WriteObjectValue(LinuxConfiguration);
            }
            if (!(Secrets is ChangeTrackingList<VaultSecretGroup> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("secrets"u8);
                writer.WriteStartArray();
                foreach (var item in Secrets)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (AllowExtensionOperations.HasValue)
            {
                writer.WritePropertyName("allowExtensionOperations"u8);
                writer.WriteBooleanValue(AllowExtensionOperations.Value);
            }
            if (RequireGuestProvisionSignal.HasValue)
            {
                writer.WritePropertyName("requireGuestProvisionSignal"u8);
                writer.WriteBooleanValue(RequireGuestProvisionSignal.Value);
            }
            writer.WriteEndObject();
        }

        internal static OSProfile DeserializeOSProfile(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string computerName = default;
            string adminUsername = default;
            string adminPassword = default;
            string customData = default;
            WindowsConfiguration windowsConfiguration = default;
            LinuxConfiguration linuxConfiguration = default;
            IList<VaultSecretGroup> secrets = default;
            bool allowExtensionOperations = default;
            bool requireGuestProvisionSignal = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("computerName"u8))
                {
                    computerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("adminUsername"u8))
                {
                    adminUsername = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("adminPassword"u8))
                {
                    adminPassword = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customData"u8))
                {
                    customData = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("windowsConfiguration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    windowsConfiguration = WindowsConfiguration.DeserializeWindowsConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("linuxConfiguration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    linuxConfiguration = LinuxConfiguration.DeserializeLinuxConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("secrets"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VaultSecretGroup> array = new List<VaultSecretGroup>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VaultSecretGroup.DeserializeVaultSecretGroup(item));
                    }
                    secrets = array;
                    continue;
                }
                if (property.NameEquals("allowExtensionOperations"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowExtensionOperations = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("requireGuestProvisionSignal"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    requireGuestProvisionSignal = property.Value.GetBoolean();
                    continue;
                }
            }
            return new OSProfile(
                computerName,
                adminUsername,
                adminPassword,
                customData,
                windowsConfiguration,
                linuxConfiguration,
                secrets ?? new ChangeTrackingList<VaultSecretGroup>(),
                allowExtensionOperations,
                requireGuestProvisionSignal);
        }
    }
}
