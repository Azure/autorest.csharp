// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class MyBaseType
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (PropB1 != null)
            {
                writer.WritePropertyName("propB1");
                writer.WriteStringValue(PropB1);
            }
            if (Helper != null)
            {
                writer.WritePropertyName("helper");
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
                    result.Helper = MyBaseHelperType.Deserialize(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
