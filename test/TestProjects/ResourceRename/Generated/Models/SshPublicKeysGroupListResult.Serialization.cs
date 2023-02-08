// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using ResourceRename;

namespace ResourceRename.Models
{
    internal partial class SshPublicKeysGroupListResult
    {
        internal static SshPublicKeysGroupListResult DeserializeSshPublicKeysGroupListResult(JsonElement element)
        {
            IReadOnlyList<SshPublicKeyInfoData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<SshPublicKeyInfoData> array = new List<SshPublicKeyInfoData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SshPublicKeyInfoData.DeserializeSshPublicKeyInfoData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new SshPublicKeysGroupListResult(value, nextLink.Value);
        }
    }
}
