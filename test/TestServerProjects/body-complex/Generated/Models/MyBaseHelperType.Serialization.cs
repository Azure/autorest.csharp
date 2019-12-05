// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class MyBaseHelperType
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (PropBH1 != null)
            {
                writer.WritePropertyName("propBH1");
                writer.WriteStringValue(PropBH1);
            }
            writer.WriteEndObject();
        }
        public static MyBaseHelperType Deserialize(JsonElement element)
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
