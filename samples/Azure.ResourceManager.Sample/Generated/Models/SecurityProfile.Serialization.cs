// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class SecurityProfile : IUtf8JsonSerializable, IJsonModel<SecurityProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SecurityProfile>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<SecurityProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(EncryptionAtHost))
            {
                writer.WritePropertyName("encryptionAtHost"u8);
                writer.WriteBooleanValue(EncryptionAtHost.Value);
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        SecurityProfile IJsonModel<SecurityProfile>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSecurityProfile(document.RootElement, options);
        }

        internal static SecurityProfile DeserializeSecurityProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> encryptionAtHost = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("encryptionAtHost"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    encryptionAtHost = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new SecurityProfile(Optional.ToNullable(encryptionAtHost), serializedAdditionalRawData);
        }

        BinaryData IModel<SecurityProfile>.Write(ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.WriteCore(this, options);
        }

        SecurityProfile IModel<SecurityProfile>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSecurityProfile(document.RootElement, options);
        }
    }
}
