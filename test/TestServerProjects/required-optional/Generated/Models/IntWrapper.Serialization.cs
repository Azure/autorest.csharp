// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace required_optional.Models
{
    public partial class IntWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value"u8);
            writer.WriteNumberValue(Value);
            writer.WriteEndObject();
        }
    }
}
