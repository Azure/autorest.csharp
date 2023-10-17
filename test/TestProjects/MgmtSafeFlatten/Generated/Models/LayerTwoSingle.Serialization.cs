// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtSafeFlatten.Models
{
    internal partial class LayerTwoSingle : IUtf8JsonSerializable, IModelJsonSerializable<LayerTwoSingle>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<LayerTwoSingle>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<LayerTwoSingle>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(MyProp))
            {
                writer.WritePropertyName("myProp"u8);
                writer.WriteStringValue(MyProp);
            }
            writer.WriteEndObject();
        }

        LayerTwoSingle IModelJsonSerializable<LayerTwoSingle>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLayerTwoSingle(document.RootElement, options);
        }

        BinaryData IModelSerializable<LayerTwoSingle>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        LayerTwoSingle IModelSerializable<LayerTwoSingle>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeLayerTwoSingle(document.RootElement, options);
        }

        internal static LayerTwoSingle DeserializeLayerTwoSingle(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> myProp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("myProp"u8))
                {
                    myProp = property.Value.GetString();
                    continue;
                }
            }
            return new LayerTwoSingle(myProp.Value);
        }
    }
}
