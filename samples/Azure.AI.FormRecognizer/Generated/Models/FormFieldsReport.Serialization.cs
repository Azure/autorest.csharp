// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    internal partial class FormFieldsReport
    {
        internal static FormFieldsReport DeserializeFormFieldsReport(JsonElement element)
        {
            string fieldName = default;
            float accuracy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("fieldName"))
                {
                    fieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("accuracy"))
                {
                    accuracy = property.Value.GetSingle();
                    continue;
                }
            }
            return new FormFieldsReport(fieldName, accuracy);
        }
    }
}
