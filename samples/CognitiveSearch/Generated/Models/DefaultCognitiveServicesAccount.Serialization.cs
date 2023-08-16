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

namespace CognitiveSearch.Models
{
    public partial class DefaultCognitiveServicesAccount : IUtf8JsonSerializable, IModelJsonSerializable<DefaultCognitiveServicesAccount>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DefaultCognitiveServicesAccount>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DefaultCognitiveServicesAccount>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DefaultCognitiveServicesAccount>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
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

        internal static DefaultCognitiveServicesAccount DeserializeDefaultCognitiveServicesAccount(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string odataType = default;
            Optional<string> description = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DefaultCognitiveServicesAccount(odataType, description.Value, rawData);
        }

        DefaultCognitiveServicesAccount IModelJsonSerializable<DefaultCognitiveServicesAccount>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DefaultCognitiveServicesAccount>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDefaultCognitiveServicesAccount(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DefaultCognitiveServicesAccount>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DefaultCognitiveServicesAccount>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DefaultCognitiveServicesAccount IModelSerializable<DefaultCognitiveServicesAccount>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DefaultCognitiveServicesAccount>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDefaultCognitiveServicesAccount(doc.RootElement, options);
        }

        public static implicit operator RequestContent(DefaultCognitiveServicesAccount model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator DefaultCognitiveServicesAccount(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDefaultCognitiveServicesAccount(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
