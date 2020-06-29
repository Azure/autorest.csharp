// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_datetime_rfc1123.Models
{
    internal partial class Error
    {
        internal static Error DeserializeError(JsonElement element)
        {
            Optional<int> status = default;
            Optional<string> message = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    status = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
            }
            return new Error(status.HasValue ? status.Value : (int?)null, message.HasValue ? message.Value : null);
        }
    }
}
