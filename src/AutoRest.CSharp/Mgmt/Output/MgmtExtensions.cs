// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensions : MgmtTypeProvider
    {
        public IEnumerable<Operation> AllRawOperations { get; }

        public MgmtExtensions(IEnumerable<Operation> allRawOperations, Type armCoreType, RequestPath contextualPath)
            : base(armCoreType.Name)
        {
            AllRawOperations = allRawOperations;
            ArmCoreType = armCoreType;
            DefaultName = Configuration.MgmtConfiguration.IsArmCore ? ResourceName : $"{ResourceName}Extensions";
            DefaultNamespace = Configuration.MgmtConfiguration.IsArmCore ? ArmCoreType.Namespace! : base.DefaultNamespace;
            Description = Configuration.MgmtConfiguration.IsArmCore ? (FormattableString)$"" : $"A class to add extension methods to {ResourceName}.";
            ContextualPath = contextualPath;
            ArmCoreNamespace = ArmCoreType.Namespace!;
            ChildResources = !Configuration.MgmtConfiguration.IsArmCore || ArmCoreType.Namespace != MgmtContext.Context.DefaultNamespace ? base.ChildResources : Enumerable.Empty<Resource>();
        }

        protected override ConstructorSignature? EnsureMockingCtor()
        {
            return IsArmCore ? null : base.EnsureMockingCtor();
        }

        public override string BranchIdVariableName => $"{ExtensionParameter.Name}.Id";

        private Parameter? _extensionParameter;
        public Parameter ExtensionParameter => _extensionParameter ??= EnsureExtensionParameter();
        private Parameter EnsureExtensionParameter()
        {
            return new Parameter(
                VariableName,
                $"The <see cref=\"{ArmCoreType}\" /> instance the method will execute against.",
                ArmCoreType,
                null,
                Validation.None,
                null);
        }

        protected virtual string VariableName => Configuration.MgmtConfiguration.IsArmCore ? "this" : ArmCoreType.Name.ToVariableName();

        public override CSharpType? BaseType => null;

        public override FormattableString Description { get; }

        public Type ArmCoreType { get; }

        public string ArmCoreNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultNamespace { get; }

        public virtual RequestPath ContextualPath { get; }

        public override IEnumerable<Resource> ChildResources { get; }

        public virtual bool IsEmpty => !ClientOperations.Any() && !ChildResources.Any();

        protected override IEnumerable<FieldDeclaration> EnsureFieldDeclaration()
        {
            yield break;
        }

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            var extensionParamToUse = Configuration.MgmtConfiguration.IsArmCore ? null : ExtensionParameter;
            return AllRawOperations.Select(operation =>
            {
                var operationName = GetOperationName(operation, ResourceName);
                // TODO -- these logic needs a thorough refactor -- the values MgmtRestOperation consumes here are actually coupled together
                // some of the values are calculated multiple times (here and in writers).
                // we just leave this implementation here since it could work for now
                return MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        operation,
                        operation.GetRequestPath(),
                        ContextualPath,
                        operationName,
                        propertyBagName: ResourceName),
                    extensionParamToUse);
            });
        }

        public string GetOperationName(Operation operation) => GetOperationName(operation, ResourceName);

        protected override string CalculateOperationName(Operation operation, string clientResourceName)
        {
            var opertionName = base.CalculateOperationName(operation, clientResourceName);

            if (MgmtContext.Library.GetRestClientMethod(operation).IsListMethod(out var itemType) && itemType.TryCastResourceData(out var data))
            {
                var requestPath = operation.GetRequestPath();
                // we need to find the correct resource type that links with this resource data
                var resource = FindResourceFromResourceData(data, requestPath);
                if (resource != null)
                {
                    var extraLayers = GetExtraLayers(requestPath, resource);
                    if (!extraLayers.Any())
                        return $"Get{resource.ResourceName.ResourceNameToPlural()}";
                    var suffix = string.Join("", extraLayers.Select(segment => segment.ConstantValue.FirstCharToUpperCase().LastWordToSingular()));
                    return $"Get{resource.ResourceName.ResourceNameToPlural()}By{suffix}";
                }
            }

            return opertionName;
        }

        private IEnumerable<Segment> GetExtraLayers(RequestPath requestPath, Resource resource)
        {
            var rawType = ResourceTypeSegment.ParseRequestPath(requestPath);
            var segmentsInResourceType = new HashSet<Segment>(resource.ResourceType);
            // compare and find the new segments in rawType
            return rawType.Where(segment => !segmentsInResourceType.Contains(segment));
        }

        // This piece of logic is duplicated in MgmtExtensionWriter, to be refactored
        private Resource? FindResourceFromResourceData(ResourceData data, RequestPath requestPath)
        {
            // we need to find the correct resource type that links with this resource data
            var candidates = MgmtContext.Library.FindResources(data);

            // return null when there is no match
            if (!candidates.Any())
                return null;

            // when we only find one result, just return it.
            if (candidates.Count() == 1)
                return candidates.Single();

            // if there is more candidates than one, we are going to some more matching to see if we could determine one
            var resourceType = requestPath.GetResourceType();
            var filteredResources = candidates.Where(resource => resource.ResourceType == resourceType);

            if (filteredResources.Count() == 1)
                return filteredResources.Single();

            return null;
        }

        private MgmtExtensionClient? _extensionClient;
        public virtual MgmtExtensionClient ExtensionClient => _extensionClient ??= new MgmtExtensionClient(this);
    }
}
