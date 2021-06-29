// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMultipleParentResource.Models
{
    internal partial class ApiErrorBase
    {
        internal static ApiErrorBase DeserializeApiErrorBase(JsonElement element)
        {
            Optional<string> code = default;
            Optional<string> target = default;
            Optional<string> message = default;
            foreach (var property in element.EnumerateObject())
            {
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
            return new ApiErrorBase(code.Value, target.Value, message.Value);
        }
    }
}
