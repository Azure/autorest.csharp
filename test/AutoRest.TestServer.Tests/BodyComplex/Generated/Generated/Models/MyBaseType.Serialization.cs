// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
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
            if (PropB1 != null)
            {
                writer.WriteString("propB1", PropB1);
            }
            if (Helper != null)
            {
                Helper?.Serialize(writer);
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
                    result.Helper = BodyComplex.Models.V20160229.MyBaseHelperType.Deserialize(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
