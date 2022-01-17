// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal abstract class MgmtExtensions : MgmtTypeProvider
    {
        protected IEnumerable<Operation> _allOperations;

        public MgmtExtensions(IEnumerable<Operation> allOperations, string resourceName, BuildContext<MgmtOutputLibrary> context) : base(context, resourceName)
        {
            _context = context;
            _allOperations = allOperations;
        }

        protected abstract RequestPath ContextualPath { get; }

        protected override string DefaultAccessibility => "public";

        public virtual bool IsEmpty => !ClientOperations.Any() && !ChildResources.Any();

        public override IEnumerable<MgmtClientOperation> ClientOperations => _clientOperations ??= EnsureClientOperations();

        private IEnumerable<MgmtClientOperation>? _clientOperations;
        private IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            return _allOperations.Select(operation =>
            {
                var operationName = GetOperationName(operation, ResourceName);
                return MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        _context.Library.GetRestClientMethod(operation),
                        _context.Library.GetRestClient(operation),
                        operation.GetRequestPath(_context),
                        ContextualPath,
                        operationName,
                        GetResourceFromResourceType(operation.GetRequestPath(_context).GetResourceType(_context.Configuration.MgmtConfiguration)),
                        operation.GetReturnTypeAsLongRunningOperation(null, operationName, _context)));
            });
        }
        protected override string GetOperationName(Operation operation, string clientResourceName)
        {
            var opertionName = base.GetOperationName(operation, clientResourceName);

            

            return opertionName;
        }

        private Resource? GetResourceFromResourceType(ResourceTypeSegment resourceType)
        {
            var candidates = _context.Library.ArmResources.Where(resource => resource.ResourceType == resourceType);
            if (candidates.Count() == 0)
                return null;

            if (candidates.Count() == 1)
                return candidates.First();

            throw new InvalidOperationException($"Found more than 1 candidate for {resourceType}, results were ({string.Join(',', candidates.Select(r => r.ResourceName))})");
        }

        private IEnumerable<MgmtRestClient>? _restClients;
        public override IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients();

        private IEnumerable<MgmtRestClient> EnsureRestClients()
        {
            return ClientOperations.SelectMany(operation => operation.Select(restOperation => restOperation.RestClient)).Distinct();
        }
    }
}
