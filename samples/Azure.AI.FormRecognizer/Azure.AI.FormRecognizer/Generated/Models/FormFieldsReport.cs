// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Report for a custom model training field. </summary>
    public partial class FormFieldsReport
    {
        /// <summary> Initializes a new instance of FormFieldsReport. </summary>
        /// <param name="fieldName"> Training field name. </param>
        /// <param name="accuracy"> Estimated extraction accuracy for this field. </param>
        internal FormFieldsReport(string fieldName, float accuracy)
        {
            FieldName = fieldName;
            Accuracy = accuracy;
        }

        /// <summary> Training field name. </summary>
        public string FieldName { get; }
        /// <summary> Estimated extraction accuracy for this field. </summary>
        public float Accuracy { get; }
    }
}
