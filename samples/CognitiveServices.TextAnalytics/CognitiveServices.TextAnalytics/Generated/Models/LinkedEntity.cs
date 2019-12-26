// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class LinkedEntity
    {
        public string Name { get; set; }
        public ICollection<Match> Matches { get; set; } = new List<Match>();
        public string Language { get; set; }
        public string? Id { get; set; }
        public string Url { get; set; }
        public string DataSource { get; set; }
    }
}
