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

        public MgmtExtensions(IEnumerable<Operation> allOperations, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _context = context;
            _allOperations = allOperations;
        }

        protected abstract RequestPath ContextualPath { get; }

        protected override string DefaultAccessibility => "public";

        public override IEnumerable<MgmtClientOperation> ClientOperations => _clientOperations ??= EnsureClientOperations();

        private IEnumerable<MgmtClientOperation>? _clientOperations;
        private IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            return _allOperations.Select(operation => MgmtClientOperation.FromOperation(
                new MgmtRestOperation(
                    _context.Library.RestClientMethods[operation],
                    _context.Library.GetRestClient(operation.GetHttpPath()),
                    operation.GetRequestPath(_context),
                    ContextualPath,
                    GetOperationName(operation, ContextualPath, null))));
        }

        private IEnumerable<MgmtRestClient>? _restClients;
        public override IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients();

        private IEnumerable<MgmtRestClient> EnsureRestClients()
        {
            return ClientOperations.SelectMany(operation => operation.Select(restOperation => restOperation.RestClient)).Distinct();
        }

        protected override string GetOperationName(Operation operation, RequestPath contextualPath, MgmtRestClient? resourceRestClient)
        {
            var restClientMethod = _context.Library.RestClientMethods[operation];
            if (restClientMethod.IsListMethod(out var itemType)
                && !itemType.IsFrameworkType // we need to ensure this is not a framework type
                && _context.Library.TryGetTypeProvider(itemType.Name, out var provider)) // and get the model name we are listing
            {
                // even if we are list a resource data under the subscription, we could have different scopes. The most common case is that we are listing under "subscriptions/locations"
                var extraScopes = MethodExtensions.GetExtraScopes(operation.GetRequestPath(_context), contextualPath);
                var suffix = GetOperationNameExtraScopeSuffix(extraScopes);
                var by = string.IsNullOrEmpty(suffix) ? string.Empty : "By";

                var itemName = provider is ResourceData data ?
                    _context.Library.FindResources(data).First().ResourceName :
                    itemType.Name;
                return $"Get{itemName.ToPlural()}{by}{suffix}";
            }

            return base.GetOperationName(operation, contextualPath, resourceRestClient);
        }

        private string GetOperationNameExtraScopeSuffix(IEnumerable<Segment> extraScope)
        {
            return string.Join("", extraScope.Select(segment => segment.IsConstant ? segment.ConstantValue.ToSingular() : segment.ReferenceName)
                .Select(segment => segment.RemoveInvalidCharacters().ToCleanName()));
        }
    }
}
