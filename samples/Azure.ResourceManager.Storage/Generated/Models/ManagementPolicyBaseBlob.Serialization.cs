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
    public partial class ManagementPolicyBaseBlob : IUtf8JsonSerializable, IModelJsonSerializable<ManagementPolicyBaseBlob>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ManagementPolicyBaseBlob>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ManagementPolicyBaseBlob>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(TierToCool))
            {
                writer.WritePropertyName("tierToCool"u8);
                if (TierToCool is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<DateAfterModification>)TierToCool).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(TierToArchive))
            {
                writer.WritePropertyName("tierToArchive"u8);
                if (TierToArchive is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<DateAfterModification>)TierToArchive).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(Delete))
            {
                writer.WritePropertyName("delete"u8);
                if (Delete is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<DateAfterModification>)Delete).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(EnableAutoTierToHotFromCool))
            {
                writer.WritePropertyName("enableAutoTierToHotFromCool"u8);
                writer.WriteBooleanValue(EnableAutoTierToHotFromCool.Value);
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

        internal static ManagementPolicyBaseBlob DeserializeManagementPolicyBaseBlob(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DateAfterModification> tierToCool = default;
            Optional<DateAfterModification> tierToArchive = default;
            Optional<DateAfterModification> delete = default;
            Optional<bool> enableAutoTierToHotFromCool = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tierToCool"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tierToCool = DateAfterModification.DeserializeDateAfterModification(property.Value);
                    continue;
                }
                if (property.NameEquals("tierToArchive"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tierToArchive = DateAfterModification.DeserializeDateAfterModification(property.Value);
                    continue;
                }
                if (property.NameEquals("delete"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    delete = DateAfterModification.DeserializeDateAfterModification(property.Value);
                    continue;
                }
                if (property.NameEquals("enableAutoTierToHotFromCool"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableAutoTierToHotFromCool = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ManagementPolicyBaseBlob(tierToCool.Value, tierToArchive.Value, delete.Value, Optional.ToNullable(enableAutoTierToHotFromCool), rawData);
        }

        ManagementPolicyBaseBlob IModelJsonSerializable<ManagementPolicyBaseBlob>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeManagementPolicyBaseBlob(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ManagementPolicyBaseBlob>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ManagementPolicyBaseBlob IModelSerializable<ManagementPolicyBaseBlob>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeManagementPolicyBaseBlob(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ManagementPolicyBaseBlob"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ManagementPolicyBaseBlob"/> to convert. </param>
        public static implicit operator RequestContent(ManagementPolicyBaseBlob model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ManagementPolicyBaseBlob"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ManagementPolicyBaseBlob(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeManagementPolicyBaseBlob(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
