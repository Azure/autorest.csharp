// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    public partial class CollectionsModelProperty
    {
        internal static CollectionsModelProperty DeserializeCollectionsModelProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredProperty = default;
            IReadOnlyList<InnerModel> nullableProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredProperty"u8))
                {
                    requiredProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nullableProperty"u8))
                {
                    List<InnerModel> array = new List<InnerModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InnerModel.DeserializeInnerModel(item));
                    }
                    nullableProperty = array;
                    continue;
                }
            }
            return new CollectionsModelProperty(requiredProperty, nullableProperty);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static CollectionsModelProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCollectionsModelProperty(document.RootElement);
        }
    }
}
