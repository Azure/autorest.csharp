// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class IpTag : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(IpTagType))
            {
                writer.WritePropertyName("ipTagType"u8);
                writer.WriteStringValue(IpTagType);
            }
            if (Optional.IsDefined(Tag))
            {
                writer.WritePropertyName("tag"u8);
                writer.WriteStringValue(Tag);
            }
            writer.WriteEndObject();
        }

        internal static IpTag DeserializeIpTag(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string ipTagType = default;
            string tag = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ipTagType"u8))
                {
                    ipTagType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tag"u8))
                {
                    tag = property.Value.GetString();
                    continue;
                }
            }
            return new IpTag(ipTagType, tag);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static IpTag FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeIpTag(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
