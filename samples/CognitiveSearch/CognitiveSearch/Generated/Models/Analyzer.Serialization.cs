// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Analyzer : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static CognitiveSearch.Models.Analyzer DeserializeAnalyzer(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("@odata.type", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.CustomAnalyzer": return CognitiveSearch.Models.CustomAnalyzer.DeserializeCustomAnalyzer(element);
                    case "#Microsoft.Azure.Search.PatternAnalyzer": return CognitiveSearch.Models.PatternAnalyzer.DeserializePatternAnalyzer(element);
                    case "#Microsoft.Azure.Search.StandardAnalyzer": return CognitiveSearch.Models.StandardAnalyzer.DeserializeStandardAnalyzer(element);
                    case "#Microsoft.Azure.Search.StopAnalyzer": return CognitiveSearch.Models.StopAnalyzer.DeserializeStopAnalyzer(element);
                }
            }
            CognitiveSearch.Models.Analyzer result = new CognitiveSearch.Models.Analyzer();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
