// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace ResourceIdentifierChooser.Models
{
    public partial class Model1 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Strawberry))
            {
                writer.WritePropertyName("strawberry");
                writer.WriteStringValue(Strawberry);
            }
            if (Optional.IsDefined(Mango))
            {
                writer.WritePropertyName("mango");
                writer.WriteStringValue(Mango);
            }
            writer.WritePropertyName("tags");
            writer.WriteStartObject();
            foreach (var item in Tags)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("location");
            writer.WriteStringValue(Location);
            writer.WriteEndObject();
        }

        internal static Model1 DeserializeModel1(JsonElement element)
        {
            Optional<string> strawberry = default;
            Optional<string> mango = default;
            IDictionary<string, string> tags = default;
            Location location = default;
            ResourceGroupResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("strawberry"))
                {
                    strawberry = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("mango"))
                {
                    mango = property.Value.GetString();
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
                if (property.NameEquals("location"))
                {
                    location = property.Value.GetString();
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
            }
            return new Model1(id, name, type, location, tags, mango.Value, strawberry.Value);
        }
    }
}
