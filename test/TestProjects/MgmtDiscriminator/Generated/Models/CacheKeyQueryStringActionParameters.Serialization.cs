// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    public partial class CacheKeyQueryStringActionParameters : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
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
            writer.WriteEndObject();
        }

        internal static CacheKeyQueryStringActionParameters DeserializeCacheKeyQueryStringActionParameters(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CacheKeyQueryStringActionParametersTypeName typeName = default;
            QueryStringBehavior queryStringBehavior = default;
            Optional<string> queryParameters = default;
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
            }
            return new CacheKeyQueryStringActionParameters(typeName, queryStringBehavior, queryParameters.Value);
        }
    }
}
