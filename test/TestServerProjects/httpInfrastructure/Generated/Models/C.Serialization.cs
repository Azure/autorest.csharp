// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace httpInfrastructure.Models
{
    public partial class C
    {
        internal static C DeserializeC(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> httpCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("httpCode"u8))
                {
                    httpCode = property.Value.GetString();
                    continue;
                }
            }
            return new C(httpCode.Value);
        }
    }
}
