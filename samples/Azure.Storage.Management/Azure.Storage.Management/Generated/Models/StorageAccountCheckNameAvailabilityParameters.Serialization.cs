// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class StorageAccountCheckNameAvailabilityParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type);
            writer.WriteEndObject();
        }

        internal static StorageAccountCheckNameAvailabilityParameters DeserializeStorageAccountCheckNameAvailabilityParameters(JsonElement element)
        {
            StorageAccountCheckNameAvailabilityParameters result = new StorageAccountCheckNameAvailabilityParameters();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    result.Type = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
