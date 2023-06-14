// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    internal partial class ErrorResponse
    {
        internal static ErrorResponse DeserializeErrorResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("error"u8))
                {
                    error = property.Value.GetString();
                    continue;
                }
            }
            return new ErrorResponse(error.Value);
        }
    }
}
