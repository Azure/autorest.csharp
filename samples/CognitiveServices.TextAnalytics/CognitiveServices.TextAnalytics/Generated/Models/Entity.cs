// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Entity
    {
        /// <summary> Entity text as appears in the request. </summary>
        public string Text { get; set; }
        /// <summary> Entity type, such as Person/Location/Org/SSN etc. </summary>
        public string Type { get; set; }
        /// <summary> Entity sub type, such as Age/Year/TimeRange etc. </summary>
        public string? SubType { get; set; }
        /// <summary> Start position (in Unicode characters) for the entity text. </summary>
        public int Offset { get; set; }
        /// <summary> Length (in Unicode characters) for the entity text. </summary>
        public int Length { get; set; }
        /// <summary> Confidence score between 0 and 1 of the extracted entity. </summary>
        public double Score { get; set; }
    }
}
