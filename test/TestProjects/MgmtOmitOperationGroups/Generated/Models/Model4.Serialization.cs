// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtOmitOperationGroups.Models
{
    public partial class Model4
    {
        internal static Model4 DeserializeModel4(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> id = default;
            Optional<string> j = default;
            Optional<ModelZ> modelz = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("j"u8))
                {
                    j = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modelz"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    modelz = ModelZ.DeserializeModelZ(property.Value);
                    continue;
                }
            }
            return new Model4(id.Value, j.Value, modelz.Value);
        }
    }
}
