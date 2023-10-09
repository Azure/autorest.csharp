// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmClientExtension : MgmtExtension
    {
        private readonly List<MgmtExtension> _extensions;
        private readonly ArmResourceExtension _armResourceExtensionForChildResources;
        public ArmClientExtension(IReadOnlyDictionary<RequestPath, IEnumerable<Operation>> armResourceExtensionOperations, IEnumerable<MgmtMockingExtension> extensionClients, ArmResourceExtension armResourceExtensionForChildResources)
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
            var extensionParamToUse = Configuration.MgmtConfiguration.IsArmCore ? null : ExtensionParameter;
            foreach (var extension in _extensions)
            {
                foreach (var clientOperation in extension.ClientOperations)
                {
                    var requestPaths = clientOperation.Select(restOperation => restOperation.RequestPath);
                    var scopeResourceTypes = requestPaths.Select(requestPath => requestPath.GetParameterizedScopeResourceTypes() ?? Enumerable.Empty<ResourceTypeSegment>()).SelectMany(types => types).Distinct();
                    var scopeTypes = ResourceTypeBuilder.GetScopeTypeStrings(scopeResourceTypes);
                    var parameterOverride = clientOperation.MethodParameters.Skip(1).Prepend(GetScopeParameter(scopeTypes)).Prepend(ExtensionParameter).ToArray();
                    var newOp = MgmtClientOperation.FromClientOperation(clientOperation, IdVariableName, extensionParameter: extensionParamToUse, parameterOverride: parameterOverride);
                    yield return newOp;
                }
            }
        }

        // only when in usual packages other than arm core, we need to generate the ArmClient, scope pattern for those scope resources
        public override IEnumerable<Resource> ChildResources => Configuration.MgmtConfiguration.IsArmCore ? Enumerable.Empty<Resource>() : _armResourceExtensionForChildResources.AllChildResources;

        private readonly Parameter _scopeParameter = new Parameter(
                Name: "scope",
                Description: $"The scope that the resource will apply against.",
                Type: typeof(ResourceIdentifier),
                DefaultValue: null,
                Validation: ValidationType.None,
                Initializer: null);

        private Parameter GetScopeParameter(ICollection<FormattableString>? types)
        {
            if (types == null)
                return _scopeParameter;

            return _scopeParameter with
            {
                Description = $"{_scopeParameter.Description} Expected resource type includes the following: {types.Join(", ", " or ")}"
            };
        }
    }
}
