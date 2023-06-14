// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace httpInfrastructure.Models
{
    public partial class B
    {
        internal static B DeserializeB(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> textStatusCode = default;
            Optional<string> statusCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("textStatusCode"u8))
                {
                    textStatusCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("statusCode"u8))
                {
                    statusCode = property.Value.GetString();
                    continue;
                }
            }
            return new B(statusCode.Value, textStatusCode.Value);
        }
    }
}
