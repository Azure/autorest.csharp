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
    public partial class AccountImmutabilityPolicyProperties : IUtf8JsonSerializable, IModelJsonSerializable<AccountImmutabilityPolicyProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AccountImmutabilityPolicyProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AccountImmutabilityPolicyProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

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

        internal static AccountImmutabilityPolicyProperties DeserializeAccountImmutabilityPolicyProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> immutabilityPeriodSinceCreationInDays = default;
            Optional<AccountImmutabilityPolicyState> state = default;
            Optional<bool> allowProtectedAppendWrites = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new AccountImmutabilityPolicyProperties(Optional.ToNullable(immutabilityPeriodSinceCreationInDays), Optional.ToNullable(state), Optional.ToNullable(allowProtectedAppendWrites), rawData);
        }

        AccountImmutabilityPolicyProperties IModelJsonSerializable<AccountImmutabilityPolicyProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
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

            using var doc = JsonDocument.Parse(data);
            return DeserializeAccountImmutabilityPolicyProperties(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="AccountImmutabilityPolicyProperties"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="AccountImmutabilityPolicyProperties"/> to convert. </param>
        public static implicit operator RequestContent(AccountImmutabilityPolicyProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="AccountImmutabilityPolicyProperties"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator AccountImmutabilityPolicyProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeAccountImmutabilityPolicyProperties(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
