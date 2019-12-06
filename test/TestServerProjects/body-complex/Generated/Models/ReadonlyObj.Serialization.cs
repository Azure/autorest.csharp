// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class ReadonlyObj
    {
        internal void Serialize(Utf8JsonWriter writer)
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
        internal static ReadonlyObj Deserialize(JsonElement element)
        {
            var result = new ReadonlyObj();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("size"))
                {
                    result.Size = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
