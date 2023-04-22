// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using Azure.ResourceManager.Models;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmResourceBuilder
    {
        public ArmResourceBuilder(RequestPath originalResourcePath, string resourceName, OperationSet operationSet, IEnumerable<Operation> operations, ResourceData resourceData)
        {
            var isSingleton = operationSet.IsSingletonResource();
            // we calculate the resource type of the resource
            var resourcePaths = originalResourcePath.Expand();
            foreach (var resourceRequestPath in resourcePaths)
            {
                var resourceType = resourceRequestPath.GetResourceType();
                var resource = new Resource(operationSet, operations, resourceName, resourceType, resourceData);
                var collection = isSingleton ? null : new ResourceCollection(operationSet, operations, resource);
            }
        }

        public Dictionary<RequestPath, ResourceObjectAssociation> Build()
        {
        }
    }
}
