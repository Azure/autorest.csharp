// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class EntitiesResult
    {
        public ICollection<DocumentEntities> Documents { get; set; } = new List<DocumentEntities>();
        public ICollection<DocumentError> Errors { get; set; } = new List<DocumentError>();
        public RequestStatistics? Statistics { get; set; }
        public string ModelVersion { get; set; }
    }
}
