// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace ModelWithConverterUsage.Models
{
    [JsonConverter(typeof(ModelStructConverter))]
    public partial struct ModelStruct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WritePropertyName("Model_Property"u8);
                writer.WriteStringValue(ModelProperty);
            }
            writer.WriteEndObject();
        }

        internal static ModelStruct DeserializeModelStruct(JsonElement element)
        {
            Optional<string> modelProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Model_Property"u8))
                {
                    modelProperty = property.Value.GetString();
                    continue;
                }
            }
            return new ModelStruct(modelProperty.Value);
        }

        internal partial class ModelStructConverter : JsonConverter<ModelStruct>
        {
            public override void Write(Utf8JsonWriter writer, ModelStruct model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ModelStruct Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeModelStruct(document.RootElement);
            }
        }
    }
}
