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
    public partial class Endpoints : IUtf8JsonSerializable, IModelJsonSerializable<Endpoints>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Endpoints>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Endpoints>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(MicrosoftEndpoints))
            {
                writer.WritePropertyName("microsoftEndpoints"u8);
                if (MicrosoftEndpoints is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<StorageAccountMicrosoftEndpoints>)MicrosoftEndpoints).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(InternetEndpoints))
            {
                writer.WritePropertyName("internetEndpoints"u8);
                if (InternetEndpoints is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<StorageAccountInternetEndpoints>)InternetEndpoints).Serialize(writer, options);
                }
            }
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static Endpoints DeserializeEndpoints(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> blob = default;
            Optional<string> queue = default;
            Optional<string> table = default;
            Optional<string> file = default;
            Optional<string> web = default;
            Optional<string> dfs = default;
            Optional<StorageAccountMicrosoftEndpoints> microsoftEndpoints = default;
            Optional<StorageAccountInternetEndpoints> internetEndpoints = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("blob"u8))
                {
                    blob = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("queue"u8))
                {
                    queue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("table"u8))
                {
                    table = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("file"u8))
                {
                    file = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("web"u8))
                {
                    web = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dfs"u8))
                {
                    dfs = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("microsoftEndpoints"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    microsoftEndpoints = StorageAccountMicrosoftEndpoints.DeserializeStorageAccountMicrosoftEndpoints(property.Value);
                    continue;
                }
                if (property.NameEquals("internetEndpoints"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    internetEndpoints = StorageAccountInternetEndpoints.DeserializeStorageAccountInternetEndpoints(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new Endpoints(blob.Value, queue.Value, table.Value, file.Value, web.Value, dfs.Value, microsoftEndpoints.Value, internetEndpoints.Value, serializedAdditionalRawData);
        }

        Endpoints IModelJsonSerializable<Endpoints>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeEndpoints(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Endpoints>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        Endpoints IModelSerializable<Endpoints>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeEndpoints(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="Endpoints"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="Endpoints"/> to convert. </param>
        public static implicit operator RequestContent(Endpoints model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="Endpoints"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator Endpoints(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeEndpoints(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
