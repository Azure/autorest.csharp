// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class DocumentResult
    {
        internal static DocumentResult DeserializeDocumentResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string docType = default;
            IReadOnlyList<int> pageRange = default;
            IReadOnlyDictionary<string, FieldValue> fields = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("docType"u8))
                {
                    docType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("pageRange"u8))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    pageRange = array;
                    continue;
                }
                if (property.NameEquals("fields"u8))
                {
                    Dictionary<string, FieldValue> dictionary = new Dictionary<string, FieldValue>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, FieldValue.DeserializeFieldValue(property0.Value));
                    }
                    fields = dictionary;
                    continue;
                }
            }
            return new DocumentResult(docType, pageRange, fields);
        }
    }
}
