// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace AdditionalPropertiesEx.Models
{
    public partial struct OutputAdditionalPropertiesModelStruct
    {
        internal static OutputAdditionalPropertiesModelStruct DeserializeOutputAdditionalPropertiesModelStruct(JsonElement element)
        {
            int id = default;
            IReadOnlyDictionary<string, string> additionalProperties = default;
            Dictionary<string, string> additionalPropertiesDictionary = new Dictionary<string, string>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetInt32();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetString());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new OutputAdditionalPropertiesModelStruct(id, additionalProperties);
        }
    }
}
