// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class VirtualNetworkRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(VirtualNetworkResourceId);
            if (Optional.IsDefined(Action))
            {
                writer.WritePropertyName("action");
                writer.WriteStringValue(Action);
            }
            if (Optional.IsDefined(State))
            {
                writer.WritePropertyName("state");
                writer.WriteStringValue(State.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }

        internal static VirtualNetworkRule DeserializeVirtualNetworkRule(JsonElement element)
        {
            string id = default;
            Optional<string> action = default;
            Optional<State> state = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("action"))
                {
                    action = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("state"))
                {
                    state = property.Value.GetString().ToState();
                    continue;
                }
            }
            return new VirtualNetworkRule(id, action.HasValue ? action.Value : null, state.HasValue ? state.Value : (State?)null);
        }
    }
}
