// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace additionalProperties.Models
{
    public partial class PetAPInPropertiesWithAPString : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteNumberValue(Id);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            writer.WritePropertyName("@odata.location"u8);
            writer.WriteStringValue(OdataLocation);
            if (Optional.IsCollectionDefined(AdditionalProperties))
            {
                writer.WritePropertyName("additionalProperties"u8);
                writer.WriteStartObject();
                foreach (var item in AdditionalProperties)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteNumberValue(item.Value);
                }
                writer.WriteEndObject();
            }
            foreach (var item in MoreAdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
        }

        internal static PetAPInPropertiesWithAPString DeserializePetAPInPropertiesWithAPString(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int id = default;
            Optional<string> name = default;
            Optional<bool> status = default;
            string odataLocation = default;
            Optional<IDictionary<string, float>> additionalProperties = default;
            IDictionary<string, string> moreAdditionalProperties = default;
            Dictionary<string, string> additionalPropertiesDictionary = new Dictionary<string, string>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("@odata.location"u8))
                {
                    odataLocation = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("additionalProperties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, float> dictionary = new Dictionary<string, float>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetSingle());
                    }
                    additionalProperties = dictionary;
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetString());
            }
            moreAdditionalProperties = additionalPropertiesDictionary;
            return new PetAPInPropertiesWithAPString(id, name.Value, Optional.ToNullable(status), odataLocation, Optional.ToDictionary(additionalProperties), moreAdditionalProperties);
        }
    }
}
