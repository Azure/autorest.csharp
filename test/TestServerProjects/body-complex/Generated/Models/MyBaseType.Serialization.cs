// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace body_complex.Models
{
    public partial class MyBaseType
    {
        internal static MyBaseType DeserializeMyBaseType(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Kind1": return MyDerivedType.DeserializeMyDerivedType(element);
                }
            }
            return UnknownMyBaseType.DeserializeUnknownMyBaseType(element);
        }
    }
}
