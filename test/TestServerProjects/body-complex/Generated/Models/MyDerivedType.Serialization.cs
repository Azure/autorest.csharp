// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class MyDerivedTypeSerializer
    {
        internal static void Serialize(MyDerivedType model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.PropD1 != null)
            {
                writer.WritePropertyName("propD1");
                writer.WriteStringValue(model.PropD1);
            }

            writer.WritePropertyName("kind");
            writer.WriteStringValue(model.Kind);
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
        internal static MyDerivedType Deserialize(JsonElement element)
        {
            var result = new MyDerivedType();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propD1"))
                {
                    result.PropD1 = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("kind"))
                {
                    result.Kind = property.Value.GetString();
                    continue;
                }
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
