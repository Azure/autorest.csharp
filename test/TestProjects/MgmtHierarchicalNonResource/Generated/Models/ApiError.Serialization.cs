// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    internal partial class ApiError
    {
        internal static ApiError DeserializeApiError(JsonElement element)
        {
            Optional<IReadOnlyList<ApiErrorBase>> details = default;
            Optional<InnerError> innererror = default;
            Optional<string> code = default;
            Optional<string> target = default;
            Optional<string> message = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("details"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ApiErrorBase> array = new List<ApiErrorBase>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ApiErrorBase.DeserializeApiErrorBase(item));
                    }
                    details = array;
                    continue;
                }
                if (property.NameEquals("innererror"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    innererror = InnerError.DeserializeInnerError(property.Value);
                    continue;
                }
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
            }
            return new ApiError(Optional.ToList(details), innererror.Value, code.Value, target.Value, message.Value);
        }
    }
}
