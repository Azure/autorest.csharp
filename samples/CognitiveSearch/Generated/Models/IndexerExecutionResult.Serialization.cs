// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;

namespace CognitiveSearch.Models
{
    public partial class IndexerExecutionResult
    {
        internal static IndexerExecutionResult DeserializeIndexerExecutionResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IndexerExecutionStatus status = default;
            string errorMessage = default;
            DateTimeOffset? startTime = default;
            DateTimeOffset? endTime = default;
            IReadOnlyList<ItemError> errors = default;
            IReadOnlyList<ItemWarning> warnings = default;
            int itemsProcessed = default;
            int itemsFailed = default;
            string initialTrackingState = default;
            string finalTrackingState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToIndexerExecutionStatus();
                    continue;
                }
                if (property.NameEquals("errorMessage"u8))
                {
                    errorMessage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("startTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("endTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    endTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    List<ItemError> array = new List<ItemError>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ItemError.DeserializeItemError(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("warnings"u8))
                {
                    List<ItemWarning> array = new List<ItemWarning>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ItemWarning.DeserializeItemWarning(item));
                    }
                    warnings = array;
                    continue;
                }
                if (property.NameEquals("itemsProcessed"u8))
                {
                    itemsProcessed = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("itemsFailed"u8))
                {
                    itemsFailed = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("initialTrackingState"u8))
                {
                    initialTrackingState = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("finalTrackingState"u8))
                {
                    finalTrackingState = property.Value.GetString();
                    continue;
                }
            }
            return new IndexerExecutionResult(
                status,
                errorMessage,
                startTime,
                endTime,
                errors,
                warnings,
                itemsProcessed,
                itemsFailed,
                initialTrackingState,
                finalTrackingState);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static IndexerExecutionResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeIndexerExecutionResult(document.RootElement);
        }
    }
}
