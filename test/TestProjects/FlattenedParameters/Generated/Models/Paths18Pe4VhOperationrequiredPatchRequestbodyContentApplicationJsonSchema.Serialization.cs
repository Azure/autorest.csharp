// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace FlattenedParameters.Models
{
    internal partial class Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("flattened"u8);
            writer.WriteStartObject();
            writer.WritePropertyName("required"u8);
            writer.WriteStringValue(Required);
            if (Optional.IsDefined(NonRequired))
            {
                writer.WritePropertyName("non_required"u8);
                writer.WriteStringValue(NonRequired);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializePaths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(doc.RootElement, options);
        }

        internal static Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema DeserializePaths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string required = default;
            Optional<string> nonRequired = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("flattened"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("required"u8))
                        {
                            required = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("non_required"u8))
                        {
                            nonRequired = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(required, nonRequired.Value);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializePaths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(doc.RootElement, options);
        }
    }
}
