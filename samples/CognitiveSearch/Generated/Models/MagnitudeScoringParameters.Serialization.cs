// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class MagnitudeScoringParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("boostingRangeStart"u8);
            writer.WriteNumberValue(BoostingRangeStart);
            writer.WritePropertyName("boostingRangeEnd"u8);
            writer.WriteNumberValue(BoostingRangeEnd);
            if (Optional.IsDefined(ShouldBoostBeyondRangeByConstant))
            {
                writer.WritePropertyName("constantBoostBeyondRange"u8);
                writer.WriteBooleanValue(ShouldBoostBeyondRangeByConstant.Value);
            }
            writer.WriteEndObject();
        }

        internal static MagnitudeScoringParameters DeserializeMagnitudeScoringParameters(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            double boostingRangeStart = default;
            double boostingRangeEnd = default;
            Optional<bool> constantBoostBeyondRange = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("boostingRangeStart"u8))
                {
                    boostingRangeStart = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("boostingRangeEnd"u8))
                {
                    boostingRangeEnd = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("constantBoostBeyondRange"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    constantBoostBeyondRange = property.Value.GetBoolean();
                    continue;
                }
            }
            return new MagnitudeScoringParameters(boostingRangeStart, boostingRangeEnd, Optional.ToNullable(constantBoostBeyondRange));
        }
    }
}
