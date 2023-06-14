// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class AnomalyInterpretation
    {
        internal static AnomalyInterpretation DeserializeAnomalyInterpretation(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> variable = default;
            Optional<float> contributionScore = default;
            Optional<CorrelationChanges> correlationChanges = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("variable"u8))
                {
                    variable = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("contributionScore"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    contributionScore = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("correlationChanges"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    correlationChanges = CorrelationChanges.DeserializeCorrelationChanges(property.Value);
                    continue;
                }
            }
            return new AnomalyInterpretation(variable.Value, Optional.ToNullable(contributionScore), correlationChanges.Value);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static AnomalyInterpretation FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAnomalyInterpretation(document.RootElement);
        }
    }
}
