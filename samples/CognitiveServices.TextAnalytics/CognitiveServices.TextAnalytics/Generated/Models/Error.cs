// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class Error
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
        public string? Target { get; set; }
        public InnerError? Innererror { get; set; }
        public ICollection<Error>? Details { get; set; }
    }
}
