// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class ReadonlyObjSerializer
    {
        internal static void Serialize(ReadonlyObj model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Id != null)
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(model.Id);
            }
            if (model.Size != null)
            {
                writer.WritePropertyName("size");
                writer.WriteNumberValue(model.Size.Value);
            }
            writer.WriteEndObject();
        }
        internal static ReadonlyObj Deserialize(JsonElement element)
        {
            var result = new ReadonlyObj();
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
