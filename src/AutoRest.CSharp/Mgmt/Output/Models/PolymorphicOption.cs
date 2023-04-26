// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output.Models;

internal class PolymorphicOption
{
    public Resource Resource { get; }

    public BaseResource BaseResource { get; }

    public ScopeResourceTypeConstraint? ScopeResourceTypeConstraint { get; }

    public Segment? ResourceNameConstraint { get; }

    public PolymorphicOption(Resource resource, BaseResource baseResource)
    {
        Resource = resource;
        BaseResource = baseResource;
        var requestPath = resource.RequestPath;
        var scopePath = requestPath.GetScopePath();
        var scopeResourceType = scopePath.GetResourceType();
        if (scopeResourceType != ResourceTypeSegment.Any && scopeResourceType != ResourceTypeSegment.Scope)
        {
            // get how many segments we have for those "non-scope" parts
            var trimmed = requestPath.TrimScope();
            Debug.Assert(trimmed.Count % 2 == 0); // this is ensured by our resource detection logic -- might throws if there is a manual resource data configuration which assigns a path with odd segments as resource
            var countOfParents = trimmed.Count / 2;
            if (trimmed.First().Equals(Segment.Providers))
                countOfParents--;
            var builder = new StringBuilder();
            for (int i = 0; i < countOfParents; i++)
            {
                builder.Append(".Parent");
            }
            ScopeResourceTypeConstraint = new ScopeResourceTypeConstraint($"{IdParameter.Name}{builder.ToString()}", scopeResourceType);
        }
        var resourceNameSegment = requestPath.Last();
        if (resourceNameSegment.IsConstant)
            ResourceNameConstraint = resourceNameSegment;
    }

    public readonly static Parameter IdParameter = new Parameter(Name: "id", Description: null, Type: typeof(ResourceIdentifier), DefaultValue: null, Validation: ValidationType.AssertNotNull, Initializer: null);

    private MethodSignature? _methodSignature;
    public MethodSignature MethodSignature => _methodSignature ??= new MethodSignature(
        Name: $"Is{Resource.Type.Name}",
        Summary: null,
        Description: null,
        Modifiers: MethodSignatureModifiers.Private | MethodSignatureModifiers.Static,
        ReturnType: typeof(bool),
        ReturnDescription: null,
        Parameters: new[] { IdParameter });
}
