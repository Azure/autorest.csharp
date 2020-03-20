// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class IntWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field1 != null)
            {
                writer.WritePropertyName("field1");
                writer.WriteNumberValue(Field1.Value);
            }
            if (Field2 != null)
            {
                writer.WritePropertyName("field2");
                writer.WriteNumberValue(Field2.Value);
            }
            writer.WriteEndObject();
        }

        internal static IntWrapper DeserializeIntWrapper(JsonElement element)
        {
            IntWrapper result;
            int? field1 = default;
            int? field2 = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field1 = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("field2"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field2 = property.Value.GetInt32();
                    continue;
                }
            }
            result = new IntWrapper(field1, field2);
            return result;
        }
    }
}
