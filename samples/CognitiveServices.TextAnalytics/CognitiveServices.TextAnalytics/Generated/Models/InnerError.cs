// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class InnerError
    {
        public InnerErrorCode Code { get; set; }
        public string Message { get; set; }
        public string? Target { get; set; }
        public InnerError? Innererror { get; set; }
    }
}
