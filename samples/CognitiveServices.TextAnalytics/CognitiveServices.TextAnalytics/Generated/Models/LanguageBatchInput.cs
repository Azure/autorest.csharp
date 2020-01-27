// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class LanguageBatchInput
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-ARRAYSCHEMA. </summary>
        public ICollection<LanguageInput> Documents { get; set; } = new System.Collections.Generic.List<CognitiveServices.TextAnalytics.Models.LanguageInput>();
    }
}
