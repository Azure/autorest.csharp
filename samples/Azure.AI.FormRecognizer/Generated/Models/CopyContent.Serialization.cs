// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class CopyContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("targetResourceId"u8);
            writer.WriteStringValue(TargetResourceId);
            writer.WritePropertyName("targetResourceRegion"u8);
            writer.WriteStringValue(TargetResourceRegion);
            writer.WritePropertyName("copyAuthorization"u8);
            writer.WriteObjectValue(CopyAuthorization);
            writer.WriteEndObject();
        }
    }
}
