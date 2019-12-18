// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace validation.Models.V100
{
    public partial class ConstantProductSerializer
    {
        internal static void Serialize(ConstantProduct model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("constProperty");
            writer.WriteStringValue(model.ConstProperty);
            writer.WritePropertyName("constProperty2");
            writer.WriteStringValue(model.ConstProperty2);
            writer.WriteEndObject();
        }
        internal static ConstantProduct Deserialize(JsonElement element)
        {
            var result = new ConstantProduct();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("constProperty"))
                {
                    result.ConstProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("constProperty2"))
                {
                    result.ConstProperty2 = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
