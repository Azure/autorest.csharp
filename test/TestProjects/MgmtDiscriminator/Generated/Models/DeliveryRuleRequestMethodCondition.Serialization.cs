// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class DeliveryRuleRequestMethodCondition : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("parameters");
            writer.WriteObjectValue(Parameters);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name.ToString());
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            writer.WriteEndObject();
        }

        internal static DeliveryRuleRequestMethodCondition DeserializeDeliveryRuleRequestMethodCondition(JsonElement element)
        {
            RequestMethodMatchConditionParameters parameters = default;
            MatchVariable name = default;
            Optional<string> description = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parameters"))
                {
                    parameters = RequestMethodMatchConditionParameters.DeserializeRequestMethodMatchConditionParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = new MatchVariable(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
            }
            return new DeliveryRuleRequestMethodCondition(name, description.Value, parameters);
        }
    }
}
