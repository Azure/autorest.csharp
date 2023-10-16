// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace ExtensionClientName.Models
{
    public partial class RenamedSchema : IUtf8JsonSerializable, IModelJsonSerializable<RenamedSchema>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RenamedSchema>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RenamedSchema>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(RenamedProperty))
            {
                writer.WritePropertyName("originalProperty"u8);
                writer.WriteStartObject();
                foreach (var item in RenamedProperty)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(RenamedPropertyString))
            {
                writer.WritePropertyName("originalPropertyString"u8);
                writer.WriteStringValue(RenamedPropertyString);
            }
            writer.WriteEndObject();
        }

        RenamedSchema IModelJsonSerializable<RenamedSchema>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRenamedSchema(doc.RootElement, options);
        }

        BinaryData IModelSerializable<RenamedSchema>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        RenamedSchema IModelSerializable<RenamedSchema>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRenamedSchema(document.RootElement, options);
        }

        internal static RenamedSchema DeserializeRenamedSchema(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> originalProperty = default;
            Optional<string> originalPropertyString = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("originalProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    originalProperty = dictionary;
                    continue;
                }
                if (property.NameEquals("originalPropertyString"u8))
                {
                    originalPropertyString = property.Value.GetString();
                    continue;
                }
            }
            return new RenamedSchema(Optional.ToDictionary(originalProperty), originalPropertyString.Value);
        }
    }
}
