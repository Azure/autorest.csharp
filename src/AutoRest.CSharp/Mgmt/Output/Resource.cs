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
        public IEnumerable<OperationSet> OperationSets { get; }

        private IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> _allOperations;

        private IEnumerable<string>? _requestPaths;
        public IEnumerable<string> RequestPaths => _requestPaths ??= OperationSets.Select(operationSet => operationSet.RequestPath);

        public Resource(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> allOperations, string resourceName, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _context = context;
            OperationSets = allOperations.Keys;
            ResourceName = resourceName;

            if (OperationSets.First().TryGetSingletonResourceSuffix(context, out var singletonResourceIdSuffix))
                SingletonResourceIdSuffix = singletonResourceIdSuffix;

            CreateOperation = GetOperationWithVerb(HttpMethod.Put, "CreateOrUpdate");
            GetOperation = GetOperationWithVerb(HttpMethod.Get, "Get");
            DeleteOperation = GetOperationWithVerb(HttpMethod.Delete, "Delete");
            UpdateOperation = GetOperationWithVerb(HttpMethod.Patch, "Update");

            _allOperations = GetAllOperations(allOperations);

            IsById = OperationSets.Any(operationSet => operationSet.IsById(_context));
        }

        private static readonly HttpMethod[] MethodToExclude = new[] { HttpMethod.Put, HttpMethod.Get, HttpMethod.Delete, HttpMethod.Patch };

        private IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> GetAllOperations(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> allOperations)
        {
            var result = new Dictionary<OperationSet, IEnumerable<Operation>>();

            foreach ((var operationSet, var operations) in allOperations)
            {
                result.Add(operationSet, operations.Concat(operationSet.Where(operation => !MethodToExclude.Contains(operation.GetHttpRequest()!.Method))));
            }

            return result;
        }

        private bool IsById { get; }

        protected MgmtClientOperation? GetOperationWithVerb(HttpMethod method, string name)
        {
            var result = new List<MgmtRestOperation>();
            foreach (var operationSet in OperationSets)
            {
                var operation = operationSet.GetOperation(method);
                if (operation is not null)
                {
                    var clientOperation = new MgmtRestOperation(
                        _context.Library.RestClientMethods[operation],
                        _context.Library.GetRestClient(operation.GetHttpPath()),
                        operation.GetRequestPath(_context),
                        GetContextualPath(operationSet),
                        name);
                    result.Add(clientOperation);
                }
            }

            return MgmtClientOperation.FromOperations(result);
        }

        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= EnsureResourceDefaultName();

        private string EnsureResourceDefaultName()
        {
            // read configuration to see if we could get a configuration for this resource
            var defaultNameFromConfig = GetDefaultNameFromConfiguration();
            if (defaultNameFromConfig != null)
                return defaultNameFromConfig;

            int count = ResourceWithSameResourceNameCount();
            if (!IsById)
            {
                // this is a regular resource and the name is unique
                if (count == 1)
                    return ResourceName;
                // otherwise we need prefix to distinguish the resources
                // TODO -- introduce a flag that suppress the exception here to be thrown which notice the user to assign a proper name in config

                // otherwise we append the parent name to it
                var parents = this.Parent(_context);
                var parentSuffix = string.Join("", parents.Select(p => p.ResourceName));
                return $"{parentSuffix}{ResourceName}";
            }
            // if this resource is based on a "ById" operation
            // if we only have one resource class with this name - we have no choice but use this "ById" resource
            if (count == 1)
                return ResourceName;

            // otherwise we need to add a "ById" suffix to make this resource to have a different name
            // TODO -- introduce a flag that suppress the exception here to be thrown which notice the user to assign a proper name in config
            return $"{ResourceName}ById";
        }

        private string? GetDefaultNameFromConfiguration()
        {
            foreach (var operationSet in OperationSets)
            {
                if (_context.Configuration.MgmtConfiguration.RequestPathToResourceName.TryGetValue(operationSet.RequestPath, out var name))
                    return name;
            }

            return null;
        }

        private int ResourceWithSameResourceNameCount()
        {
            return _context.Library.ArmResources.Count(resource => resource.ResourceName == this.ResourceName);
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

        public override string ResourceName { get; }

        public MgmtClientOperation? CreateOperation { get; }
        public virtual MgmtClientOperation? GetOperation { get; }
        public virtual MgmtClientOperation? DeleteOperation { get; }
        public virtual MgmtClientOperation? UpdateOperation { get; }

        protected virtual bool ShouldIncludeOperation(Operation operation)
        {
            // In the resource class, we need to exclude the List operations
            var restClientMethod = _context.Library.RestClientMethods[operation];
            if (restClientMethod.IsListMethod(out var valueType))
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
                var resourceRequestPath = operationSet.GetRequestPath(_context);
                var resourceRestClient = _context.Library.GetRestClient(resourceRequestPath);
                // iterate over all the operations under this operationSet to get their diff between the corresponding contextual path
                foreach (var operation in operations)
                {
                    if (!ShouldIncludeOperation(operation))
                        continue; // meaning this operation will be included in the container
                    var method = operation.GetHttpMethod();
                    // considering the case of parameterized scope, we might do not have direct parenting relationship between the two paths
                    // therefore we trim the scope off and then calculate the diff
                    var requestPath = operation.GetRequestPath(_context);
                    var requestTrimmedPath = requestPath.TrimScope();
                    var resourceTrimmedPath = resourceRequestPath.TrimScope();
                    string key;
                    RequestPath contextualPath;
                    string methodName;
                    // first we need to see if this operation is a collection operation. Collection operation is not literally a child of the corresponding resource
                    if (IsListOperation(operation, operationSet))
                    {
                        // if this operation is a collection operation, it should be the parent of its corresponding resource request path
                        var diff = requestTrimmedPath.TrimAncestorFrom(resourceTrimmedPath);
                        // since in this case, the diff is a "minus" diff comparing with the other branch of the condition, we add a minus sign at the beginning of this key ti make sure this key would not collide with others
                        key = $"{method}-{diff}";
                        //contextualPath = GetContextualPath(operationSet);
                        contextualPath = ReplaceParameterizedScope(GetContextualPath(operationSet), requestPath.GetScopePath());
                        methodName = "GetAll"; // hard-code the name of a resource collection operation to "GetAll"
                    }
                    else
                    {
                        // for other child operations, they should be child of the corresponding resource request path
                        var diff = resourceTrimmedPath.TrimAncestorFrom(requestTrimmedPath);
                        key = $"{method}{diff}";
                        contextualPath = ReplaceParameterizedScope(GetContextualPath(operationSet), requestPath.GetScopePath());
                        methodName = GetOperationName(operation, resourceRestClient);
                    }
                    // get the MgmtRestOperation with a proper name
                    var restOperation = new MgmtRestOperation(
                        _context.Library.RestClientMethods[operation],
                        _context.Library.GetRestClient(operation.GetHttpPath()),
                        requestPath,
                        contextualPath,
                        methodName);
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

        private RequestPath ReplaceParameterizedScope(RequestPath path, RequestPath scopeToReplace)
        {
            var scope = path.GetScopePath();
            if (!scope.IsParameterizedScope())
                return path;
            return scopeToReplace.Append(path.TrimScope());
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
        public override IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients();

        private IEnumerable<MgmtRestClient> EnsureRestClients()
        {
            var childRestClients = ClientOperations.SelectMany(clientOperation => clientOperation.Select(restOperation => restOperation.RestClient)).Distinct();
            var resourceRestClients = OperationSets.Select(operationSet => _context.Library.GetRestClient(operationSet.RequestPath)).Distinct();

            return resourceRestClients.Concat(childRestClients).Distinct();
        }

        private ISet<ResourceType>? _resourceTypes;
        public ISet<ResourceType> ResourceTypes => _resourceTypes ??= OperationSets.Select(operationSet => GetContextualPath(operationSet).GetResourceType(_context.Configuration.MgmtConfiguration)).ToHashSet();

        protected virtual string CreateDescription(string clientPrefix)
        {
            return $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.";
        }
    }
}
