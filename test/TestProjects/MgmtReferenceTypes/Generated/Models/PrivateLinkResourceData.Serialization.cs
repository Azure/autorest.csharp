// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(PrivateLinkResourceDataConverter))]
    public partial class PrivateLinkResourceData : IUtf8JsonSerializable, IModelJsonSerializable<PrivateLinkResourceData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<PrivateLinkResourceData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<PrivateLinkResourceData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(SystemData))
            {
                writer.WritePropertyName("systemData"u8);
                JsonSerializer.Serialize(writer, SystemData);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(GroupId))
                {
                    writer.WritePropertyName("groupId"u8);
                    writer.WriteStringValue(GroupId);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(RequiredMembers))
                {
                    writer.WritePropertyName("requiredMembers"u8);
                    writer.WriteStartArray();
                    foreach (var item in RequiredMembers)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(RequiredZoneNames))
                {
                    writer.WritePropertyName("requiredZoneNames"u8);
                    writer.WriteStartArray();
                    foreach (var item in RequiredZoneNames)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        PrivateLinkResourceData IModelJsonSerializable<PrivateLinkResourceData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateLinkResourceData(document.RootElement, options);
        }

        internal static PrivateLinkResourceData DeserializePrivateLinkResourceData(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<string> groupId = default;
            Optional<IReadOnlyList<string>> requiredMembers = default;
            Optional<IReadOnlyList<string>> requiredZoneNames = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.GetRawText());
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
                        if (property0.NameEquals("groupId"u8))
                        {
                            groupId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("requiredMembers"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            requiredMembers = array;
                            continue;
                        }
                        if (property0.NameEquals("requiredZoneNames"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            requiredZoneNames = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new PrivateLinkResourceData(id, name, type, systemData.Value, groupId.Value, Optional.ToList(requiredMembers), Optional.ToList(requiredZoneNames));
        }

        BinaryData IModelSerializable<PrivateLinkResourceData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        PrivateLinkResourceData IModelSerializable<PrivateLinkResourceData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePrivateLinkResourceData(document.RootElement, options);
        }

        internal partial class PrivateLinkResourceDataConverter : JsonConverter<PrivateLinkResourceData>
        {
            public override void Write(Utf8JsonWriter writer, PrivateLinkResourceData model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override PrivateLinkResourceData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializePrivateLinkResourceData(document.RootElement);
            }
        }
    }
}
