// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(ErrorAdditionalInfoConverter))]
    public partial class ErrorAdditionalInfo : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static ErrorAdditionalInfo DeserializeErrorAdditionalInfo(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> type = default;
            Optional<BinaryData> info = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("info"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    info = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
            }
            return new ErrorAdditionalInfo(type.Value, info.Value);
        }

        internal partial class ErrorAdditionalInfoConverter : JsonConverter<ErrorAdditionalInfo>
        {
            public override void Write(Utf8JsonWriter writer, ErrorAdditionalInfo model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ErrorAdditionalInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeErrorAdditionalInfo(document.RootElement);
            }
        }
    }
}
