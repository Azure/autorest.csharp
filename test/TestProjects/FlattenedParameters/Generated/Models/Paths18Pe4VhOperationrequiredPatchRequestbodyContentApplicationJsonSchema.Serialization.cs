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

namespace FlattenedParameters.Models
{
    internal partial class Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable, IModelJsonSerializable<Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

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

        internal static Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema DeserializePaths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string required = default;
            Optional<string> nonRequired = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(required, nonRequired.Value, serializedAdditionalRawData);
        }

        Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema IModelJsonSerializable<Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializePaths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema IModelSerializable<Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializePaths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema"/> to convert. </param>
        public static implicit operator RequestContent(Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializePaths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
