// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class ReadonlyObj
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("readonly-obj");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Id != null)
            {
                writer.WriteString("id", Id);
            }
            if (Size != null)
            {
                writer.WriteNumber("size", Size.Value);
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
