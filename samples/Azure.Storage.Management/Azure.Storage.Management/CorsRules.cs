// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    [CodeGenModel("CorsRules")]
    public partial class CorsRules
    {
        [CodeGenMember("corsRules")]
        public ICollection<CorsRule> Rules { get; set; }
    }
}