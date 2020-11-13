// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace subscriptionId_apiVersion.Models
{
    internal partial class Error
    {
        internal static Error DeserializeError(JsonElement element)
        {
            Optional<int> code = default;
            Optional<string> message = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    code = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
            }
            return new Error(Optional.ToNullable(code), message.Value);
        }
    }
}
