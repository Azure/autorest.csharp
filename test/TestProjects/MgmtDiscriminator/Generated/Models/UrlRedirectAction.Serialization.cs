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
    public partial class UrlRedirectAction : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("parameters"u8);
            writer.WriteObjectValue(Parameters);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeUrlRedirectAction(doc.RootElement, options);
        }

        internal static UrlRedirectAction DeserializeUrlRedirectAction(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            UrlRedirectActionParameters parameters = default;
            DeliveryRuleActionType name = default;
            Optional<string> foo = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parameters"u8))
                {
                    parameters = UrlRedirectActionParameters.DeserializeUrlRedirectActionParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = new DeliveryRuleActionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("foo"u8))
                {
                    foo = property.Value.GetString();
                    continue;
                }
            }
            return new UrlRedirectAction(name, foo.Value, parameters);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUrlRedirectAction(doc.RootElement, options);
        }
    }
}
