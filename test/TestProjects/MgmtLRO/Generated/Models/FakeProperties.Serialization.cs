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

namespace MgmtLRO.Models
{
    public partial class FakeProperties : IUtf8JsonSerializable, IModelJsonSerializable<FakeProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FakeProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FakeProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(PlatformUpdateDomainCount))
            {
                writer.WritePropertyName("platformUpdateDomainCount"u8);
                writer.WriteNumberValue(PlatformUpdateDomainCount.Value);
            }
            if (Optional.IsDefined(PlatformFaultDomainCount))
            {
                writer.WritePropertyName("platformFaultDomainCount"u8);
                writer.WriteNumberValue(PlatformFaultDomainCount.Value);
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

        internal static FakeProperties DeserializeFakeProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> platformUpdateDomainCount = default;
            Optional<int> platformFaultDomainCount = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("platformUpdateDomainCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformUpdateDomainCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("platformFaultDomainCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformFaultDomainCount = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new FakeProperties(Optional.ToNullable(platformUpdateDomainCount), Optional.ToNullable(platformFaultDomainCount), rawData);
        }

        FakeProperties IModelJsonSerializable<FakeProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeFakeProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<FakeProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        FakeProperties IModelSerializable<FakeProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeFakeProperties(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="FakeProperties"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="FakeProperties"/> to convert. </param>
        public static implicit operator RequestContent(FakeProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="FakeProperties"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator FakeProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeFakeProperties(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
