// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ManagementPolicyFilter : IUtf8JsonSerializable, IModelJsonSerializable<ManagementPolicyFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ManagementPolicyFilter>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ManagementPolicyFilter>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(PrefixMatch))
            {
                writer.WritePropertyName("prefixMatch"u8);
                writer.WriteStartArray();
                foreach (var item in PrefixMatch)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("blobTypes"u8);
            writer.WriteStartArray();
            foreach (var item in BlobTypes)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsCollectionDefined(BlobIndexMatch))
            {
                writer.WritePropertyName("blobIndexMatch"u8);
                writer.WriteStartArray();
                foreach (var item in BlobIndexMatch)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        ManagementPolicyFilter IModelJsonSerializable<ManagementPolicyFilter>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeManagementPolicyFilter(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ManagementPolicyFilter>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ManagementPolicyFilter IModelSerializable<ManagementPolicyFilter>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeManagementPolicyFilter(document.RootElement, options);
        }

        internal static ManagementPolicyFilter DeserializeManagementPolicyFilter(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> prefixMatch = default;
            IList<string> blobTypes = default;
            Optional<IList<TagFilter>> blobIndexMatch = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("prefixMatch"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    prefixMatch = array;
                    continue;
                }
                if (property.NameEquals("blobTypes"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    blobTypes = array;
                    continue;
                }
                if (property.NameEquals("blobIndexMatch"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TagFilter> array = new List<TagFilter>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TagFilter.DeserializeTagFilter(item));
                    }
                    blobIndexMatch = array;
                    continue;
                }
            }
            return new ManagementPolicyFilter(Optional.ToList(prefixMatch), blobTypes, Optional.ToList(blobIndexMatch));
        }
    }
}
