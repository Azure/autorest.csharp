// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class ModelsSummary
    {
        internal static ModelsSummary DeserializeModelsSummary(JsonElement element)
        {
            ModelsSummary result = new ModelsSummary();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("count"))
                {
                    result.Count = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("limit"))
                {
                    result.Limit = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("lastUpdatedDateTime"))
                {
                    result.LastUpdatedDateTime = property.Value.GetDateTimeOffset("S");
                    continue;
                }
            }
            return result;
        }
    }
}
