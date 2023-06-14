// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    internal partial class BaseError
    {
        internal static BaseError DeserializeBaseError(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> someBaseProp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("someBaseProp"u8))
                {
                    someBaseProp = property.Value.GetString();
                    continue;
                }
            }
            return new BaseError(someBaseProp.Value);
        }
    }
}
