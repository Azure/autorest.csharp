// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    internal partial class SuperDeepSinglePropertyModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Super))
            {
                writer.WritePropertyName("super"u8);
                writer.WriteObjectValue(Super);
            }
            writer.WriteEndObject();
        }

        internal static SuperDeepSinglePropertyModel DeserializeSuperDeepSinglePropertyModel(JsonElement element)
        {
            Optional<VeryDeepSinglePropertyModel> super = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("super"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    super = VeryDeepSinglePropertyModel.DeserializeVeryDeepSinglePropertyModel(property.Value);
                    continue;
                }
            }
            return new SuperDeepSinglePropertyModel(super.Value);
        }
    }
}
