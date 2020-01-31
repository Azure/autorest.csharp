// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The LanguageInput. </summary>
    public partial class LanguageInput
    {
        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; set; }
        public string Text { get; set; }
        public string CountryHint { get; set; }
    }
}
