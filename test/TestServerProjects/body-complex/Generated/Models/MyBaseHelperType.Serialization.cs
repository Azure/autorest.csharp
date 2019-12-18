// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class MyBaseHelperType : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (PropBH1 != null)
            {
                writer.WritePropertyName("propBH1");
                writer.WriteStringValue(PropBH1);
            }
            writer.WriteEndObject();
        }
        internal static MyBaseHelperType DeserializeMyBaseHelperType(JsonElement element)
        {
            var result = new MyBaseHelperType();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propBH1"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.PropBH1 = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
