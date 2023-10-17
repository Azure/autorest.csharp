// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    internal partial class DiskEncryptionSetList : IUtf8JsonSerializable, IModelJsonSerializable<DiskEncryptionSetList>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DiskEncryptionSetList>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DiskEncryptionSetList>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value"u8);
            writer.WriteStartArray();
            foreach (var item in Value)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(NextLink))
            {
                writer.WritePropertyName("nextLink"u8);
                writer.WriteStringValue(NextLink);
            }
            writer.WriteEndObject();
        }

        DiskEncryptionSetList IModelJsonSerializable<DiskEncryptionSetList>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDiskEncryptionSetList(document.RootElement, options);
        }

        BinaryData IModelSerializable<DiskEncryptionSetList>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        DiskEncryptionSetList IModelSerializable<DiskEncryptionSetList>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDiskEncryptionSetList(document.RootElement, options);
        }

        internal static DiskEncryptionSetList DeserializeDiskEncryptionSetList(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<DiskEncryptionSetData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<DiskEncryptionSetData> array = new List<DiskEncryptionSetData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DiskEncryptionSetData.DeserializeDiskEncryptionSetData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new DiskEncryptionSetList(value, nextLink.Value);
        }
    }
}
