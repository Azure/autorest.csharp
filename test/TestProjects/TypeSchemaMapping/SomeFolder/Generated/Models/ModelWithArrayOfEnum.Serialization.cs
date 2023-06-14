// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    internal partial class ModelWithArrayOfEnum : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(ArrayOfEnum))
            {
                writer.WritePropertyName("ArrayOfEnum"u8);
                writer.WriteStartArray();
                foreach (var item in ArrayOfEnum)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ArrayOfEnumCustomizedToNullable))
            {
                writer.WritePropertyName("ArrayOfEnumCustomizedToNullable"u8);
                writer.WriteStartArray();
                foreach (var item in ArrayOfEnumCustomizedToNullable)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item.Value.ToSerialString());
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static ModelWithArrayOfEnum DeserializeModelWithArrayOfEnum(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<EnumForModelWithArrayOfEnum>> arrayOfEnum = default;
            Optional<IReadOnlyList<EnumForModelWithArrayOfEnum?>> arrayOfEnumCustomizedToNullable = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ArrayOfEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<EnumForModelWithArrayOfEnum> array = new List<EnumForModelWithArrayOfEnum>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString().ToEnumForModelWithArrayOfEnum());
                    }
                    arrayOfEnum = array;
                    continue;
                }
                if (property.NameEquals("ArrayOfEnumCustomizedToNullable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<EnumForModelWithArrayOfEnum?> array = new List<EnumForModelWithArrayOfEnum?>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetString().ToEnumForModelWithArrayOfEnum());
                        }
                    }
                    arrayOfEnumCustomizedToNullable = array;
                    continue;
                }
            }
            return new ModelWithArrayOfEnum(Optional.ToList(arrayOfEnum), Optional.ToList(arrayOfEnumCustomizedToNullable));
        }
    }
}
