// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class DocumentLanguage
    {
        public string Id { get; set; }
        public ICollection<DetectedLanguage> DetectedLanguages { get; set; } = new List<DetectedLanguage>();
        public DocumentStatistics? Statistics { get; set; }
    }
}
