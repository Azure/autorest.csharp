// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output;

internal class BaseResource : Resource
{
    public BaseResource(string resourceName, IEnumerable<Resource> resources) : base(OperationSet.Null, Enumerable.Empty<Operation>(), resourceName, ResourceTypeSegment.Null, resources.First().ResourceData)
    {
        DerivedResources = resources;
    }

    protected override bool IsAbstract => true;

    public override bool CanValidateResourceType => false;

    public IEnumerable<Resource> DerivedResources { get; }

    public override CSharpType? BaseType => typeof(ArmResource);

    protected override FormattableString CreateDescription()
    {
        var resourceList = DerivedResources.Select(resource => (FormattableString)$"<see cref=\"{resource.Type.Name}\" />").ToArray();
        return $"This is the base client representation of the following resources {FormattableStringHelpers.Join(resourceList, ", ", " or ")}.";
    }

    // base resource does not have children
    public override IEnumerable<Resource> ChildResources => Enumerable.Empty<Resource>();

    protected override IEnumerable<MgmtClientOperation> EnsureAllOperations()
    {
        //return base.EnsureAllOperations();
        yield break;
    }

    protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
    {
        // TODO -- get the common operations
        yield break;
    }

    public MethodSignature StaticFactoryMethod => new MethodSignature(
            Name: "GetResource",
            Summary: null,
            Description: null,
            Modifiers: MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
            ReturnType: Type,
            ReturnDescription: null,
            Parameters: new[] { ArmClientParameter, ResourceDataParameter });
}
