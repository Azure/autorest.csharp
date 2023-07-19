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
    public partial class LegalHoldProperties : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartArray();
                foreach (var item in Tags)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ProtectedAppendWritesHistory))
            {
                writer.WritePropertyName("protectedAppendWritesHistory"u8);
                writer.WriteObjectValue(ProtectedAppendWritesHistory);
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeLegalHoldProperties(doc.RootElement, options);
        }

        internal static LegalHoldProperties DeserializeLegalHoldProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> hasLegalHold = default;
            Optional<IReadOnlyList<TagProperty>> tags = default;
            Optional<ProtectedAppendWritesHistory> protectedAppendWritesHistory = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hasLegalHold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hasLegalHold = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TagProperty> array = new List<TagProperty>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TagProperty.DeserializeTagProperty(item));
                    }
                    tags = array;
                    continue;
                }
                if (property.NameEquals("protectedAppendWritesHistory"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectedAppendWritesHistory = ProtectedAppendWritesHistory.DeserializeProtectedAppendWritesHistory(property.Value);
                    continue;
                }
            }
            return new LegalHoldProperties(Optional.ToNullable(hasLegalHold), Optional.ToList(tags), protectedAppendWritesHistory.Value);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeLegalHoldProperties(doc.RootElement, options);
        }
    }
}
