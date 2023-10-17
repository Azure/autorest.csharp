// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace PublicClientCtor.Models
{
    public partial class TestModel : IUtf8JsonSerializable, IModelJsonSerializable<TestModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TestModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TestModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Code))
            {
                writer.WritePropertyName("Code"u8);
                writer.WriteStringValue(Code);
            }
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("Status"u8);
                writer.WriteStringValue(Status);
            }
            writer.WriteEndObject();
        }

        TestModel IModelJsonSerializable<TestModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTestModel(document.RootElement, options);
        }

        BinaryData IModelSerializable<TestModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        TestModel IModelSerializable<TestModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeTestModel(document.RootElement, options);
        }

        internal static TestModel DeserializeTestModel(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> code = default;
            Optional<string> status = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Code"u8))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Status"u8))
                {
                    status = property.Value.GetString();
                    continue;
                }
            }
            return new TestModel(code.Value, status.Value);
        }
    }
}
