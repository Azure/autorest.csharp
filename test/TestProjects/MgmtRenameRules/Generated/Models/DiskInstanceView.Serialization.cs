// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class DiskInstanceView
    {
        internal static DiskInstanceView DeserializeDiskInstanceView(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<IReadOnlyList<DiskEncryptionSettings>> encryptionSettings = default;
            Optional<IReadOnlyList<InstanceViewStatus>> statuses = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("encryptionSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DiskEncryptionSettings> array = new List<DiskEncryptionSettings>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DiskEncryptionSettings.DeserializeDiskEncryptionSettings(item));
                    }
                    encryptionSettings = array;
                    continue;
                }
                if (property.NameEquals("statuses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InstanceViewStatus> array = new List<InstanceViewStatus>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InstanceViewStatus.DeserializeInstanceViewStatus(item));
                    }
                    statuses = array;
                    continue;
                }
            }
            return new DiskInstanceView(name.Value, Optional.ToList(encryptionSettings), Optional.ToList(statuses));
        }
    }
}
