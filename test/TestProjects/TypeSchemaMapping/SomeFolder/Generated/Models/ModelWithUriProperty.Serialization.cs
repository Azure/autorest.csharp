// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithUriProperty : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Uri))
            {
                writer.WritePropertyName("Uri"u8);
                writer.WriteStringValue(Uri.AbsoluteUri);
            }
            writer.WriteEndObject();
        }

        internal static ModelWithUriProperty DeserializeModelWithUriProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Uri> uri = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Uri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    uri = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new ModelWithUriProperty(uri.Value);
        }
    }
}
