// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(ErrorResponseConverter))]
    public partial class ErrorResponse : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Error))
            {
                writer.WritePropertyName("error"u8);
                writer.WriteObjectValue(Error);
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeErrorResponse(doc.RootElement, options);
        }

        internal static ErrorResponse DeserializeErrorResponse(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ResponseError> error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    error = JsonSerializer.Deserialize<ResponseError>(property.Value.GetRawText());
                    continue;
                }
            }
            return new ErrorResponse(error.Value);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeErrorResponse(doc.RootElement, options);
        }

        internal partial class ErrorResponseConverter : JsonConverter<ErrorResponse>
        {
            public override void Write(Utf8JsonWriter writer, ErrorResponse model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ErrorResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeErrorResponse(document.RootElement);
            }
        }
    }
}
