// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    internal partial class BaseError
    {
        internal static BaseError DeserializeBaseError(JsonElement element)
        {
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
