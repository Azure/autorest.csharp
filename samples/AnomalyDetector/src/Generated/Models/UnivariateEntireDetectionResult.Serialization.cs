// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class UnivariateEntireDetectionResult
    {
        internal static UnivariateEntireDetectionResult DeserializeUnivariateEntireDetectionResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int period = default;
            IReadOnlyList<float> expectedValues = default;
            IReadOnlyList<float> upperMargins = default;
            IReadOnlyList<float> lowerMargins = default;
            IReadOnlyList<bool> isAnomaly = default;
            IReadOnlyList<bool> isNegativeAnomaly = default;
            IReadOnlyList<bool> isPositiveAnomaly = default;
            Optional<IReadOnlyList<float>> severity = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("period"u8))
                {
                    period = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("expectedValues"u8))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    expectedValues = array;
                    continue;
                }
                if (property.NameEquals("upperMargins"u8))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    upperMargins = array;
                    continue;
                }
                if (property.NameEquals("lowerMargins"u8))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    lowerMargins = array;
                    continue;
                }
                if (property.NameEquals("isAnomaly"u8))
                {
                    List<bool> array = new List<bool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetBoolean());
                    }
                    isAnomaly = array;
                    continue;
                }
                if (property.NameEquals("isNegativeAnomaly"u8))
                {
                    List<bool> array = new List<bool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetBoolean());
                    }
                    isNegativeAnomaly = array;
                    continue;
                }
                if (property.NameEquals("isPositiveAnomaly"u8))
                {
                    List<bool> array = new List<bool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetBoolean());
                    }
                    isPositiveAnomaly = array;
                    continue;
                }
                if (property.NameEquals("severity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    severity = array;
                    continue;
                }
            }
            return new UnivariateEntireDetectionResult(period, expectedValues, upperMargins, lowerMargins, isAnomaly, isNegativeAnomaly, isPositiveAnomaly, Optional.ToList(severity));
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static UnivariateEntireDetectionResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnivariateEntireDetectionResult(document.RootElement);
        }
    }
}
