// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ServiceSasContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("canonicalizedResource"u8);
            writer.WriteStringValue(CanonicalizedResource);
            if (Optional.IsDefined(Resource))
            {
                writer.WritePropertyName("signedResource"u8);
                writer.WriteStringValue(Resource.Value.ToString());
            }
            if (Optional.IsDefined(Permissions))
            {
                writer.WritePropertyName("signedPermission"u8);
                writer.WriteStringValue(Permissions.Value.ToString());
            }
            if (Optional.IsDefined(IPAddressOrRange))
            {
                writer.WritePropertyName("signedIp"u8);
                writer.WriteStringValue(IPAddressOrRange);
            }
            if (Optional.IsDefined(Protocols))
            {
                writer.WritePropertyName("signedProtocol"u8);
                writer.WriteStringValue(Protocols.Value.ToSerialString());
            }
            if (Optional.IsDefined(SharedAccessStartOn))
            {
                writer.WritePropertyName("signedStart"u8);
                writer.WriteStringValue(SharedAccessStartOn.Value, "O");
            }
            if (Optional.IsDefined(SharedAccessExpiryOn))
            {
                writer.WritePropertyName("signedExpiry"u8);
                writer.WriteStringValue(SharedAccessExpiryOn.Value, "O");
            }
            if (Optional.IsDefined(Identifier))
            {
                writer.WritePropertyName("signedIdentifier"u8);
                writer.WriteStringValue(Identifier);
            }
            if (Optional.IsDefined(PartitionKeyStart))
            {
                writer.WritePropertyName("startPk"u8);
                writer.WriteStringValue(PartitionKeyStart);
            }
            if (Optional.IsDefined(PartitionKeyEnd))
            {
                writer.WritePropertyName("endPk"u8);
                writer.WriteStringValue(PartitionKeyEnd);
            }
            if (Optional.IsDefined(RowKeyStart))
            {
                writer.WritePropertyName("startRk"u8);
                writer.WriteStringValue(RowKeyStart);
            }
            if (Optional.IsDefined(RowKeyEnd))
            {
                writer.WritePropertyName("endRk"u8);
                writer.WriteStringValue(RowKeyEnd);
            }
            if (Optional.IsDefined(KeyToSign))
            {
                writer.WritePropertyName("keyToSign"u8);
                writer.WriteStringValue(KeyToSign);
            }
            if (Optional.IsDefined(CacheControl))
            {
                writer.WritePropertyName("rscc"u8);
                writer.WriteStringValue(CacheControl);
            }
            if (Optional.IsDefined(ContentDisposition))
            {
                writer.WritePropertyName("rscd"u8);
                writer.WriteStringValue(ContentDisposition);
            }
            if (Optional.IsDefined(ContentEncoding))
            {
                writer.WritePropertyName("rsce"u8);
                writer.WriteStringValue(ContentEncoding);
            }
            if (Optional.IsDefined(ContentLanguage))
            {
                writer.WritePropertyName("rscl"u8);
                writer.WriteStringValue(ContentLanguage);
            }
            if (Optional.IsDefined(ContentType))
            {
                writer.WritePropertyName("rsct"u8);
                writer.WriteStringValue(ContentType);
            }
            writer.WriteEndObject();
        }
    }
}
