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
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensions : MgmtTypeProvider
    {
        public IEnumerable<Operation> AllRawOperations { get; }

        protected MgmtExtensions(BuildContext<MgmtOutputLibrary> context, MgmtExtensions mgmtExtension)
            : this(mgmtExtension.AllRawOperations, mgmtExtension.ArmCoreType, context, mgmtExtension.ContextualPath)
        {
        }

        public MgmtExtensions(IEnumerable<Operation> allRawOperations, Type armCoreType, BuildContext<MgmtOutputLibrary> context, RequestPath contextualPath)
            : base(context, armCoreType.Name)
        {
            _context = context;
            AllRawOperations = allRawOperations;
            ArmCoreType = armCoreType;
            DefaultName = context.Configuration.MgmtConfiguration.IsArmCore ? ResourceName : $"{ResourceName}Extensions";
            DefaultNamespace = context.Configuration.MgmtConfiguration.IsArmCore ? ArmCoreType.Namespace! : base.DefaultNamespace;
            Description = context.Configuration.MgmtConfiguration.IsArmCore ? string.Empty : $"A class to add extension methods to {ResourceName}.";
            ContextualPath = contextualPath;
            ArmCoreNamespace = ArmCoreType.Namespace!;
            string variableName = context.Configuration.MgmtConfiguration.IsArmCore ? "this" : armCoreType.Name.ToVariableName();
            ExtensionParameter = new Parameter(
                variableName,
                $"The <see cref=\"{armCoreType}\" /> instance the method will execute against.",
                armCoreType,
                null,
                false,
                IsExtensionParameter: true);
        }

        protected override ConstructorSignature? EnsureMockingCtor()
        {
            return IsArmCore ? null : base.EnsureMockingCtor();
        }

        public override string BranchIdVariableName => $"{ExtensionParameter.Name}.Id";

        public Parameter ExtensionParameter { get; }

        public override CSharpType? BaseType => null;

        public override string Description { get; }

        public Type ArmCoreType { get; }

        public string ArmCoreNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultNamespace { get; }

        public virtual RequestPath ContextualPath { get; }

        public virtual bool IsEmpty => !ClientOperations.Any() && !ChildResources.Any();

        protected override IEnumerable<FieldDeclaration> EnsureFieldDeclaration()
        {
            yield break;
        }

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            var extensionParamToUse = _context.Configuration.MgmtConfiguration.IsArmCore ? null : ExtensionParameter;
            return AllRawOperations.Select(operation =>
            {
                var operationName = GetOperationName(operation, ResourceName);
                // TODO -- these logic needs a thorough refactor -- the values MgmtRestOperation consumes here are actually coupled together
                // some of the values are calculated multiple times (here and in writers).
                // we just leave this implementation here since it could work for now
                return MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        _context.Library.GetRestClientMethod(operation),
                        _context.Library.GetRestClient(operation),
                        operation.GetRequestPath(_context),
                        ContextualPath,
                        operationName,
                        operation.GetReturnTypeAsLongRunningOperation(null, operationName, _context),
                        _context),
                    _context,
                    extensionParamToUse);
            });
        }

        public string GetOperationName(Operation operation) => GetOperationName(operation, ResourceName);

        protected override string CalculateOperationName(Operation operation, string clientResourceName)
        {
            var opertionName = base.CalculateOperationName(operation, clientResourceName);

            if (_context.Library.GetRestClientMethod(operation).IsListMethod(out var itemType) && itemType.IsResourceDataType(_context, out var data))
            {
                var requestPath = operation.GetRequestPath(_context);
                // we need to find the correct resource type that links with this resource data
                var resource = FindResourceFromResourceData(data, requestPath);
                if (resource != null)
                {
                    var extraLayers = GetExtraLayers(requestPath, resource);
                    if (!extraLayers.Any())
                        return $"Get{resource.Type.Name.ResourceNameToPlural()}";
                    var suffix = string.Join("", extraLayers.Select(segment => segment.ConstantValue.FirstCharToUpperCase().LastWordToSingular()));
                    return $"Get{resource.Type.Name.ResourceNameToPlural()}By{suffix}";
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
            var candidates = _context.Library.FindResources(data);

            // return null when there is no match
            if (!candidates.Any())
                return null;

            // when we only find one result, just return it.
            if (candidates.Count() == 1)
                return candidates.Single();

            // if there is more candidates than one, we are going to some more matching to see if we could determine one
            var resourceType = requestPath.GetResourceType(_context.Configuration.MgmtConfiguration);
            var filteredResources = candidates.Where(resource => resource.ResourceType == resourceType);

            if (filteredResources.Count() == 1)
                return filteredResources.Single();

            return null;
        }
    }
}
