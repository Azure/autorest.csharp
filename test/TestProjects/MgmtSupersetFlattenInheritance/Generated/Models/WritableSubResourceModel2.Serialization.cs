// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtSupersetFlattenInheritance.Models
{
    public partial class WritableSubResourceModel2 : IUtf8JsonSerializable, IModelJsonSerializable<WritableSubResourceModel2>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<WritableSubResourceModel2>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<WritableSubResourceModel2>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(IdPropertiesId))
                {
                    writer.WritePropertyName("id"u8);
                    writer.WriteStringValue(IdPropertiesId);
                }
                if (Optional.IsDefined(Foo))
                {
                    writer.WritePropertyName("foo"u8);
                    writer.WriteStringValue(Foo);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        WritableSubResourceModel2 IModelJsonSerializable<WritableSubResourceModel2>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWritableSubResourceModel2(document.RootElement, options);
        }

        BinaryData IModelSerializable<WritableSubResourceModel2>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        WritableSubResourceModel2 IModelSerializable<WritableSubResourceModel2>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeWritableSubResourceModel2(document.RootElement, options);
        }

        internal static WritableSubResourceModel2 DeserializeWritableSubResourceModel2(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> id = default;
            Optional<string> id0 = default;
            Optional<string> foo = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("id"u8))
                        {
                            id0 = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("foo"u8))
                        {
                            foo = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new WritableSubResourceModel2(id.Value, id0.Value, foo.Value);
        }
    }
}
