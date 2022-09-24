// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal record ResourceObjectAssociation
    {
        public ResourceTypeSegment ResourceType { get; }

        public ResourceData ResourceData { get; }

        public Resource Resource { get; }

        public ResourceCollection? ResourceCollection { get; }

        private ResourceObjectAssociation(ResourceTypeSegment resourceType, ResourceData resourceData, Resource resource, ResourceCollection? resourceCollection)
        {
            ResourceType = resourceType;
            ResourceData = resourceData;
            Resource = resource;
            ResourceCollection = resourceCollection;
        }

        public static ResourceObjectAssociation CreateAssociation(ResourceTypeSegment resourceType, ResourceData resourceData, Resource resource, ResourceCollection? resourceCollection)
        {
            resource.ResourceCollection = resourceCollection;

            return new ResourceObjectAssociation(resourceType, resourceData, resource, resourceCollection);
        }
    }
}
