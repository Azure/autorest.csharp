// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ItemWarning : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Key != null)
            {
                writer.WritePropertyName("key");
                writer.WriteStringValue(Key);
            }
            if (Message != null)
            {
                writer.WritePropertyName("message");
                writer.WriteStringValue(Message);
            }
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Details != null)
            {
                writer.WritePropertyName("details");
                writer.WriteStringValue(Details);
            }
            if (DocumentationLink != null)
            {
                writer.WritePropertyName("documentationLink");
                writer.WriteStringValue(DocumentationLink);
            }
            writer.WriteEndObject();
        }
        internal static ItemWarning DeserializeItemWarning(JsonElement element)
        {
            ItemWarning result = new ItemWarning();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("key"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Key = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Message = property.Value.GetString();
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
                if (property.NameEquals("details"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Details = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("documentationLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DocumentationLink = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
