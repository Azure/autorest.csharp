// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class MyBaseType
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("MyBaseType");
            }
            else
            {
                writer.WriteStartObject();
            }
            writer.WriteString("kind", Kind);
            if (PropB1 != null)
            {
                writer.WriteString("propB1", PropB1);
            }
            if (Helper != null)
            {
                Helper?.Serialize(writer, true);
            }
            writer.WriteEndObject();
        }
        internal static MyBaseType Deserialize(JsonElement element)
        {
            var result = new MyBaseType();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propB1"))
                {
                    result.PropB1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("helper"))
                {
                    result.Helper = MyBaseHelperType.Deserialize(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
