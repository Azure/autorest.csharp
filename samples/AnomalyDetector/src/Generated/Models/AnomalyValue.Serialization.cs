// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class AnomalyValue
    {
        internal static AnomalyValue DeserializeAnomalyValue(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool isAnomaly = default;
            float severity = default;
            float score = default;
            Optional<IReadOnlyList<AnomalyInterpretation>> interpretation = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("isAnomaly"u8))
                {
                    isAnomaly = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("severity"u8))
                {
                    severity = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("score"u8))
                {
                    score = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("interpretation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AnomalyInterpretation> array = new List<AnomalyInterpretation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AnomalyInterpretation.DeserializeAnomalyInterpretation(item));
                    }
                    interpretation = array;
                    continue;
                }
            }
            return new AnomalyValue(isAnomaly, severity, score, Optional.ToList(interpretation));
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static AnomalyValue FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAnomalyValue(document.RootElement);
        }
    }
}
