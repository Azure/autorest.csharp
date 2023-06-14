// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    public partial class WhatIfOperationResult
    {
        internal static WhatIfOperationResult DeserializeWhatIfOperationResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> status = default;
            Optional<ErrorResponse> errorResponse = default;
            Optional<IReadOnlyList<WhatIfChange>> changes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errorResponse"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    errorResponse = ErrorResponse.DeserializeErrorResponse(property.Value);
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("changes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WhatIfChange> array = new List<WhatIfChange>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(WhatIfChange.DeserializeWhatIfChange(item));
                            }
                            changes = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new WhatIfOperationResult(status.Value, errorResponse.Value, Optional.ToList(changes));
        }
    }
}
