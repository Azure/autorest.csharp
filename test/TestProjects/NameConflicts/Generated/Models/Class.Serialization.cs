// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace NameConflicts.Models
{
    public partial class Class : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (In != null)
            {
                writer.WritePropertyName("in");
                writer.WriteStringValue(In);
            }
            if (As != null)
            {
                writer.WritePropertyName("as");
                writer.WriteStringValue(As);
            }
            if (Namespace != null)
            {
                writer.WritePropertyName("namespace");
                writer.WriteStringValue(Namespace);
            }
            writer.WriteEndObject();
        }

        internal static Class DeserializeClass(JsonElement element)
        {
            string @in = default;
            string @as = default;
            string @namespace = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("in"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    @in = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("as"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    @as = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("namespace"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    @namespace = property.Value.GetString();
                    continue;
                }
            }
            return new Class(@in, @as, @namespace);
        }
    }
}
