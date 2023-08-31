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
    public partial class ActiveDirectoryProperties : IUtf8JsonSerializable, IModelJsonSerializable<ActiveDirectoryProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ActiveDirectoryProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ActiveDirectoryProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("domainName"u8);
            writer.WriteStringValue(DomainName);
            writer.WritePropertyName("netBiosDomainName"u8);
            writer.WriteStringValue(NetBiosDomainName);
            writer.WritePropertyName("forestName"u8);
            writer.WriteStringValue(ForestName);
            writer.WritePropertyName("domainGuid"u8);
            writer.WriteStringValue(DomainGuid);
            writer.WritePropertyName("domainSid"u8);
            writer.WriteStringValue(DomainSid);
            writer.WritePropertyName("azureStorageSid"u8);
            writer.WriteStringValue(AzureStorageSid);
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

        internal static ActiveDirectoryProperties DeserializeActiveDirectoryProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string domainName = default;
            string netBiosDomainName = default;
            string forestName = default;
            string domainGuid = default;
            string domainSid = default;
            string azureStorageSid = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("domainName"u8))
                {
                    domainName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("netBiosDomainName"u8))
                {
                    netBiosDomainName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("forestName"u8))
                {
                    forestName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("domainGuid"u8))
                {
                    domainGuid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("domainSid"u8))
                {
                    domainSid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("azureStorageSid"u8))
                {
                    azureStorageSid = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ActiveDirectoryProperties(domainName, netBiosDomainName, forestName, domainGuid, domainSid, azureStorageSid, rawData);
        }

        ActiveDirectoryProperties IModelJsonSerializable<ActiveDirectoryProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeActiveDirectoryProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ActiveDirectoryProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ActiveDirectoryProperties IModelSerializable<ActiveDirectoryProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeActiveDirectoryProperties(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ActiveDirectoryProperties"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ActiveDirectoryProperties"/> to convert. </param>
        public static implicit operator RequestContent(ActiveDirectoryProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ActiveDirectoryProperties"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ActiveDirectoryProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeActiveDirectoryProperties(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
