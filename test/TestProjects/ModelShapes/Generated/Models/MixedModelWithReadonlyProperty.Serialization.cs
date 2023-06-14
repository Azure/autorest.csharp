// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace ModelShapes.Models
{
    public partial class MixedModelWithReadonlyProperty : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static MixedModelWithReadonlyProperty DeserializeMixedModelWithReadonlyProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ReadonlyModel> readonlyProperty = default;
            Optional<IReadOnlyList<ReadonlyModel>> readonlyListProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ReadonlyProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    readonlyProperty = ReadonlyModel.DeserializeReadonlyModel(property.Value);
                    continue;
                }
                if (property.NameEquals("ReadonlyListProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ReadonlyModel> array = new List<ReadonlyModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ReadonlyModel.DeserializeReadonlyModel(item));
                    }
                    readonlyListProperty = array;
                    continue;
                }
            }
            return new MixedModelWithReadonlyProperty(readonlyProperty.Value, Optional.ToList(readonlyListProperty));
        }
    }
}
