// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class MyBaseHelperTypeSerializer
    {
        internal static void Serialize(MyBaseHelperType model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.PropBH1 != null)
            {
                writer.WritePropertyName("propBH1");
                writer.WriteStringValue(model.PropBH1);
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
