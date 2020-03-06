// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    [CodeGenSchema("InnerError")]
    public partial class InnerError
    {
        [CodeGenSchemaMember("innerError")]
        public InnerError Inner { get; set; }
    }
}
