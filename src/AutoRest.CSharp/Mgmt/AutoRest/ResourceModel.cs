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
        public IList<ResourceOperation>? GetOperations { get; set; }
        public IList<ResourceOperation>? CreateOperations { get; set; }
        public IList<ResourceOperation>? UpdateOperations { get; set; }
        public IList<ResourceOperation>? DeleteOperations { get; set; }
        public IList<ResourceOperation>? ListOperations { get; set; }
        public IList<ResourceOperation>? OperationsFromResourceGroupExtension { get; set; }
        public IList<ResourceOperation>? OperationsFromSubscriptionExtension { get; set; }
        public IList<ResourceOperation>? OperationsFromManagementGroupExtension { get; set; }
        public IList<ResourceOperation>? OperationsFromTenantExtension { get; set; }
        public IList<ResourceOperation>? OtherOperations { get; set; }
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
