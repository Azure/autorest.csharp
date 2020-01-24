// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class LanguageInput
    {
        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; set; }
        public string Text { get; set; }
        public string CountryHint { get; set; }
    }
}
