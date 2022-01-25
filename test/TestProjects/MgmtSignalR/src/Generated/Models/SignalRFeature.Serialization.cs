// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtSignalR.Models
{
    public partial class SignalRFeature : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("flag");
            writer.WriteStringValue(Flag.ToString());
            writer.WritePropertyName("value");
            writer.WriteStringValue(Value);
            if (Optional.IsCollectionDefined(Properties))
            {
                writer.WritePropertyName("properties");
                writer.WriteStartObject();
                foreach (var item in Properties)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        internal static SignalRFeature DeserializeSignalRFeature(JsonElement element)
        {
            FeatureFlags flag = default;
            string value = default;
            Optional<IDictionary<string, string>> properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("flag"))
                {
                    flag = new FeatureFlags(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    value = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    properties = dictionary;
                    continue;
                }
            }
            return new SignalRFeature(flag, value, Optional.ToDictionary(properties));
        }
    }
}
