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
    public partial class ImmutabilityPolicyProperties : IUtf8JsonSerializable, IModelJsonSerializable<ImmutabilityPolicyProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ImmutabilityPolicyProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ImmutabilityPolicyProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Etag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(Etag.Value.ToString());
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(UpdateHistory))
            {
                writer.WritePropertyName("updateHistory"u8);
                writer.WriteStartArray();
                foreach (var item in UpdateHistory)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(ImmutabilityPeriodSinceCreationInDays))
                {
                    writer.WritePropertyName("immutabilityPeriodSinceCreationInDays"u8);
                    writer.WriteNumberValue(ImmutabilityPeriodSinceCreationInDays.Value);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(State))
                {
                    writer.WritePropertyName("state"u8);
                    writer.WriteStringValue(State.Value.ToString());
                }
                if (Optional.IsDefined(AllowProtectedAppendWrites))
                {
                    writer.WritePropertyName("allowProtectedAppendWrites"u8);
                    writer.WriteBooleanValue(AllowProtectedAppendWrites.Value);
                }
                if (Optional.IsDefined(AllowProtectedAppendWritesAll))
                {
                    writer.WritePropertyName("allowProtectedAppendWritesAll"u8);
                    writer.WriteBooleanValue(AllowProtectedAppendWritesAll.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        ImmutabilityPolicyProperties IModelJsonSerializable<ImmutabilityPolicyProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeImmutabilityPolicyProperties(document.RootElement, options);
        }

        BinaryData IModelSerializable<ImmutabilityPolicyProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ImmutabilityPolicyProperties IModelSerializable<ImmutabilityPolicyProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeImmutabilityPolicyProperties(document.RootElement, options);
        }

        internal static ImmutabilityPolicyProperties DeserializeImmutabilityPolicyProperties(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ETag> etag = default;
            Optional<IReadOnlyList<UpdateHistoryProperty>> updateHistory = default;
            Optional<int> immutabilityPeriodSinceCreationInDays = default;
            Optional<ImmutabilityPolicyState> state = default;
            Optional<bool> allowProtectedAppendWrites = default;
            Optional<bool> allowProtectedAppendWritesAll = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    etag = new ETag(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("updateHistory"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<UpdateHistoryProperty> array = new List<UpdateHistoryProperty>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(UpdateHistoryProperty.DeserializeUpdateHistoryProperty(item));
                    }
                    updateHistory = array;
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("immutabilityPeriodSinceCreationInDays"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            immutabilityPeriodSinceCreationInDays = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("state"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            state = new ImmutabilityPolicyState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("allowProtectedAppendWrites"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allowProtectedAppendWrites = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("allowProtectedAppendWritesAll"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allowProtectedAppendWritesAll = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ImmutabilityPolicyProperties(Optional.ToNullable(etag), Optional.ToList(updateHistory), Optional.ToNullable(immutabilityPeriodSinceCreationInDays), Optional.ToNullable(state), Optional.ToNullable(allowProtectedAppendWrites), Optional.ToNullable(allowProtectedAppendWritesAll));
        }
    }
}
