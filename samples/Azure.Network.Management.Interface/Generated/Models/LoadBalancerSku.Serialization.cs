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
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static LoadBalancerSku DeserializeLoadBalancerSku(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            LoadBalancerSkuName? name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    name = new LoadBalancerSkuName(property.Value.GetString());
                    continue;
                }
            }
            return new LoadBalancerSku(name);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static LoadBalancerSku FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeLoadBalancerSku(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
