﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensions : MgmtTypeProvider
    {
        protected IEnumerable<Operation> _allOperations;

        public MgmtExtensions(IEnumerable<Operation> allOperations, string resourceName, BuildContext<MgmtOutputLibrary> context, string defaultName, RequestPath contextualPath)
            : base(context, resourceName)
        {
            _context = context;
            _allOperations = allOperations;
            DefaultName = defaultName;
            ContextualPath = contextualPath;
        }

        protected override string DefaultName { get; }

        protected virtual RequestPath ContextualPath { get; }

        protected override string DefaultAccessibility => "public";

        public virtual bool IsEmpty => !ClientOperations.Any() && !ChildResources.Any();

        public override IEnumerable<MgmtClientOperation> ClientOperations => _clientOperations ??= EnsureClientOperations();

        private IEnumerable<MgmtClientOperation>? _clientOperations;
        private IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            return _allOperations.Select(operation =>
            {
                var operationName = GetOperationName(operation, ResourceName);
                // TODO -- these logic needs a thorough refactor -- the values MgmtRestOperation consumes here are actually coupled together, some of the values are calculated multiple times (here and in writers).
                // we just leave this implementation here since it could work for now
                return MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        _context.Library.GetRestClientMethod(operation),
                        _context.Library.GetRestClient(operation),
                        operation.GetRequestPath(_context),
                        ContextualPath,
                        operationName,
                        operation.GetReturnTypeAsLongRunningOperation(null, operationName, _context),
                        _context));
            });
        }

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

        private IEnumerable<MgmtRestClient>? _restClients;
        public override IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients();

        private IEnumerable<MgmtRestClient> EnsureRestClients()
        {
            return ClientOperations.SelectMany(operation => operation.Select(restOperation => restOperation.RestClient)).Distinct();
        }
    }
}
