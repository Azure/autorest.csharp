// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace compute.Models
{
    internal partial class CloudError
    {
        internal static CloudError DeserializeCloudError(JsonElement element)
        {
            Optional<ApiError> error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("error"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    error = ApiError.DeserializeApiError(property.Value);
                    continue;
                }
            }
            return new CloudError(error.Value);
        }
    }
}
