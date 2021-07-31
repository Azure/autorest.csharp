// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class ApplicationAuthorization : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("principalId");
            writer.WriteStringValue(PrincipalId);
            writer.WritePropertyName("roleDefinitionId");
            writer.WriteStringValue(RoleDefinitionId);
            writer.WriteEndObject();
        }

        internal static ApplicationAuthorization DeserializeApplicationAuthorization(JsonElement element)
        {
            string principalId = default;
            string roleDefinitionId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("principalId"))
                {
                    principalId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("roleDefinitionId"))
                {
                    roleDefinitionId = property.Value.GetString();
                    continue;
                }
            }
            return new ApplicationAuthorization(principalId, roleDefinitionId);
        }
    }
}
