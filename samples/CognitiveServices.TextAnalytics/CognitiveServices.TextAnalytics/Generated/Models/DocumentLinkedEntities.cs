// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class DocumentLinkedEntities
    {
        public string Id { get; set; }
        public ICollection<LinkedEntity> Entities { get; set; } = new List<LinkedEntity>();
        public DocumentStatistics? Statistics { get; set; }
    }
}
