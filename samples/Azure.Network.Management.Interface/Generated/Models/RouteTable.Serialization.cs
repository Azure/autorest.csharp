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
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Routes))
            {
                writer.WritePropertyName("routes"u8);
                writer.WriteStartArray();
                foreach (var item in Routes)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(DisableBgpRoutePropagation))
            {
                writer.WritePropertyName("disableBgpRoutePropagation"u8);
                writer.WriteBooleanValue(DisableBgpRoutePropagation.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static RouteTable DeserializeRouteTable(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string etag = default;
            string id = default;
            string name = default;
            string type = default;
            string location = default;
            IDictionary<string, string> tags = default;
            IList<Route> routes = default;
            IReadOnlyList<Subnet> subnets = default;
            bool? disableBgpRoutePropagation = default;
            ProvisioningState? provisioningState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("routes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<Route> array = new List<Route>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(Route.DeserializeRoute(item));
                            }
                            routes = array;
                            continue;
                        }
                        if (property0.NameEquals("subnets"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<Subnet> array = new List<Subnet>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(Subnet.DeserializeSubnet(item));
                            }
                            subnets = array;
                            continue;
                        }
                        if (property0.NameEquals("disableBgpRoutePropagation"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            disableBgpRoutePropagation = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new RouteTable(
                id,
                name,
                type,
                location,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                etag,
                routes ?? new ChangeTrackingList<Route>(),
                subnets ?? new ChangeTrackingList<Subnet>(),
                disableBgpRoutePropagation,
                provisioningState);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new RouteTable FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRouteTable(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
