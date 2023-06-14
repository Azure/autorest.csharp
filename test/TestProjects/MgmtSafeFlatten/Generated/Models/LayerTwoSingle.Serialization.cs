// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtSafeFlatten.Models
{
    internal partial class LayerTwoSingle : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(MyProp))
            {
                writer.WritePropertyName("myProp"u8);
                writer.WriteStringValue(MyProp);
            }
            writer.WriteEndObject();
        }

        internal static LayerTwoSingle DeserializeLayerTwoSingle(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> myProp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("myProp"u8))
                {
                    myProp = property.Value.GetString();
                    continue;
                }
            }
            return new LayerTwoSingle(myProp.Value);
        }
    }
}
