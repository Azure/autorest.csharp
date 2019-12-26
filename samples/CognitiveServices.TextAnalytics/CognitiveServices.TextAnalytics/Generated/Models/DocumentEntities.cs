// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class DocumentEntities
    {
        public string Id { get; set; }
        public ICollection<Entity> Entities { get; set; } = new List<Entity>();
        public DocumentStatistics? Statistics { get; set; }
    }
}
