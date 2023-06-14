// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace httpInfrastructure.Models
{
    public partial class D
    {
        internal static D DeserializeD(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> httpStatusCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("httpStatusCode"u8))
                {
                    httpStatusCode = property.Value.GetString();
                    continue;
                }
            }
            return new D(httpStatusCode.Value);
        }
    }
}
