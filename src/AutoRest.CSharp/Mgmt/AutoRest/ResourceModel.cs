// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Mgmt.AutoRest
{

    public class ResourceModel
    {
        public string? Name { get; set; }
        public IEnumerable<ResourceOperation>? Operations { get; set; }
        public IEnumerable<string>? Parents { get; set; }
        public string? ModelName {  get; set; }
        public bool IsTrackedResource { get; set; }
        public bool IsResource { get; set; }
        public bool IsScopeResource { get; set; }
    }
}
