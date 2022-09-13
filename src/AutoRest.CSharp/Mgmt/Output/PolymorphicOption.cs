// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class PolymorphicOption
    {
        public Resource Resource { get; }

        public BaseResource BaseResource { get; }

        public ResourceTypeSegment? ScopeResourceTypeConstraint { get; }

        public Segment? ResourceNameConstraint { get; }

        public PolymorphicOption(Resource resource, BaseResource baseResource)
        {
            Resource = resource;
            BaseResource = baseResource;
            var requestPath = resource.RequestPath;
            var scopeResourceType = requestPath.GetScopePath().GetResourceType();
            if (scopeResourceType != ResourceTypeSegment.Any && scopeResourceType != ResourceTypeSegment.Scope)
                ScopeResourceTypeConstraint = scopeResourceType;
            var resourceNameSegment = requestPath.Last();
            if (resourceNameSegment.IsConstant)
                ResourceNameConstraint = resourceNameSegment;
        }

        private MethodSignature? _methodSignature;
        public MethodSignature MethodSignature => _methodSignature ??= new MethodSignature(
            Name: $"Is{Resource.Type.Name}",
            Summary: null,
            Description: null,
            Modifiers: MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
            ReturnType: typeof(bool),
            ReturnDescription: null,
            Parameters: new[] {new Parameter(Name: "id", Description: null, Type: typeof(ResourceIdentifier), DefaultValue: null, Validation: ValidationType.AssertNotNull, Initializer: null)});
    }
}
