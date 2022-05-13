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
    internal class VirtualResource : MgmtTypeProvider
    {
        protected static readonly string ResourcePosition = "resource";
        protected static readonly string CollectionPosition = "collection";
        protected readonly Parameter[] _armClientCtorParameters;

        /// <summary>
        /// The position means which class an operation should go. Possible value of this property is `resource` or `collection`.
        /// There is a configuration in <see cref="MgmtConfiguration"/> which assign values to operations.
        /// </summary>
        protected string Position { get; }

        public OperationSet OperationSet { get; }

        private RequestPath? _requestPath;
        public RequestPath RequestPath => _requestPath ??= OperationSet.GetRequestPath(ResourceType);

        protected internal VirtualResource(OperationSet operationSet, IEnumerable<Operation> operations, string resourceName, ResourceTypeSegment resourceType, string position) : base(resourceName)
        {
            _armClientCtorParameters = new[] { ArmClientParameter, ResourceIdentifierParameter };
            OperationSet = operationSet;
            ResourceType = resourceType;
            Position = position;
        }

        public override CSharpType? BaseType => typeof(ArmResource);

        public override FormattableString Description => CreateDescription(ResourceName);

        protected virtual FormattableString CreateDescription(string clientPrefix)
        {
            var an = clientPrefix.StartsWithVowel() ? "an" : "a";
            List<FormattableString> lines = new List<FormattableString>();
            var parent = ResourceName.Equals("Tenant", StringComparison.Ordinal) ? null : this.Parent().First();

            lines.Add($"A Class representing {an} {ResourceName} along with the instance operations that can be performed on it.");
            lines.Add($"If you have a <see cref=\"{typeof(ResourceIdentifier)}\" /> you can construct {an} <see cref=\"{Type}\" />");
            lines.Add($"from an instance of <see cref=\"{typeof(ArmClient)}\" /> using the Get{DefaultName} method.");
            if (parent is not null)
            {
                var parentType = parent is MgmtExtensions mgmtExtensions ? mgmtExtensions.ArmCoreType : parent.Type;
                lines.Add($"Otherwise you can get one from its parent resource <see cref=\"{parentType}\" /> using the Get{ResourceName} method.");
            }

            return FormattableStringHelpers.Join(lines, "\r\n");
        }

        protected override string DefaultName => throw new NotImplementedException();

        public ResourceTypeSegment ResourceType { get; }

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            throw new NotImplementedException();
        }

        protected override ConstructorSignature? EnsureArmClientCtor()
        {
            return new ConstructorSignature(
              Name: Type.Name,
              Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class.",
              Modifiers: Internal,
              Parameters: _armClientCtorParameters,
              Initializer: new(
                  isBase: true,
                  arguments: _armClientCtorParameters));
        }

        protected override ConstructorSignature? EnsureResourceDataCtor()
        {
            // virtual resource does not have this constructor
            return null;
        }
    }
}
