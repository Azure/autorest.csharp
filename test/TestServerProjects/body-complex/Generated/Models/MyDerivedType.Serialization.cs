// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class MyDerivedType
    {
        internal static MyDerivedType DeserializeMyDerivedType(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> propD1 = default;
            MyKind kind = default;
            Optional<string> propB1 = default;
            Optional<string> propBH1 = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propD1"u8))
                {
                    propD1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = new MyKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("propB1"u8))
                {
                    propB1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("helper"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("propBH1"u8))
                        {
                            propBH1 = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new MyDerivedType(kind, propB1.Value, propBH1.Value, propD1.Value);
        }
    }
}
