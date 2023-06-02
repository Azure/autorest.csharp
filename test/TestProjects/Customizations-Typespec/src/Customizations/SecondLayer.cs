// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CustomizationsInCadl.Models
{
    [CodeGenMemberSerializationHooks(nameof(IntToBeChanged), SerializationValueHook = nameof(WriteIntToBeChanged), DeserializationValueHook = nameof(ReadIntToBeChanged))]
    public partial class SecondLayer : FirstLayer
    {
        internal void WriteIntToBeChanged(Utf8JsonWriter writer)
        {
            writer.WriteNumberValue(IntToBeChanged.Value + 1);
        }

        internal static void ReadIntToBeChanged(JsonProperty property, ref Optional<int> intToBeChanged)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            intToBeChanged = property.Value.GetInt32() - 1;
        }
    }
}
