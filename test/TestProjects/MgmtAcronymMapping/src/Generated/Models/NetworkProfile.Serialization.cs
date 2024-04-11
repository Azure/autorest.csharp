// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    internal partial class NetworkProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(NetworkInterfaces))
            {
                writer.WritePropertyName("networkInterfaces"u8);
                writer.WriteStartArray();
                foreach (var item in NetworkInterfaces)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static NetworkProfile DeserializeNetworkProfile(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<NetworkInterfaceReference> networkInterfaces = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("networkInterfaces"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<NetworkInterfaceReference> array = new List<NetworkInterfaceReference>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NetworkInterfaceReference.DeserializeNetworkInterfaceReference(item));
                    }
                    networkInterfaces = array;
                    continue;
                }
            }
            return new NetworkProfile(networkInterfaces ?? new ChangeTrackingList<NetworkInterfaceReference>());
        }
    }
}
