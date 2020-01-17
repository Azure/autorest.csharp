// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace paging.Models
{
    public partial class OdataProductResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Values != null)
            {
                writer.WritePropertyName("values");
                writer.WriteStartArray();
                foreach (var item in Values)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (OdataNextLink != null)
            {
                writer.WritePropertyName("odata.nextLink");
                writer.WriteStringValue(OdataNextLink);
            }
            writer.WriteEndObject();
        }
        internal static OdataProductResult DeserializeOdataProductResult(JsonElement element)
        {
            OdataProductResult result = new OdataProductResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("values"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Values = new List<Product>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Values.Add(Product.DeserializeProduct(item));
                    }
                    continue;
                }
                if (property.NameEquals("odata.nextLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OdataNextLink = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
