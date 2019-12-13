// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class MyBaseTypeSerializer
    {
        internal static void Serialize(MyBaseType model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.PropB1 != null)
            {
                writer.WritePropertyName("propB1");
                writer.WriteStringValue(model.PropB1);
            }
            if (model.Helper != null)
            {
                writer.WritePropertyName("helper");
                MyBaseHelperTypeSerializer.Serialize(model.Helper, writer);
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
                    result.Helper = MyBaseHelperTypeSerializer.Deserialize(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
