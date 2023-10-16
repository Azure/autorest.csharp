// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class DedicatedHostAvailableCapacity : IUtf8JsonSerializable, IModelJsonSerializable<DedicatedHostAvailableCapacity>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DedicatedHostAvailableCapacity>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DedicatedHostAvailableCapacity>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(AllocatableVms))
            {
                writer.WritePropertyName("allocatableVMs"u8);
                writer.WriteStartArray();
                foreach (var item in AllocatableVms)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        DedicatedHostAvailableCapacity IModelJsonSerializable<DedicatedHostAvailableCapacity>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDedicatedHostAvailableCapacity(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DedicatedHostAvailableCapacity>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        DedicatedHostAvailableCapacity IModelSerializable<DedicatedHostAvailableCapacity>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDedicatedHostAvailableCapacity(document.RootElement, options);
        }

        internal static DedicatedHostAvailableCapacity DeserializeDedicatedHostAvailableCapacity(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<DedicatedHostAllocatableVm>> allocatableVms = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("allocatableVMs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DedicatedHostAllocatableVm> array = new List<DedicatedHostAllocatableVm>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DedicatedHostAllocatableVm.DeserializeDedicatedHostAllocatableVm(item));
                    }
                    allocatableVms = array;
                    continue;
                }
            }
            return new DedicatedHostAvailableCapacity(Optional.ToList(allocatableVms));
        }
    }
}
