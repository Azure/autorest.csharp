// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace httpInfrastructure.Models
{
    public partial class C
    {
        internal static C DeserializeC(JsonElement element)
        {
            Optional<string> httpCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("httpCode"))
                {
                    httpCode = property.Value.GetString();
                    continue;
                }
            }
            return new C(httpCode.Value);
        }
    }
}
