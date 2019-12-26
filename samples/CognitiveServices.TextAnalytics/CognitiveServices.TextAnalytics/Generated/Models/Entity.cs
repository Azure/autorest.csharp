// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class Entity
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public string? SubType { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
        public double Score { get; set; }
    }
}
