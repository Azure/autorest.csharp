// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class MyBaseHelperType
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("MyBaseHelperType");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (PropBH1 != null)
            {
                writer.WriteString("propBH1", PropBH1);
            }
            writer.WriteEndObject();
        }
        internal static MyBaseHelperType Deserialize(JsonElement element)
        {
            var result = new MyBaseHelperType();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propBH1"))
                {
                    result.PropBH1 = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
