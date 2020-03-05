// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    [CodeGenSchema("CorsRules")]
    public partial class CorsRules
    {
        [CodeGenSchemaMember("corsRules")]
        public ICollection<CorsRule> Rules { get; set; }
    }
}