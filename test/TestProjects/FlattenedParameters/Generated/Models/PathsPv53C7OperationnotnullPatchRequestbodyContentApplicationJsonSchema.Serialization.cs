// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace FlattenedParameters.Models
{
    internal partial class PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable, IModelJsonSerializable<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Items))
            {
                writer.WritePropertyName("items"u8);
                writer.WriteStartArray();
                foreach (var item in Items)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema IModelJsonSerializable<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializePathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema(doc.RootElement, options);
        }

        BinaryData IModelSerializable<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema IModelSerializable<PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema(document.RootElement, options);
        }

        internal static PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema DeserializePathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> items = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("items"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    items = array;
                    continue;
                }
            }
            return new PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema(Optional.ToList(items));
        }
    }
}
