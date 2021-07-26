// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace OmitOperationGroups
{
    public partial class ModelY : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(E))
            {
                writer.WritePropertyName("e");
                writer.WriteStringValue(E);
            }
            writer.WriteEndObject();
        }

        internal static ModelY DeserializeModelY(JsonElement element)
        {
            Optional<string> e = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("e"))
                {
                    e = property.Value.GetString();
                    continue;
                }
            }
            return new ModelY(e.Value);
        }
    }
}
