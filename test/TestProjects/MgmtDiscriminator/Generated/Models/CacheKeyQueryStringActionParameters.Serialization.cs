// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    public partial class CacheKeyQueryStringActionParameters : IUtf8JsonSerializable, IModelJsonSerializable<CacheKeyQueryStringActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<CacheKeyQueryStringActionParameters>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<CacheKeyQueryStringActionParameters>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("queryStringBehavior"u8);
            writer.WriteStringValue(QueryStringBehavior.ToString());
            if (Optional.IsDefined(QueryParameters))
            {
                if (QueryParameters != null)
                {
                    writer.WritePropertyName("queryParameters"u8);
                    writer.WriteStringValue(QueryParameters);
                }
                else
                {
                    writer.WriteNull("queryParameters");
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        CacheKeyQueryStringActionParameters IModelJsonSerializable<CacheKeyQueryStringActionParameters>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCacheKeyQueryStringActionParameters(document.RootElement, options);
        }

        BinaryData IModelSerializable<CacheKeyQueryStringActionParameters>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        CacheKeyQueryStringActionParameters IModelSerializable<CacheKeyQueryStringActionParameters>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCacheKeyQueryStringActionParameters(document.RootElement, options);
        }

        internal static CacheKeyQueryStringActionParameters DeserializeCacheKeyQueryStringActionParameters(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CacheKeyQueryStringActionParametersTypeName typeName = default;
            QueryStringBehavior queryStringBehavior = default;
            Optional<string> queryParameters = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new CacheKeyQueryStringActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("queryStringBehavior"u8))
                {
                    queryStringBehavior = new QueryStringBehavior(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("queryParameters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        queryParameters = null;
                        continue;
                    }
                    queryParameters = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CacheKeyQueryStringActionParameters(typeName, queryStringBehavior, queryParameters.Value, serializedAdditionalRawData);
        }
    }
}
