// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class ReadonlyObj : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Id != null)
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            if (Size != null)
            {
                writer.WritePropertyName("size");
                writer.WriteNumberValue(Size.Value);
            }
            writer.WriteEndObject();
        }
        internal static ReadonlyObj DeserializeReadonlyObj(JsonElement element)
        {
            ReadonlyObj result = new ReadonlyObj();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("size"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Size = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
