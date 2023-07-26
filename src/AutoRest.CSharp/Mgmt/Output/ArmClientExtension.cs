// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmClientExtension : MgmtExtension
    {
        private readonly List<MgmtExtension> _extensions;
        private readonly ArmResourceExtension _armResourceExtensionForChildResources;
        public ArmClientExtension(IReadOnlyDictionary<RequestPath, IEnumerable<Operation>> armResourceExtensionOperations, IEnumerable<MgmtExtensionClient> extensionClients, ArmResourceExtension armResourceExtensionForChildResources)
            : base(Enumerable.Empty<Operation>(), extensionClients, typeof(ArmClient), RequestPath.Tenant)
        {
            _armResourceExtensionForChildResources = armResourceExtensionForChildResources;
            _extensions = new();
            foreach (var (parentRequestPath, operations) in armResourceExtensionOperations)
            {
                _extensions.Add(new(operations, extensionClients, typeof(ArmResource), parentRequestPath));
            }
        }

        public override bool IsEmpty => !MgmtContext.Library.ArmResources.Any();

        protected override string VariableName => Configuration.MgmtConfiguration.IsArmCore ? "this" : "client";

        public override FormattableString IdVariableName => $"scope";
        public override FormattableString BranchIdVariableName => $"scope";

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            foreach (var extension in _extensions)
            {
                foreach (var clientOperation in extension.ClientOperations)
                {
                    yield return clientOperation;
                }
            }
        }

        // only when in usual packages other than arm core, we need to generate the ArmClient, scope pattern for those scope resources
        public override IEnumerable<Resource> ChildResources => Configuration.MgmtConfiguration.IsArmCore ? Enumerable.Empty<Resource>() : _armResourceExtensionForChildResources.ChildResources;
    }
}
