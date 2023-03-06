// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    public partial class TemplateHashResult
    {
        internal static TemplateHashResult DeserializeTemplateHashResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> minifiedTemplate = default;
            Optional<string> templateHash = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("minifiedTemplate"u8))
                {
                    minifiedTemplate = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("templateHash"u8))
                {
                    templateHash = property.Value.GetString();
                    continue;
                }
            }
            return new TemplateHashResult(minifiedTemplate.Value, templateHash.Value);
        }
    }
}
