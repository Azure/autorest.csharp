// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class VaultValidationResult
    {
        internal static VaultValidationResult DeserializeVaultValidationResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<VaultIssue>> issues = default;
            Optional<string> result = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("issues"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VaultIssue> array = new List<VaultIssue>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VaultIssue.DeserializeVaultIssue(item));
                    }
                    issues = array;
                    continue;
                }
                if (property.NameEquals("result"u8))
                {
                    result = property.Value.GetString();
                    continue;
                }
            }
            return new VaultValidationResult(Optional.ToList(issues), result.Value);
        }
    }
}
