// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockTest.Models
{
    public partial class SenderAuthorization
    {
        internal static SenderAuthorization DeserializeSenderAuthorization(JsonElement element)
        {
            Optional<string> action = default;
            Optional<string> role = default;
            Optional<string> scope = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("action"))
                {
                    action = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("role"))
                {
                    role = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("scope"))
                {
                    scope = property.Value.GetString();
                    continue;
                }
            }
            return new SenderAuthorization(action.Value, role.Value, scope.Value);
        }
    }
}
