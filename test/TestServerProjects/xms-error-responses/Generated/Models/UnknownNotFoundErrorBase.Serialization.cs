// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace xms_error_responses.Models
{
    internal partial class UnknownNotFoundErrorBase : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Reason))
            {
                writer.WritePropertyName("reason"u8);
                writer.WriteStringValue(Reason);
            }
            writer.WritePropertyName("whatNotFound"u8);
            writer.WriteStringValue(WhatNotFound);
            if (Optional.IsDefined(SomeBaseProp))
            {
                writer.WritePropertyName("someBaseProp"u8);
                writer.WriteStringValue(SomeBaseProp);
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeUnknownNotFoundErrorBase(doc.RootElement, options);
        }

        internal static UnknownNotFoundErrorBase DeserializeUnknownNotFoundErrorBase(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> reason = default;
            string whatNotFound = "Unknown";
            Optional<string> someBaseProp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("reason"u8))
                {
                    reason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("whatNotFound"u8))
                {
                    whatNotFound = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("someBaseProp"u8))
                {
                    someBaseProp = property.Value.GetString();
                    continue;
                }
            }
            return new UnknownNotFoundErrorBase(someBaseProp.Value, reason.Value, whatNotFound);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUnknownNotFoundErrorBase(doc.RootElement, options);
        }
    }
}
