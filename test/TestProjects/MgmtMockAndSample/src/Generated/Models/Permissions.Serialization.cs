// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class Permissions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (!(Keys is ChangeTrackingList<KeyPermission> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("keys"u8);
                writer.WriteStartArray();
                foreach (var item in Keys)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (!(Secrets is ChangeTrackingList<SecretPermission> collection0 && collection0.IsUndefined))
            {
                writer.WritePropertyName("secrets"u8);
                writer.WriteStartArray();
                foreach (var item in Secrets)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (!(Certificates is ChangeTrackingList<CertificatePermission> collection1 && collection1.IsUndefined))
            {
                writer.WritePropertyName("certificates"u8);
                writer.WriteStartArray();
                foreach (var item in Certificates)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (!(Storage is ChangeTrackingList<StoragePermission> collection2 && collection2.IsUndefined))
            {
                writer.WritePropertyName("storage"u8);
                writer.WriteStartArray();
                foreach (var item in Storage)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static Permissions DeserializePermissions(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<KeyPermission>> keys = default;
            Optional<IList<SecretPermission>> secrets = default;
            Optional<IList<CertificatePermission>> certificates = default;
            Optional<IList<StoragePermission>> storage = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keys"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<KeyPermission> array = new List<KeyPermission>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new KeyPermission(item.GetString()));
                    }
                    keys = array;
                    continue;
                }
                if (property.NameEquals("secrets"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<SecretPermission> array = new List<SecretPermission>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new SecretPermission(item.GetString()));
                    }
                    secrets = array;
                    continue;
                }
                if (property.NameEquals("certificates"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CertificatePermission> array = new List<CertificatePermission>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new CertificatePermission(item.GetString()));
                    }
                    certificates = array;
                    continue;
                }
                if (property.NameEquals("storage"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<StoragePermission> array = new List<StoragePermission>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new StoragePermission(item.GetString()));
                    }
                    storage = array;
                    continue;
                }
            }
            return new Permissions(Optional.ToList(keys), Optional.ToList(secrets), Optional.ToList(certificates), Optional.ToList(storage));
        }
    }
}
