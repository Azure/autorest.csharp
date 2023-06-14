// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class ByteWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Field))
            {
                writer.WritePropertyName("field"u8);
                writer.WriteBase64StringValue(Field, "D");
            }
            writer.WriteEndObject();
        }

        internal static ByteWrapper DeserializeByteWrapper(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<byte[]> field = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field = property.Value.GetBytesFromBase64("D");
                    continue;
                }
            }
            return new ByteWrapper(field.Value);
        }
    }
}
