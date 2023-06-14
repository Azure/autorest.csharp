// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class DeletedShare : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("deletedShareName"u8);
            writer.WriteStringValue(DeletedShareName);
            writer.WritePropertyName("deletedShareVersion"u8);
            writer.WriteStringValue(DeletedShareVersion);
            writer.WriteEndObject();
        }
    }
}
