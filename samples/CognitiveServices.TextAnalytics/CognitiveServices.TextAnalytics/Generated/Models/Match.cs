// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class Match
    {
        public double Score { get; set; }
        public string Text { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
    }
}
