// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(SystemDataConverter))]
    public partial class SystemData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(CreatedBy))
            {
                writer.WritePropertyName("createdBy"u8);
                writer.WriteStringValue(CreatedBy);
            }
            if (Optional.IsDefined(CreatedByType))
            {
                writer.WritePropertyName("createdByType"u8);
                writer.WriteStringValue(CreatedByType.Value.ToString());
            }
            if (Optional.IsDefined(CreatedOn))
            {
                writer.WritePropertyName("createdAt"u8);
                writer.WriteStringValue(CreatedOn.Value, "O");
            }
            if (Optional.IsDefined(LastModifiedBy))
            {
                writer.WritePropertyName("lastModifiedBy"u8);
                writer.WriteStringValue(LastModifiedBy);
            }
            if (Optional.IsDefined(LastModifiedByType))
            {
                writer.WritePropertyName("lastModifiedByType"u8);
                writer.WriteStringValue(LastModifiedByType.Value.ToString());
            }
            if (Optional.IsDefined(LastModifiedOn))
            {
                writer.WritePropertyName("lastModifiedAt"u8);
                writer.WriteStringValue(LastModifiedOn.Value, "O");
            }
            writer.WriteEndObject();
        }

        internal static SystemData DeserializeSystemData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> createdBy = default;
            Optional<CreatedByType> createdByType = default;
            Optional<DateTimeOffset> createdAt = default;
            Optional<string> lastModifiedBy = default;
            Optional<CreatedByType> lastModifiedByType = default;
            Optional<DateTimeOffset> lastModifiedAt = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("createdBy"u8))
                {
                    createdBy = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("createdByType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    createdByType = new CreatedByType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("createdAt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    createdAt = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastModifiedBy"u8))
                {
                    lastModifiedBy = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lastModifiedByType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastModifiedByType = new CreatedByType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("lastModifiedAt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastModifiedAt = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new SystemData(createdBy.Value, Optional.ToNullable(createdByType), Optional.ToNullable(createdAt), lastModifiedBy.Value, Optional.ToNullable(lastModifiedByType), Optional.ToNullable(lastModifiedAt));
        }

        internal partial class SystemDataConverter : JsonConverter<SystemData>
        {
            public override void Write(Utf8JsonWriter writer, SystemData model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override SystemData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeSystemData(document.RootElement);
            }
        }
    }
}
