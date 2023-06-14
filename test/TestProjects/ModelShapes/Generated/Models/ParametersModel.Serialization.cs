// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace ModelShapes.Models
{
    internal partial class ParametersModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Code))
            {
                writer.WritePropertyName("Code"u8);
                writer.WriteStringValue(Code);
            }
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("Status"u8);
                writer.WriteStringValue(Status);
            }
            writer.WriteEndObject();
        }
    }
}
