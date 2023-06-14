// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class MultivariateDetectionResult
    {
        internal static MultivariateDetectionResult DeserializeMultivariateDetectionResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Guid resultId = default;
            MultivariateBatchDetectionResultSummary summary = default;
            IReadOnlyList<AnomalyState> results = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resultId"u8))
                {
                    resultId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("summary"u8))
                {
                    summary = MultivariateBatchDetectionResultSummary.DeserializeMultivariateBatchDetectionResultSummary(property.Value);
                    continue;
                }
                if (property.NameEquals("results"u8))
                {
                    List<AnomalyState> array = new List<AnomalyState>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AnomalyState.DeserializeAnomalyState(item));
                    }
                    results = array;
                    continue;
                }
            }
            return new MultivariateDetectionResult(resultId, summary, results);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MultivariateDetectionResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMultivariateDetectionResult(document.RootElement);
        }
    }
}
