// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class DocumentKeyPhrases
    {
        public string Id { get; set; }
        public ICollection<string> KeyPhrases { get; set; } = new List<string>();
        public DocumentStatistics? Statistics { get; set; }
    }
}
