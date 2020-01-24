// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class FreshnessScoringParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("boostingDuration");
            writer.WriteStringValue(BoostingDuration, "P");
            writer.WriteEndObject();
        }
        internal static FreshnessScoringParameters DeserializeFreshnessScoringParameters(JsonElement element)
        {
            FreshnessScoringParameters result = new FreshnessScoringParameters();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("boostingDuration"))
                {
                    result.BoostingDuration = property.Value.GetTimeSpan("P");
                    continue;
                }
            }
            return result;
        }
    }
}
