// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

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
            Optional<string> errorMessage = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> endTime = default;
            IReadOnlyList<ItemError> errors = default;
            IReadOnlyList<ItemWarning> warnings = default;
            int itemsProcessed = default;
            int itemsFailed = default;
            Optional<string> initialTrackingState = default;
            Optional<string> finalTrackingState = default;
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
            return new IndexerExecutionResult(status, errorMessage.Value, Optional.ToNullable(startTime), Optional.ToNullable(endTime), errors, warnings, itemsProcessed, itemsFailed, initialTrackingState.Value, finalTrackingState.Value);
        }
    }
}
