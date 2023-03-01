// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class CorrelationChanges
    {
        internal static CorrelationChanges DeserializeCorrelationChanges(JsonElement element)
        {
            Optional<IReadOnlyList<string>> changedVariables = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("changedVariables"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    changedVariables = array;
                    continue;
                }
            }
            return new CorrelationChanges(Optional.ToList(changedVariables));
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static CorrelationChanges FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCorrelationChanges(document.RootElement);
        }
    }
}
