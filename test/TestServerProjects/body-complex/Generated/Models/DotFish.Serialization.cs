// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace body_complex.Models
{
    public partial class DotFish : IUtf8JsonSerializable, IModelJsonSerializable<DotFish>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DotFish>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DotFish>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("fish.type"u8);
            writer.WriteStringValue(FishType);
            if (Optional.IsDefined(Species))
            {
                writer.WritePropertyName("species"u8);
                writer.WriteStringValue(Species);
            }
            writer.WriteEndObject();
        }

        DotFish IModelJsonSerializable<DotFish>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDotFish(document.RootElement, options);
        }

        BinaryData IModelSerializable<DotFish>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        DotFish IModelSerializable<DotFish>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDotFish(document.RootElement, options);
        }

        internal static DotFish DeserializeDotFish(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("fish.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "DotSalmon": return DotSalmon.DeserializeDotSalmon(element);
                }
            }
            return UnknownDotFish.DeserializeUnknownDotFish(element);
        }
    }
}
