// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtRenameRules;

namespace MgmtRenameRules.Models
{
    internal partial class SshPublicKeysGroupListResult
    {
        internal static SshPublicKeysGroupListResult DeserializeSshPublicKeysGroupListResult(JsonElement element)
        {
            IReadOnlyList<SshPublicKeyData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<SshPublicKeyData> array = new List<SshPublicKeyData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SshPublicKeyData.DeserializeSshPublicKeyData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new SshPublicKeysGroupListResult(value, nextLink.Value);
        }
    }
}
