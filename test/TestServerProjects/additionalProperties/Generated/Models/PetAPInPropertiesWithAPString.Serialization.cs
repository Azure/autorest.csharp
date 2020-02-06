// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace additionalProperties.Models
{
    public partial class PetApInPropertiesWithApstring : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteNumberValue(Id);
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Status != null)
            {
                writer.WritePropertyName("status");
                writer.WriteBooleanValue(Status.Value);
            }
            writer.WritePropertyName("@odata.location");
            writer.WriteStringValue(OdataLocation);
            if (AdditionalProperties != null)
            {
                writer.WritePropertyName("additionalProperties");
                writer.WriteStartObject();
                foreach (var item in AdditionalProperties)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteNumberValue(item.Value);
                }
                writer.WriteEndObject();
            }
            foreach (var item in this)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
        }
        internal static PetApInPropertiesWithApstring DeserializePetApInPropertiesWithApstring(JsonElement element)
        {
            PetApInPropertiesWithApstring result = new PetApInPropertiesWithApstring();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Status = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("@odata.location"))
                {
                    result.OdataLocation = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("additionalProperties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.AdditionalProperties = new Dictionary<string, float>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        result.AdditionalProperties.Add(property0.Name, property0.Value.GetSingle());
                    }
                    continue;
                }
                result.Add(property.Name, property.Value.GetString());
            }
            return result;
        }
    }
}
