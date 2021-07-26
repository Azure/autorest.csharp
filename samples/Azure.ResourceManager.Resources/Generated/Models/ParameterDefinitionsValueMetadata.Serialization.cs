// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources
{
    public partial class ParameterDefinitionsValueMetadata : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(DisplayName))
            {
                writer.WritePropertyName("displayName");
                writer.WriteStringValue(DisplayName);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(StrongType))
            {
                writer.WritePropertyName("strongType");
                writer.WriteStringValue(StrongType);
            }
            if (Optional.IsDefined(AssignPermissions))
            {
                writer.WritePropertyName("assignPermissions");
                writer.WriteBooleanValue(AssignPermissions.Value);
            }
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }

        internal static ParameterDefinitionsValueMetadata DeserializeParameterDefinitionsValueMetadata(JsonElement element)
        {
            Optional<string> displayName = default;
            Optional<string> description = default;
            Optional<string> strongType = default;
            Optional<bool> assignPermissions = default;
            IDictionary<string, object> additionalProperties = default;
            Dictionary<string, object> additionalPropertiesDictionary = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("displayName"))
                {
                    displayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("strongType"))
                {
                    strongType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("assignPermissions"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    try
                    {
                        assignPermissions = property.Value.GetBoolean();
                    }
                    catch (Exception)
                    {
                        assignPermissions = property.Value.GetString().Equals("true", StringComparison.InvariantCultureIgnoreCase);
                    }
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetObject());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new ParameterDefinitionsValueMetadata(displayName.Value, description.Value, strongType.Value, Optional.ToNullable(assignPermissions), additionalProperties);
        }
    }
}
