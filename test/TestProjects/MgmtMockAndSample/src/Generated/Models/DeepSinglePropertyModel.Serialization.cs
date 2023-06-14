// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    internal partial class DeepSinglePropertyModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Deep))
            {
                writer.WritePropertyName("deep"u8);
                writer.WriteObjectValue(Deep);
            }
            writer.WriteEndObject();
        }

        internal static DeepSinglePropertyModel DeserializeDeepSinglePropertyModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<SinglePropertyModel> deep = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("deep"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    deep = SinglePropertyModel.DeserializeSinglePropertyModel(property.Value);
                    continue;
                }
            }
            return new DeepSinglePropertyModel(deep.Value);
        }
    }
}
