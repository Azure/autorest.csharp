// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Analyzer : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static Analyzer DeserializeAnalyzer(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.CustomAnalyzer": return CustomAnalyzer.DeserializeCustomAnalyzer(element);
                    case "#Microsoft.Azure.Search.PatternAnalyzer": return PatternAnalyzer.DeserializePatternAnalyzer(element);
                    case "#Microsoft.Azure.Search.StandardAnalyzer": return StandardAnalyzer.DeserializeStandardAnalyzer(element);
                    case "#Microsoft.Azure.Search.StopAnalyzer": return StopAnalyzer.DeserializeStopAnalyzer(element);
                }
            }
            return UnknownAnalyzer.DeserializeUnknownAnalyzer(element);
        }
    }
}
