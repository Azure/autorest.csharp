// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class RouteTable : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location");
                writer.WriteStringValue(Location);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags");
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Routes))
            {
                writer.WritePropertyName("routes");
                writer.WriteStartArray();
                foreach (var item in Routes)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(DisableBgpRoutePropagation))
            {
                writer.WritePropertyName("disableBgpRoutePropagation");
                writer.WriteBooleanValue(DisableBgpRoutePropagation.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static RouteTable DeserializeRouteTable(JsonElement element)
        {
            Optional<string> etag = default;
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<string> type = default;
            Optional<string> location = default;
            Optional<IDictionary<string, string>> tags = default;
            Optional<IList<Route>> routes = default;
            Optional<IReadOnlyList<Subnet>> subnets = default;
            Optional<bool> disableBgpRoutePropagation = default;
            Optional<ProvisioningState> provisioningState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"))
                {
                    location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("routes"))
                        {
                            List<Route> array = new List<Route>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(Route.DeserializeRoute(item));
                            }
                            routes = array;
                            continue;
                        }
                        if (property0.NameEquals("subnets"))
                        {
                            List<Subnet> array = new List<Subnet>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(Subnet.DeserializeSubnet(item));
                            }
                            subnets = array;
                            continue;
                        }
                        if (property0.NameEquals("disableBgpRoutePropagation"))
                        {
                            disableBgpRoutePropagation = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"))
                        {
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new RouteTable(id.Value, name.Value, type.Value, location.Value, Optional.ToDictionary(tags), etag.Value, Optional.ToList(routes), Optional.ToList(subnets), Optional.ToNullable(disableBgpRoutePropagation), Optional.ToNullable(provisioningState));
        }
    }
}
