// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class SmartSalmon
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("smart_salmon");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (CollegeDegree != null)
            {
                writer.WriteString("college_degree", CollegeDegree);
            }
            writer.WriteEndObject();
        }
        internal static SmartSalmon Deserialize(JsonElement element)
        {
            var result = new SmartSalmon();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("college_degree"))
                {
                    result.CollegeDegree = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
