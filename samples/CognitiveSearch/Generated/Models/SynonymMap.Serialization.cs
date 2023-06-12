// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class SynonymMap : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("format"u8);
            writer.WriteStringValue(Format.ToString());
            writer.WritePropertyName("synonyms"u8);
            writer.WriteStringValue(Synonyms);
            if (Optional.IsDefined(EncryptionKey))
            {
                writer.WritePropertyName("encryptionKey"u8);
                writer.WriteObjectValue(EncryptionKey);
            }
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("@odata.etag"u8);
                writer.WriteStringValue(ETag);
            }
            writer.WriteEndObject();
        }

        internal static SynonymMap DeserializeSynonymMap(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            SynonymMapFormat format = default;
            string synonyms = default;
            Optional<EncryptionKey> encryptionKey = default;
            Optional<string> odataEtag = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("format"u8))
                {
                    format = new SynonymMapFormat(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("synonyms"u8))
                {
                    synonyms = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("encryptionKey"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    encryptionKey = EncryptionKey.DeserializeEncryptionKey(property.Value);
                    continue;
                }
                if (property.NameEquals("@odata.etag"u8))
                {
                    odataEtag = property.Value.GetString();
                    continue;
                }
            }
            return new SynonymMap(name, format, synonyms, encryptionKey.Value, odataEtag.Value);
        }
    }
}
