// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithListOfInternalModel : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeModelWithListOfInternalModel(doc.RootElement, options);
        }

        internal static ModelWithListOfInternalModel DeserializeModelWithListOfInternalModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> stringProperty = default;
            Optional<IReadOnlyList<InternalModel>> internalListProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("StringProperty"u8))
                {
                    stringProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("InternalListProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalModel> array = new List<InternalModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InternalModel.DeserializeInternalModel(item));
                    }
                    internalListProperty = array;
                    continue;
                }
            }
            return new ModelWithListOfInternalModel(stringProperty.Value, Optional.ToList(internalListProperty));
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithListOfInternalModel(doc.RootElement, options);
        }
    }
}
