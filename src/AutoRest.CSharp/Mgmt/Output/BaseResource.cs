// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class BaseResource : MgmtTypeProvider
    {
        public BaseResource(string resourceName) : base(resourceName)
        {
        }

        internal void SetDerivedResources(IEnumerable<Resource> derivedResources)
        {
            DerivedResources = derivedResources;
        }

        public IEnumerable<Resource> DerivedResources { get; private set; } = Enumerable.Empty<Resource>();

        public override CSharpType? BaseType => typeof(ArmResource);

        public override FormattableString Description => $"TODO";

        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= EnsureDefaultName();

        private string EnsureDefaultName()
        {
            // TODO -- read the name from configuration
            var defaultName = ResourceName.AddResourceSuffixToResourceName();
            var isNameCollidedWithDerived = DerivedResources.Any(resource => resource.Type.Name.Equals(defaultName, StringComparison.OrdinalIgnoreCase));

            return isNameCollidedWithDerived ? $"Base{defaultName}" : defaultName;
        }

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            return Enumerable.Empty<MgmtClientOperation>();
        }
    }
}
