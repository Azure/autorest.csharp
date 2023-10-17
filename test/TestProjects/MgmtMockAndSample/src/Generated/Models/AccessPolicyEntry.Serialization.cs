// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtMockAndSample.Models
{
    public partial class AccessPolicyEntry : IUtf8JsonSerializable, IModelJsonSerializable<AccessPolicyEntry>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AccessPolicyEntry>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AccessPolicyEntry>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("tenantId"u8);
            writer.WriteStringValue(TenantId);
            writer.WritePropertyName("objectId"u8);
            writer.WriteStringValue(ObjectId);
            if (Optional.IsDefined(ApplicationId))
            {
                writer.WritePropertyName("applicationId"u8);
                writer.WriteStringValue(ApplicationId.Value);
            }
            writer.WritePropertyName("permissions"u8);
            writer.WriteObjectValue(Permissions);
            writer.WriteEndObject();
        }

        AccessPolicyEntry IModelJsonSerializable<AccessPolicyEntry>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAccessPolicyEntry(document.RootElement, options);
        }

        BinaryData IModelSerializable<AccessPolicyEntry>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        AccessPolicyEntry IModelSerializable<AccessPolicyEntry>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAccessPolicyEntry(document.RootElement, options);
        }

        internal static AccessPolicyEntry DeserializeAccessPolicyEntry(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Guid tenantId = default;
            string objectId = default;
            Optional<Guid> applicationId = default;
            Permissions permissions = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tenantId"u8))
                {
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("objectId"u8))
                {
                    objectId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("applicationId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    applicationId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("permissions"u8))
                {
                    permissions = Permissions.DeserializePermissions(property.Value);
                    continue;
                }
            }
            return new AccessPolicyEntry(tenantId, objectId, Optional.ToNullable(applicationId), permissions);
        }
    }
}
