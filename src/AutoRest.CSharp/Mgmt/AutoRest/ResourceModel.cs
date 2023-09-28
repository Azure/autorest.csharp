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
        public IList<ResourceOperation>? Operations { get; set; }
        public IList<string>? Parents { get; set; }
        public string? SwaggerModelName {  get; set; }
        public string? ResourceType { get; set; }
        public string? ResourceKey { get; set; }
        public string? ResourceKeySegment { get; set; }
        public bool IsTrackedResource { get; set; }
        public bool IsTenantResource { get; set; }
        public bool IsSubscriptionResource { get; set; }
        public bool IsManagementGroupResource { get; set; }
        public bool IsExtensionResource { get; set; }
        public bool IsSingletonResource { get; set; }
    }
}
