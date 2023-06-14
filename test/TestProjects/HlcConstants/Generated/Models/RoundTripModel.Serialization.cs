// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace HlcConstants.Models
{
    public partial class RoundTripModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(RequiredConstantModel))
            {
                writer.WritePropertyName("requiredConstantModel"u8);
                writer.WriteObjectValue(RequiredConstantModel);
            }
            if (Optional.IsDefined(OptionalConstantModel))
            {
                writer.WritePropertyName("optionalConstantModel"u8);
                writer.WriteObjectValue(OptionalConstantModel);
            }
            writer.WriteEndObject();
        }

        internal static RoundTripModel DeserializeRoundTripModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ModelWithRequiredConstant> requiredConstantModel = default;
            Optional<ModelWithOptionalConstant> optionalConstantModel = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredConstantModel"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    requiredConstantModel = ModelWithRequiredConstant.DeserializeModelWithRequiredConstant(property.Value);
                    continue;
                }
                if (property.NameEquals("optionalConstantModel"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalConstantModel = ModelWithOptionalConstant.DeserializeModelWithOptionalConstant(property.Value);
                    continue;
                }
            }
            return new RoundTripModel(requiredConstantModel.Value, optionalConstantModel.Value);
        }
    }
}
