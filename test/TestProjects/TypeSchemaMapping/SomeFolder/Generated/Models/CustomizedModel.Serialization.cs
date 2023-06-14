// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;
using NamespaceForEnums;

namespace CustomNamespace
{
    internal partial class CustomizedModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(PropertyRenamedAndTypeChanged))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteNumberValue(PropertyRenamedAndTypeChanged.Value);
            }
            if (Optional.IsDefined(_field))
            {
                writer.WritePropertyName("PropertyToField"u8);
                writer.WriteStringValue(_field);
            }
            writer.WritePropertyName("Fruit"u8);
            writer.WriteStringValue(CustomizedFancyField.ToSerialString());
            writer.WritePropertyName("DaysOfWeek"u8);
            writer.WriteStringValue(DaysOfWeek.ToString());
            writer.WriteEndObject();
        }
    }
}
