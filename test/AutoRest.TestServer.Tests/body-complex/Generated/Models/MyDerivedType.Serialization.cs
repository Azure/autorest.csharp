// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class MyDerivedType
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (PropD1 != null)
            {
                writer.WritePropertyName("propD1");
                writer.WriteStringValue(PropD1);
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
            }
            return result;
        }
    }
}
