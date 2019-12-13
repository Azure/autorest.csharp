// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DotSalmonSerializer
    {
        internal static void Serialize(DotSalmon model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Location != null)
            {
                writer.WritePropertyName("location");
                writer.WriteStringValue(model.Location);
            }
            if (model.Iswild != null)
            {
                writer.WritePropertyName("iswild");
                writer.WriteBooleanValue(model.Iswild.Value);
            }

            writer.WritePropertyName("fish.type");
            writer.WriteStringValue(model.FishType);
            if (model.Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(model.Species);
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

                if (property.NameEquals("fish.type"))
                {
                    result.FishType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    result.Species = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
