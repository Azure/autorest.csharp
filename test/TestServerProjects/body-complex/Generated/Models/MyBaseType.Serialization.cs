// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class MyBaseType : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind");
            writer.WriteStringValue(Kind);
            if (PropB1 != null)
            {
                writer.WritePropertyName("propB1");
                writer.WriteStringValue(PropB1);
            }
            if (PropBH1 != null)
            {
                writer.WritePropertyName("propBH1");
                writer.WriteStringValue(PropBH1);
            }
            writer.WriteEndObject();
        }
        internal static body_complex.Models.MyBaseType DeserializeMyBaseType(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("kind", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Kind1": return body_complex.Models.MyDerivedType.DeserializeMyDerivedType(element);
                }
            }
            body_complex.Models.MyBaseType result = new body_complex.Models.MyBaseType();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"))
                {
                    result.Kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("propB1"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.PropB1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("propBH1"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
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
