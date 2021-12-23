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
        public ResourceType ResourceType { get; }

        public ResourceData ResourceData { get; }

        public Resource Resource { get; }

        public ResourceCollection? ResourceCollection { get; }

        public ResourceObjectAssociation(ResourceType resourceType, ResourceData resourceData, Resource resource, ResourceCollection? resourceCollection)
        {
            ResourceType = resourceType;
            ResourceData = resourceData;
            Resource = resource;
            ResourceCollection = resourceCollection;
        }
    }
}
