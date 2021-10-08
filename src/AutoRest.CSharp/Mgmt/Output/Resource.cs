// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using ResourceType = AutoRest.CSharp.Mgmt.Models.ResourceType;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : MgmtTypeProvider
    {
        //public bool IsScopeOrExtension { get; } // will be back soon

        public IEnumerable<OperationSet> OperationSets { get; }

        private IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> _allOperations;

        private IEnumerable<string>? _requestPaths;
        public IEnumerable<string> RequestPaths => _requestPaths ??= OperationSets.Select(operationSet => operationSet.RequestPath);

        public Resource(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> allOperations, string resourceName, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _context = context;
            _allOperations = allOperations;
            OperationSets = allOperations.Keys;
            ResourceName = resourceName;
            //DefaultName = resourceName + SuffixValue;

            if (OperationSets.First().TryGetSingletonResourceSuffix(context, out var singletonResourceIdSuffix))
                SingletonResourceIdSuffix = singletonResourceIdSuffix;

            GetOperation = GetOperationWithVerb(HttpMethod.Get);
            DeleteOperation = GetOperationWithVerb(HttpMethod.Delete);
            UpdateOperation = GetOperationWithVerb(HttpMethod.Patch);
            PostOperation = GetOperationWithVerb(HttpMethod.Post);
        }

        protected MgmtClientOperation? GetOperationWithVerb(HttpMethod method)
        {
            var result = new List<MgmtRestOperation>();
            foreach (var operationSet in OperationSets)
            {
                var operation = operationSet.GetOperation(method);
                if (operation is not null)
                {
                    var clientOperation = new MgmtRestOperation(_context.Library.RestClientMethods[operation],
                        _context.Library.GetRestClient(operation.GetHttpPath()), GetContextualPath(operationSet));
                    result.Add(clientOperation);
                }
            }

            return MgmtClientOperation.FromOperations(result);
        }

        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= EnsureResourceDefaultName();

        private string EnsureResourceDefaultName()
        {
            // TODO -- sometimes we might have multiple resources with the same name, we need to resolve this here
            // But temporarily, we just return the ResourceName and assume we will not hit on any issues
            return ResourceName;
        }

        protected override string DefaultAccessibility => "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(ResourceName));

        public bool IsSingleton => SingletonResourceIdSuffix != null;

        public string? SingletonResourceIdSuffix { get; }

        /// <summary>
        /// Finds the corresponding <see cref="ResourceContainer"/> of this <see cref="Resource"/>
        /// Return null when this resource is a singleton.
        /// </summary>
        public ResourceContainer? ResourceContainer => _context.Library.GetResourceContainer(RequestPaths.First());

        /// <summary>
        /// Finds the corresponding <see cref="ResourceData"/> of this <see cref="Resource"/>
        /// </summary>
        public ResourceData ResourceData => _context.Library.GetResourceData(RequestPaths.First());

        public virtual string ResourceName { get; }

        public virtual MgmtClientOperation? GetOperation { get; }
        public virtual MgmtClientOperation? DeleteOperation { get; }
        public virtual MgmtClientOperation? UpdateOperation { get; }
        public virtual MgmtClientOperation? PostOperation { get; }

        protected virtual bool ShouldIncludeOperation(Operation operation)
        {
            // In the resource class, we need to exclude the List operations
            var restClientMethod = _context.Library.RestClientMethods[operation];
            if (restClientMethod.IsListMethod(out var valueType, out _))
                return !valueType.EqualsByName(ResourceData.Type);
            return true;
        }

        /// <summary>
        /// A collection of ClientOperations.
        /// The List of <see cref="MgmtRestOperation"/> represents a set of the same operations under different parent (OperationSet)
        /// </summary>
        public override IEnumerable<MgmtClientOperation> ClientOperations => EnsureClientOperationMap().Values;

        /// <summary>
        /// This is a map from the diff request path between the operation and the contextual path to the actual operations
        /// </summary>
        private IDictionary<string, MgmtClientOperation>? _clientOperationMap;
        private IDictionary<string, MgmtClientOperation> EnsureClientOperationMap()
        {
            if (_clientOperationMap != null)
                return _clientOperationMap;

            var result = new Dictionary<string, List<MgmtRestOperation>>();
            foreach ((var operationSet, var operations) in _allOperations)
            {
                // iterate over all the operations under this operationSet to get their diff between the corresponding contextual path
                foreach (var operation in operations)
                {
                    if (!ShouldIncludeOperation(operation))
                        continue; // meaning this operation will be included in the container
                    // first we need to see if this operation is a collection operation. Collection operation is not literally a child of the corresponding resource
                    string key;
                    if (IsListOperation(operation, operationSet))
                    {
                        // if this operation is a collection operation, it should be the parent of its corresponding resource request path
                        var diff = new RequestPath(operation.GetRequestPath(_context).TrimParentFrom(operationSet.GetRequestPath(_context)).ToList());
                        // since in this case, the diff is a "minus" diff comparing with the other branch of the condition, we add a minus sign at the beginning of this key ti make sure this key would not collide with others
                        key = $"-{diff}";
                    }
                    else
                        // for other child operations, they should be child of the corresponding resource request path
                        key = new RequestPath(operationSet.GetRequestPath(_context).TrimParentFrom(operation.GetRequestPath(_context)).ToList());
                    var restOperation = new MgmtRestOperation(
                        _context.Library.RestClientMethods[operation],
                        _context.Library.GetRestClient(operation.GetHttpPath()),
                        GetContextualPath(operationSet));
                    if (result.TryGetValue(key, out var list))
                    {
                        list.Add(restOperation);
                    }
                    else
                    {
                        result.Add(key, new List<MgmtRestOperation> { restOperation });
                    }
                }
            }

            // now the operations should be properly categarized into the dictionary in the key of diff between contextual request path and the operation
            // TODO -- what if the response type is not the same? Also we need to verify they have the same parameters before we could union those together
            _clientOperationMap = result.Where(pair => pair.Value.Count > 0).ToDictionary(
                pair => pair.Key,
                pair => MgmtClientOperation.FromOperations(pair.Value)!); // We first filtered the ones with at least one operation, therefore this will never be null
            return _clientOperationMap;
        }

        private bool IsListOperation(Operation operation, OperationSet operationSet)
        {
            return operation.IsResourceCollectionOperation(_context, out var resourceOperationSet) && resourceOperationSet == operationSet;
        }

        /// <summary>
        /// This method returns the contextual path from one resource <see cref="OperationSet"/>
        /// In the <see cref="Resource"/> class, we just use the RequestPath of the OperationSet as its contextual path
        /// </summary>
        /// <param name="operationSet"></param>
        /// <returns></returns>
        protected virtual RequestPath GetContextualPath(OperationSet operationSet)
        {
            return operationSet.GetRequestPath(_context);
        }

        private IEnumerable<MgmtRestClient>? _restClients;
        public IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients();

        private IEnumerable<MgmtRestClient> EnsureRestClients()
        {
            var childRestClients = ClientOperations.SelectMany(clientOperation => clientOperation.Select(restOperation => restOperation.RestClient)).Distinct();
            var resourceRestClients = OperationSets.Select(operationSet => _context.Library.GetRestClient(operationSet.RequestPath)).Distinct();

            return resourceRestClients.Concat(childRestClients).Distinct();
        }

        private IDictionary<OperationSet, ResourceType>? _resourceTypes;
        public IDictionary<OperationSet, ResourceType> ResourceTypes => _resourceTypes ??= OperationSets.ToDictionary(
            operationSet => operationSet,
            operationSet => GetContextualPath(operationSet).GetResourceType(_context.Configuration.MgmtConfiguration));

        public Diagnostic GetDiagnostic(RestClientMethod method)
        {
            return new Diagnostic($"{Declaration.Name}.{method.Name}", Array.Empty<DiagnosticAttribute>());
        }

        protected virtual string CreateDescription(string clientPrefix)
        {
            return $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.";
        }
    }
}
