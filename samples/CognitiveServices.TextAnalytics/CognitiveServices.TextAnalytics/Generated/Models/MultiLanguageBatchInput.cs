// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class MultiLanguageBatchInput
    {
        public ICollection<MultiLanguageInput> Documents { get; set; } = new List<MultiLanguageInput>();
    }
}
