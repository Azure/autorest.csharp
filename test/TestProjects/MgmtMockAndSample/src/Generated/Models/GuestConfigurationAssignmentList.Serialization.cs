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
    internal partial class GuestConfigurationAssignmentList : IUtf8JsonSerializable, IModelJsonSerializable<GuestConfigurationAssignmentList>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<GuestConfigurationAssignmentList>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<GuestConfigurationAssignmentList>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStartArray();
                foreach (var item in Value)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        GuestConfigurationAssignmentList IModelJsonSerializable<GuestConfigurationAssignmentList>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeGuestConfigurationAssignmentList(document.RootElement, options);
        }

        BinaryData IModelSerializable<GuestConfigurationAssignmentList>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        GuestConfigurationAssignmentList IModelSerializable<GuestConfigurationAssignmentList>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeGuestConfigurationAssignmentList(document.RootElement, options);
        }

        internal static GuestConfigurationAssignmentList DeserializeGuestConfigurationAssignmentList(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<GuestConfigurationAssignmentData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<GuestConfigurationAssignmentData> array = new List<GuestConfigurationAssignmentData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(GuestConfigurationAssignmentData.DeserializeGuestConfigurationAssignmentData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new GuestConfigurationAssignmentList(Optional.ToList(value));
        }
    }
}
