// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class Models
    {
        internal static Models DeserializeModels(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ModelsSummary summary = default;
            IReadOnlyList<ModelInfo> modelList = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("summary"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    summary = ModelsSummary.DeserializeModelsSummary(property.Value);
                    continue;
                }
                if (property.NameEquals("modelList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ModelInfo> array = new List<ModelInfo>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ModelInfo.DeserializeModelInfo(item));
                    }
                    modelList = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new Models(summary, modelList ?? new ChangeTrackingList<ModelInfo>(), nextLink);
        }
    }
}
