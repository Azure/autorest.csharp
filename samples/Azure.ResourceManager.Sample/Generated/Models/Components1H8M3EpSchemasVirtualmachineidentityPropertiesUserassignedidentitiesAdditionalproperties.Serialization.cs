// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class Components1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static Components1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties DeserializeComponents1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties(JsonElement element)
        {
            Optional<string> principalId = default;
            Optional<string> clientId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("principalId"))
                {
                    principalId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("clientId"))
                {
                    clientId = property.Value.GetString();
                    continue;
                }
            }
            return new Components1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties(principalId.Value, clientId.Value);
        }
    }
}
