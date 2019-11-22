// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Cookiecuttershark
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("cookiecuttershark");
            }
            else
            {
                writer.WriteStartObject();
            }
            writer.WriteEndObject();
        }
        internal static Cookiecuttershark Deserialize(JsonElement element)
        {
            var result = new Cookiecuttershark();
            foreach (var property in element.EnumerateObject())
            {
            }
            return result;
        }
    }
}
