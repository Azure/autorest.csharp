// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class MultivariateBatchDetectionResultSummary
    {
        internal static MultivariateBatchDetectionResultSummary DeserializeMultivariateBatchDetectionResultSummary(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MultivariateBatchDetectionStatus status = default;
            Optional<IReadOnlyList<ErrorResponse>> errors = default;
            Optional<IReadOnlyList<VariableState>> variableStates = default;
            MultivariateBatchDetectionOptions setupInfo = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToMultivariateBatchDetectionStatus();
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ErrorResponse> array = new List<ErrorResponse>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ErrorResponse.DeserializeErrorResponse(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("variableStates"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VariableState> array = new List<VariableState>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VariableState.DeserializeVariableState(item));
                    }
                    variableStates = array;
                    continue;
                }
                if (property.NameEquals("setupInfo"u8))
                {
                    setupInfo = MultivariateBatchDetectionOptions.DeserializeMultivariateBatchDetectionOptions(property.Value);
                    continue;
                }
            }
            return new MultivariateBatchDetectionResultSummary(status, Optional.ToList(errors), Optional.ToList(variableStates), setupInfo);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MultivariateBatchDetectionResultSummary FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMultivariateBatchDetectionResultSummary(document.RootElement);
        }
    }
}
