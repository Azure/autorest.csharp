// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// A virtual resource stands for a resource from another SDK, and it plays a role of anchor of some operations that belong to this resource in another SDK
    /// </summary>
    internal class VirtualResource : Resource
    {
        protected internal VirtualResource(OperationSet operationSet, IEnumerable<Operation> operations, string resourceName, ResourceTypeSegment resourceType, ResourceData resourceData, string position) : base(operationSet, operations, resourceName, resourceType, resourceData, ResourcePosition)
        {
        }

        // TODO -- change this to a virtual resource description
        public override FormattableString Description => CreateDescription(ResourceName);

        protected override string DefaultName => throw new NotImplementedException();

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            throw new NotImplementedException();
        }

        protected override ConstructorSignature? EnsureResourceDataCtor()
        {
            // virtual resource does not have this constructor
            return null;
        }
    }
}
