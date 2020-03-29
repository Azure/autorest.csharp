// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    [CodeGenModel("InnerError")]
    public partial class InnerError
    {
        [CodeGenMember("innerError")]
        public InnerError Inner { get; set; }
    }
}
