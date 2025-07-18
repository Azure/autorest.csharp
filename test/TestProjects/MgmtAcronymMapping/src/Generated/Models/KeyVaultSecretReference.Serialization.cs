// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtAcronymMapping.Models
{
    public partial class KeyVaultSecretReference : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("secretUrl"u8);
            writer.WriteStringValue(SecretUri.AbsoluteUri);
            writer.WritePropertyName("sourceVault"u8);
            ((IJsonModel<WritableSubResource>)SourceVault).Write(writer, ModelSerializationExtensions.WireOptions);
            writer.WriteEndObject();
        }

        internal static KeyVaultSecretReference DeserializeKeyVaultSecretReference(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri secretUrl = default;
            WritableSubResource sourceVault = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("secretUrl"u8))
                {
                    secretUrl = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourceVault"u8))
                {
                    sourceVault = ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, MgmtAcronymMappingContext.Default);
                    continue;
                }
            }
            return new KeyVaultSecretReference(secretUrl, sourceVault);
        }
    }
}
