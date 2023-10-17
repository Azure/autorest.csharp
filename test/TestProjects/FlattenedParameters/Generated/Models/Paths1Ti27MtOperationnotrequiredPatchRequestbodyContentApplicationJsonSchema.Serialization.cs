// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace FlattenedParameters.Models
{
    internal partial class Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable, IModelJsonSerializable<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("flattened"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(Required))
                {
                    writer.WritePropertyName("required"u8);
                    writer.WriteStringValue(Required);
                }
                if (Optional.IsDefined(NonRequired))
                {
                    writer.WritePropertyName("non_required"u8);
                    writer.WriteStringValue(NonRequired);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema IModelJsonSerializable<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePaths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(document.RootElement, options);
        }

        BinaryData IModelSerializable<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema IModelSerializable<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePaths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(document.RootElement, options);
        }

        internal static Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema DeserializePaths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> required = default;
            Optional<string> nonRequired = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("flattened"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("required"u8))
                        {
                            required = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("non_required"u8))
                        {
                            nonRequired = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(required.Value, nonRequired.Value);
        }
    }
}
