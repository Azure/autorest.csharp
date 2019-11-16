// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class ComponentsSchemasSmartSalmonAdditionalproperties
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("components·schemas·smart_salmon·additionalproperties");
            }
            else
            {
                writer.WriteStartObject();
            }
            writer.WriteEndObject();
        }
        internal static ComponentsSchemasSmartSalmonAdditionalproperties Deserialize(JsonElement element)
        {
            var result = new ComponentsSchemasSmartSalmonAdditionalproperties();
            foreach (var property in element.EnumerateObject())
            {
            }
            return result;
        }
    }
}
