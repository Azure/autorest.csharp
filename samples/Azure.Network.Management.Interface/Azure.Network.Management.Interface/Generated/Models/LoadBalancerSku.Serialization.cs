// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class LoadBalancerSku : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static LoadBalancerSku DeserializeLoadBalancerSku(JsonElement element)
        {
            LoadBalancerSku result = new LoadBalancerSku();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = new LoadBalancerSkuName(property.Value.GetString());
                    continue;
                }
            }
            return result;
        }
    }
}
