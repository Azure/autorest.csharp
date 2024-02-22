// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    internal partial class VeryDeepSinglePropertyModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Very != null)
            {
                writer.WritePropertyName("very"u8);
                writer.WriteObjectValue(Very);
            }
            writer.WriteEndObject();
        }

        internal static VeryDeepSinglePropertyModel DeserializeVeryDeepSinglePropertyModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DeepSinglePropertyModel> very = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("very"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    very = DeepSinglePropertyModel.DeserializeDeepSinglePropertyModel(property.Value);
                    continue;
                }
            }
            return new VeryDeepSinglePropertyModel(very.Value);
        }
    }
}
