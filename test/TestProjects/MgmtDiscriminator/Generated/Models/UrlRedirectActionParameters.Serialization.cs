// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    public partial class UrlRedirectActionParameters : IUtf8JsonSerializable, IModelJsonSerializable<UrlRedirectActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<UrlRedirectActionParameters>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<UrlRedirectActionParameters>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("redirectType"u8);
            writer.WriteStringValue(RedirectType.ToString());
            if (Optional.IsDefined(DestinationProtocol))
            {
                writer.WritePropertyName("destinationProtocol"u8);
                writer.WriteStringValue(DestinationProtocol.Value.ToString());
            }
            if (Optional.IsDefined(CustomPath))
            {
                writer.WritePropertyName("customPath"u8);
                writer.WriteStringValue(CustomPath);
            }
            if (Optional.IsDefined(CustomHostname))
            {
                writer.WritePropertyName("customHostname"u8);
                writer.WriteStringValue(CustomHostname);
            }
            if (Optional.IsDefined(CustomQueryString))
            {
                writer.WritePropertyName("customQueryString"u8);
                writer.WriteStringValue(CustomQueryString);
            }
            if (Optional.IsDefined(CustomFragment))
            {
                writer.WritePropertyName("customFragment"u8);
                writer.WriteStringValue(CustomFragment);
            }
            writer.WriteEndObject();
        }

        UrlRedirectActionParameters IModelJsonSerializable<UrlRedirectActionParameters>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUrlRedirectActionParameters(doc.RootElement, options);
        }

        BinaryData IModelSerializable<UrlRedirectActionParameters>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        UrlRedirectActionParameters IModelSerializable<UrlRedirectActionParameters>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeUrlRedirectActionParameters(document.RootElement, options);
        }

        internal static UrlRedirectActionParameters DeserializeUrlRedirectActionParameters(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            UrlRedirectActionParametersTypeName typeName = default;
            RedirectType redirectType = default;
            Optional<DestinationProtocol> destinationProtocol = default;
            Optional<string> customPath = default;
            Optional<string> customHostname = default;
            Optional<string> customQueryString = default;
            Optional<string> customFragment = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new UrlRedirectActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("redirectType"u8))
                {
                    redirectType = new RedirectType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("destinationProtocol"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    destinationProtocol = new DestinationProtocol(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("customPath"u8))
                {
                    customPath = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customHostname"u8))
                {
                    customHostname = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customQueryString"u8))
                {
                    customQueryString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customFragment"u8))
                {
                    customFragment = property.Value.GetString();
                    continue;
                }
            }
            return new UrlRedirectActionParameters(typeName, redirectType, Optional.ToNullable(destinationProtocol), customPath.Value, customHostname.Value, customQueryString.Value, customFragment.Value);
        }
    }
}
