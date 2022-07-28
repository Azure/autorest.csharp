// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// A virtual resource stands for a resource from another SDK, and it plays a role of anchor of some operations that belong to this resource in another SDK
    /// </summary>
    internal class PartialResource : Resource
    {
        protected internal PartialResource(OperationSet operationSet, IEnumerable<Operation> operations, string resourceName, ResourceTypeSegment resourceType, EmptyResourceData resourceData) : base(operationSet, operations, resourceName, resourceType, resourceData, ResourcePosition)
        {
        }

        // TODO -- change this to a virtual resource description
        public override FormattableString Description => CreateDescription(ResourceName);

        protected override ConstructorSignature? EnsureResourceDataCtor()
        {
            // virtual resource does not have this constructor
            return null;
        }

        private MethodSignature? _createResourceIdentifierSignature;
        public override MethodSignature CreateResourceIdentifierMethodSignature => _createResourceIdentifierSignature ??= base.CreateResourceIdentifierMethodSignature with
        {
            Modifiers = MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static
        };

        protected override IEnumerable<FieldDeclaration> GetAdditionalFields()
        {
            yield break;
        }
    }
}
