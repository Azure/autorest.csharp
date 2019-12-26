// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class DocumentError
    {
        public string Id { get; set; }
        public DocumentErrorError Error { get; set; } = new DocumentErrorError();
    }
}
