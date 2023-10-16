// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtExactMatchInheritance.Models
{
    [JsonConverter(typeof(ExactMatchModel11Converter))]
    public partial class ExactMatchModel11 : IUtf8JsonSerializable, IModelJsonSerializable<ExactMatchModel11>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ExactMatchModel11>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ExactMatchModel11>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        ExactMatchModel11 IModelJsonSerializable<ExactMatchModel11>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeExactMatchModel11(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ExactMatchModel11>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ExactMatchModel11 IModelSerializable<ExactMatchModel11>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeExactMatchModel11(document.RootElement, options);
        }

        internal static ExactMatchModel11 DeserializeExactMatchModel11(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<ResourceType> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.ValueKind == JsonValueKind.String && property.Value.GetString().Length == 0)
                    {
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
            }
            return new ExactMatchModel11(name.Value, Optional.ToNullable(type));
        }

        internal partial class ExactMatchModel11Converter : JsonConverter<ExactMatchModel11>
        {
            public override void Write(Utf8JsonWriter writer, ExactMatchModel11 model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ExactMatchModel11 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeExactMatchModel11(document.RootElement);
            }
        }
    }
}
