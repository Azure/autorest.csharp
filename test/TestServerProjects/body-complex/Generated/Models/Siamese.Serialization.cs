// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace body_complex.Models
{
    public partial class Siamese : IUtf8JsonSerializable, IModelJsonSerializable<Siamese>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Siamese>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Siamese>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Breed))
            {
                writer.WritePropertyName("breed"u8);
                writer.WriteStringValue(Breed);
            }
            if (Optional.IsDefined(Color))
            {
                writer.WritePropertyName("color"u8);
                writer.WriteStringValue(Color);
            }
            if (Optional.IsCollectionDefined(Hates))
            {
                writer.WritePropertyName("hates"u8);
                writer.WriteStartArray();
                foreach (var item in Hates)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteNumberValue(Id.Value);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            writer.WriteEndObject();
        }

        Siamese IModelJsonSerializable<Siamese>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSiamese(document.RootElement, options);
        }

        BinaryData IModelSerializable<Siamese>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        Siamese IModelSerializable<Siamese>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSiamese(document.RootElement, options);
        }

        internal static Siamese DeserializeSiamese(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> breed = default;
            Optional<string> color = default;
            Optional<IList<Dog>> hates = default;
            Optional<int> id = default;
            Optional<string> name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("breed"u8))
                {
                    breed = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("color"u8))
                {
                    color = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("hates"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Dog> array = new List<Dog>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Dog.DeserializeDog(item));
                    }
                    hates = array;
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new Siamese(Optional.ToNullable(id), name.Value, color.Value, Optional.ToList(hates), breed.Value);
        }
    }
}
