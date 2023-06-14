// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    public partial class DeploymentExportResult
    {
        internal static DeploymentExportResult DeserializeDeploymentExportResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<BinaryData> template = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("template"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    template = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
            }
            return new DeploymentExportResult(template.Value);
        }
    }
}
