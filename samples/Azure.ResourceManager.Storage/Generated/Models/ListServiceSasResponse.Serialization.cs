// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ListServiceSasResponse
    {
        internal static ListServiceSasResponse DeserializeListServiceSasResponse(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> serviceSasToken = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("serviceSasToken"u8))
                {
                    serviceSasToken = property.Value.GetString();
                    continue;
                }
            }
            return new ListServiceSasResponse(serviceSasToken.Value);
        }
    }
}
