// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class DistanceScoringParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("referencePointParameter"u8);
            writer.WriteStringValue(ReferencePointParameter);
            writer.WritePropertyName("boostingDistance"u8);
            writer.WriteNumberValue(BoostingDistance);
            writer.WriteEndObject();
        }

        internal static DistanceScoringParameters DeserializeDistanceScoringParameters(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string referencePointParameter = default;
            double boostingDistance = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("referencePointParameter"u8))
                {
                    referencePointParameter = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boostingDistance"u8))
                {
                    boostingDistance = property.Value.GetDouble();
                    continue;
                }
            }
            return new DistanceScoringParameters(referencePointParameter, boostingDistance);
        }
    }
}
