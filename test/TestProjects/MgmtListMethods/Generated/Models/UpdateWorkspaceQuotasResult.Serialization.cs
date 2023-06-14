// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtListMethods.Models
{
    internal partial class UpdateWorkspaceQuotasResult
    {
        internal static UpdateWorkspaceQuotasResult DeserializeUpdateWorkspaceQuotasResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<UpdateWorkspaceQuotas>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<UpdateWorkspaceQuotas> array = new List<UpdateWorkspaceQuotas>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(UpdateWorkspaceQuotas.DeserializeUpdateWorkspaceQuotas(item));
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
            return new UpdateWorkspaceQuotasResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
