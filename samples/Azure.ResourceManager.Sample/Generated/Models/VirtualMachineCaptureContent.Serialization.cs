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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineCaptureContent : IUtf8JsonSerializable, IModelJsonSerializable<VirtualMachineCaptureContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualMachineCaptureContent>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualMachineCaptureContent>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("vhdPrefix"u8);
            writer.WriteStringValue(VhdPrefix);
            writer.WritePropertyName("destinationContainerName"u8);
            writer.WriteStringValue(DestinationContainerName);
            writer.WritePropertyName("overwriteVhds"u8);
            writer.WriteBooleanValue(OverwriteVhds);
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

        internal static VirtualMachineCaptureContent DeserializeVirtualMachineCaptureContent(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string vhdPrefix = default;
            string destinationContainerName = default;
            bool overwriteVhds = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vhdPrefix"u8))
                {
                    vhdPrefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destinationContainerName"u8))
                {
                    destinationContainerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("overwriteVhds"u8))
                {
                    overwriteVhds = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new VirtualMachineCaptureContent(vhdPrefix, destinationContainerName, overwriteVhds, rawData);
        }

        VirtualMachineCaptureContent IModelJsonSerializable<VirtualMachineCaptureContent>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineCaptureContent(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualMachineCaptureContent>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualMachineCaptureContent IModelSerializable<VirtualMachineCaptureContent>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualMachineCaptureContent(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="VirtualMachineCaptureContent"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="VirtualMachineCaptureContent"/> to convert. </param>
        public static implicit operator RequestContent(VirtualMachineCaptureContent model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="VirtualMachineCaptureContent"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator VirtualMachineCaptureContent(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeVirtualMachineCaptureContent(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
