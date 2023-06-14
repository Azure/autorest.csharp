// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtExtensionCommonRestOperation.Models
{
    internal partial class CloudError
    {
        internal static CloudError DeserializeCloudError(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ErrorResponse> error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    error = Models.ErrorResponse.DeserializeErrorResponse(property.Value);
                    continue;
                }
            }
            return new CloudError(error.Value);
        }
    }
}
