// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace httpInfrastructure.Models
{
    public partial class D
    {
        internal static D DeserializeD(JsonElement element)
        {
            Optional<string> httpStatusCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("httpStatusCode"))
                {
                    httpStatusCode = property.Value.GetString();
                    continue;
                }
            }
            return new D(httpStatusCode.HasValue ? httpStatusCode.Value : null);
        }
    }
}
