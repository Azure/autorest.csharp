// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class ServiceAssociationLink : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(LinkedResourceType))
            {
                writer.WritePropertyName("linkedResourceType"u8);
                writer.WriteStringValue(LinkedResourceType);
            }
            if (Optional.IsDefined(Link))
            {
                writer.WritePropertyName("link"u8);
                writer.WriteStringValue(Link);
            }
            if (Optional.IsDefined(AllowDelete))
            {
                writer.WritePropertyName("allowDelete"u8);
                writer.WriteBooleanValue(AllowDelete.Value);
            }
            if (Optional.IsCollectionDefined(Locations))
            {
                writer.WritePropertyName("locations"u8);
                writer.WriteStartArray();
                foreach (var item in Locations)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static ServiceAssociationLink DeserializeServiceAssociationLink(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string etag = default;
            string type = default;
            string id = default;
            string linkedResourceType = default;
            string link = default;
            ProvisioningState? provisioningState = default;
            bool? allowDelete = default;
            IList<string> locations = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
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
                        if (property0.NameEquals("linkedResourceType"u8))
                        {
                            linkedResourceType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("link"u8))
                        {
                            link = property0.Value.GetString();
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
                        if (property0.NameEquals("allowDelete"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allowDelete = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("locations"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            locations = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ServiceAssociationLink(
                id,
                name,
                etag,
                type,
                linkedResourceType,
                link,
                provisioningState,
                allowDelete,
                locations ?? new ChangeTrackingList<string>());
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new ServiceAssociationLink FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeServiceAssociationLink(document.RootElement);
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
