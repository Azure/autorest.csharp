// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace HttpInfrastructure.Models
{
    public partial class B
    {
        internal static B DeserializeB(JsonElement element)
        {
            Optional<string> textStatusCode = default;
            Optional<string> statusCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("textStatusCode"))
                {
                    textStatusCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("statusCode"))
                {
                    statusCode = property.Value.GetString();
                    continue;
                }
            }
            return new B(statusCode.Value, textStatusCode.Value);
        }
    }
}
