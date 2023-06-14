// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class RouteConfigurationOverrideActionParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            if (Optional.IsDefined(OriginGroupOverride))
            {
                writer.WritePropertyName("originGroupOverride"u8);
                writer.WriteObjectValue(OriginGroupOverride);
            }
            writer.WriteEndObject();
        }

        internal static RouteConfigurationOverrideActionParameters DeserializeRouteConfigurationOverrideActionParameters(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            RouteConfigurationOverrideActionParametersTypeName typeName = default;
            Optional<OriginGroupOverride> originGroupOverride = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new RouteConfigurationOverrideActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("originGroupOverride"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    originGroupOverride = OriginGroupOverride.DeserializeOriginGroupOverride(property.Value);
                    continue;
                }
            }
            return new RouteConfigurationOverrideActionParameters(typeName, originGroupOverride.Value);
        }
    }
}
