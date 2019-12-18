// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class MyBaseType : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind");
            writer.WriteStringValue(Kind);
            if (PropB1 != null)
            {
                writer.WritePropertyName("propB1");
                writer.WriteStringValue(PropB1);
            }
            if (Helper != null)
            {
                writer.WritePropertyName("helper");
                writer.WriteObjectValue(Helper);
            }
            writer.WriteEndObject();
        }
        internal static MyBaseType DeserializeMyBaseType(JsonElement element)
        {
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Kind1": return MyDerivedType.DeserializeMyDerivedType(element);
                }
            }
            var result = new MyBaseType();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"))
                {
                    result.Kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("propB1"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.PropB1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("helper"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Helper = MyBaseHelperType.DeserializeMyBaseHelperType(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
