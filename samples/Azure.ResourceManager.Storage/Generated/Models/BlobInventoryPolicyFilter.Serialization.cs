// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobInventoryPolicyFilter : IUtf8JsonSerializable, IModelJsonSerializable<BlobInventoryPolicyFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<BlobInventoryPolicyFilter>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BlobInventoryPolicyFilter>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

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
            if (Optional.IsCollectionDefined(BlobTypes))
            {
                writer.WritePropertyName("blobTypes"u8);
                writer.WriteStartArray();
                foreach (var item in BlobTypes)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(IncludeBlobVersions))
            {
                writer.WritePropertyName("includeBlobVersions"u8);
                writer.WriteBooleanValue(IncludeBlobVersions.Value);
            }
            if (Optional.IsDefined(IncludeSnapshots))
            {
                writer.WritePropertyName("includeSnapshots"u8);
                writer.WriteBooleanValue(IncludeSnapshots.Value);
            }
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static BlobInventoryPolicyFilter DeserializeBlobInventoryPolicyFilter(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> prefixMatch = default;
            Optional<IList<string>> blobTypes = default;
            Optional<bool> includeBlobVersions = default;
            Optional<bool> includeSnapshots = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    blobTypes = array;
                    continue;
                }
                if (property.NameEquals("includeBlobVersions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    includeBlobVersions = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("includeSnapshots"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    includeSnapshots = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new BlobInventoryPolicyFilter(Optional.ToList(prefixMatch), Optional.ToList(blobTypes), Optional.ToNullable(includeBlobVersions), Optional.ToNullable(includeSnapshots), rawData);
        }

        BlobInventoryPolicyFilter IModelJsonSerializable<BlobInventoryPolicyFilter>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeBlobInventoryPolicyFilter(doc.RootElement, options);
        }

        BinaryData IModelSerializable<BlobInventoryPolicyFilter>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        BlobInventoryPolicyFilter IModelSerializable<BlobInventoryPolicyFilter>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeBlobInventoryPolicyFilter(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="BlobInventoryPolicyFilter"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="BlobInventoryPolicyFilter"/> to convert. </param>
        public static implicit operator RequestContent(BlobInventoryPolicyFilter model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="BlobInventoryPolicyFilter"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator BlobInventoryPolicyFilter(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeBlobInventoryPolicyFilter(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
