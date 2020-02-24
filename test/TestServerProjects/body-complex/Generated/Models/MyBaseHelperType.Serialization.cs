// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class MyBaseHelperType : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (PropBh1 != null)
            {
                writer.WritePropertyName("propBH1");
                writer.WriteStringValue(PropBh1);
            }
            writer.WriteEndObject();
        }
        internal static MyBaseHelperType DeserializeMyBaseHelperType(JsonElement element)
        {
            MyBaseHelperType result = new MyBaseHelperType();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propBH1"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.PropBh1 = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
