// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class FormFieldsReport
    {
        internal static FormFieldsReport DeserializeFormFieldsReport(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string fieldName = default;
            float accuracy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("fieldName"u8))
                {
                    fieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("accuracy"u8))
                {
                    accuracy = property.Value.GetSingle();
                    continue;
                }
            }
            return new FormFieldsReport(fieldName, accuracy);
        }
    }
}
