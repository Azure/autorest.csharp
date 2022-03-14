// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class DeliveryRuleRouteConfigurationOverrideAction : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("parameters");
            writer.WriteObjectValue(Parameters);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name.ToString());
            writer.WriteEndObject();
        }

        internal static DeliveryRuleRouteConfigurationOverrideAction DeserializeDeliveryRuleRouteConfigurationOverrideAction(JsonElement element)
        {
            RouteConfigurationOverrideActionParameters parameters = default;
            DeliveryRuleActionType name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parameters"))
                {
                    parameters = RouteConfigurationOverrideActionParameters.DeserializeRouteConfigurationOverrideActionParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = new DeliveryRuleActionType(property.Value.GetString());
                    continue;
                }
            }
            return new DeliveryRuleRouteConfigurationOverrideAction(name, parameters);
        }
    }
}
