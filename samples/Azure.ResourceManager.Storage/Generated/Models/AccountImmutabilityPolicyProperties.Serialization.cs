// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class AccountImmutabilityPolicyProperties : IUtf8JsonSerializable, IModelJsonSerializable<AccountImmutabilityPolicyProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AccountImmutabilityPolicyProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AccountImmutabilityPolicyProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ImmutabilityPeriodSinceCreationInDays))
            {
                writer.WritePropertyName("immutabilityPeriodSinceCreationInDays"u8);
                writer.WriteNumberValue(ImmutabilityPeriodSinceCreationInDays.Value);
            }
            if (Optional.IsDefined(State))
            {
                writer.WritePropertyName("state"u8);
                writer.WriteStringValue(State.Value.ToString());
            }
            if (Optional.IsDefined(AllowProtectedAppendWrites))
            {
                writer.WritePropertyName("allowProtectedAppendWrites"u8);
                writer.WriteBooleanValue(AllowProtectedAppendWrites.Value);
            }
            writer.WriteEndObject();
        }

        AccountImmutabilityPolicyProperties IModelJsonSerializable<AccountImmutabilityPolicyProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAccountImmutabilityPolicyProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<AccountImmutabilityPolicyProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        AccountImmutabilityPolicyProperties IModelSerializable<AccountImmutabilityPolicyProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAccountImmutabilityPolicyProperties(document.RootElement, options);
        }

        internal static AccountImmutabilityPolicyProperties DeserializeAccountImmutabilityPolicyProperties(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> immutabilityPeriodSinceCreationInDays = default;
            Optional<AccountImmutabilityPolicyState> state = default;
            Optional<bool> allowProtectedAppendWrites = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("immutabilityPeriodSinceCreationInDays"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    immutabilityPeriodSinceCreationInDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("state"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    state = new AccountImmutabilityPolicyState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("allowProtectedAppendWrites"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowProtectedAppendWrites = property.Value.GetBoolean();
                    continue;
                }
            }
            return new AccountImmutabilityPolicyProperties(Optional.ToNullable(immutabilityPeriodSinceCreationInDays), Optional.ToNullable(state), Optional.ToNullable(allowProtectedAppendWrites));
        }
    }
}
