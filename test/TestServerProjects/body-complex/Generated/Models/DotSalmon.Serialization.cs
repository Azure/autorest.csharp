// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DotSalmon
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Location != null)
            {
                writer.WritePropertyName("location");
                writer.WriteStringValue(Location);
            }
            if (Iswild != null)
            {
                writer.WritePropertyName("iswild");
                writer.WriteBooleanValue(Iswild.Value);
            }
            writer.WriteEndObject();
        }
        internal static DotSalmon Deserialize(JsonElement element)
        {
            var result = new DotSalmon();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"))
                {
                    result.Location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("iswild"))
                {
                    result.Iswild = property.Value.GetBoolean();
                    continue;
                }
            }
            return result;
        }
    }
}
