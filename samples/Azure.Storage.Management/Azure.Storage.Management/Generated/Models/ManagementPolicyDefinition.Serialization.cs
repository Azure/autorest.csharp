// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class ManagementPolicyDefinition : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("actions");
            writer.WriteObjectValue(Actions);
            if (Filters != null)
            {
                writer.WritePropertyName("filters");
                writer.WriteObjectValue(Filters);
            }
            writer.WriteEndObject();
        }

        internal static ManagementPolicyDefinition DeserializeManagementPolicyDefinition(JsonElement element)
        {
            ManagementPolicyAction actions = default;
            ManagementPolicyFilter filters = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("actions"))
                {
                    actions = ManagementPolicyAction.DeserializeManagementPolicyAction(property.Value);
                    continue;
                }
                if (property.NameEquals("filters"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    filters = ManagementPolicyFilter.DeserializeManagementPolicyFilter(property.Value);
                    continue;
                }
            }
            return new ManagementPolicyDefinition(actions, filters);
        }
    }
}
