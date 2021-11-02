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
using AutoRest.CSharp.Utilities;
using ResourceType = AutoRest.CSharp.Mgmt.Models.ResourceType;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : MgmtTypeProvider
    {
        public IEnumerable<OperationSet> OperationSets { get; }

        private IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> _allOperationMap;

        private IEnumerable<RequestPath>? _requestPaths;
        public IEnumerable<RequestPath> RequestPaths => _requestPaths ??= OperationSets.Select(operationSet => operationSet.GetRequestPath(_context));

        public Resource(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> allOperations, string resourceName, ResourceType resourceType, BuildContext<MgmtOutputLibrary> context)
            : base(context)
        {
            _context = context;
            OperationSets = allOperations.Keys;
            ResourceName = resourceName;
            ResourceType = resourceType;

            if (OperationSets.First().TryGetSingletonResourceSuffix(context, out var singletonResourceIdSuffix))
                SingletonResourceIdSuffix = singletonResourceIdSuffix;

            CreateOperation = GetOperationWithVerb(HttpMethod.Put, "CreateOrUpdate");
            GetOperation = GetOperationWithVerb(HttpMethod.Get, "Get");
            DeleteOperation = GetOperationWithVerb(HttpMethod.Delete, "Delete");
            UpdateOperation = GetOperationWithVerb(HttpMethod.Patch, "Update");

            _allOperationMap = GetAllOperationsMap(allOperations);

            IsById = OperationSets.Any(operationSet => operationSet.IsById(_context));
        }

        private static readonly HttpMethod[] MethodToExclude = new[] { HttpMethod.Put, HttpMethod.Get, HttpMethod.Delete, HttpMethod.Patch };

        private IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> GetAllOperationsMap(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> allOperations)
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
                    var requestPath = operation.GetRequestPath(_context);
                    var clientOperation = new MgmtRestOperation(
                        _context.Library.RestClientMethods[operation],
                        _context.Library.GetRestClient(operation.GetHttpPath()),
                        requestPath,
                        GetContextualPath(operationSet, requestPath),
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

            var resourcesWithSameName = ResourcesWithSameResourceName();
            var resourcesWithSameType = ResourcesWithSameResourceType();
            int countOfSameResourceDataName = resourcesWithSameName.Count();
            int countOfSameResourceTypeName = resourcesWithSameType.Count();
            if (!IsById)
            {
                // this is a regular resource and the name is unique
                if (countOfSameResourceDataName == 1)
                    return ResourceName;

                // if countOfSameResourceDataName > 1, we need to have the resource types as the resource type name

                // if we have the unique resource type, we just use the resource type to construct our resource type name
                var types = ResourceType.Types;
                var name = string.Join("", types.Select(segment => segment.ConstantValue.ToSingular().FirstCharToUpperCase()));
                if (countOfSameResourceTypeName == 1)
                    return name;

                // if countOfSameResourceTypeName > 1, we will have to add the scope as prefix to fully qualify the resource type name
                // first we try to add the parent name as prefix
                var prefixes = resourcesWithSameType.Select(resource => ParentPrefix(resource)).Distinct();
                if (prefixes.Count() == countOfSameResourceTypeName)
                {
                    // this means that we have unique parent prefix for each resource with the same type, use the parent as prefix
                    return ParentPrefix(this) + name;
                }
                // if we get here, parent prefix is not enough, we try the resource name if it is a constant
                var nameSegments = RequestPaths.Select(p => p.Last()).Where(segment => segment.IsConstant).Select(segment => segment.ConstantValue.FirstCharToUpperCase());
                if (nameSegments.Any())
                    return name + string.Join("", nameSegments);

                // if we get here, we have tried all approaches to get a solid resource type name, throw an exception
                throw new InvalidOperationException($"Cannot determine a resource class name for resource with the request path(s): {string.Join(", ", RequestPaths)}, please assign a valid resource name in `request-path-to-resource-name` section");
            }
            // if this resource is based on a "ById" operation
            // if we only have one resource class with this name - we have no choice but use this "ById" resource
            if (countOfSameResourceDataName == 1)
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

        private IEnumerable<Resource> ResourcesWithSameResourceName() => _context.Library.ArmResources.Where(resource => resource.ResourceName == ResourceName);

        private IEnumerable<Resource> ResourcesWithSameResourceType() => _context.Library.ArmResources.Where(resource => resource.ResourceType == ResourceType);

        protected override string DefaultAccessibility => "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(ResourceName));

        public bool IsSingleton => SingletonResourceIdSuffix != null;

        public string? SingletonResourceIdSuffix { get; }

        /// <summary>
        /// Finds the corresponding <see cref="ResourceCollection"/> of this <see cref="Resource"/>
        /// Return null when this resource is a singleton.
        /// </summary>
        public ResourceCollection? ResourceCollection => _context.Library.GetResourceCollection(RequestPaths.First());

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

        private IEnumerable<MgmtClientOperation>? _allOperations;
        public virtual IEnumerable<MgmtClientOperation> AllOperations => _allOperations ??= EnsureAllOperations();

        private IEnumerable<MgmtClientOperation> EnsureAllOperations()
        {
            var result = new List<MgmtClientOperation>();
            if (GetOperation != null)
                result.Add(GetOperation);
            if (DeleteOperation != null)
                result.Add(DeleteOperation);
            if (UpdateOperation != null)
                result.Add(UpdateOperation);
            result.AddRange(ClientOperations);
            return result;
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
            var methodNames = new Dictionary<string, MgmtRestOperation>();
            foreach ((var operationSet, var operations) in _allOperationMap)
            {
                var resourceRequestPath = operationSet.GetRequestPath(_context);
                var resourceRestClient = _context.Library.GetRestClient(resourceRequestPath);
                // iterate over all the operations under this operationSet to get their diff between the corresponding contextual path
                foreach (var operation in operations)
                {
                    if (!ShouldIncludeOperation(operation))
                        continue; // meaning this operation will be included in the collection
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
                        contextualPath = GetContextualPath(operationSet, requestPath);
                        methodName = "GetAll"; // hard-code the name of a resource collection operation to "GetAll"
                    }
                    else
                    {
                        // for other child operations, they should be child of the corresponding resource request path
                        var diff = resourceTrimmedPath.TrimAncestorFrom(requestTrimmedPath);
                        key = $"{method}{diff}";
                        contextualPath = GetContextualPath(operationSet, requestPath);
                        methodName = GetOperationName(operation, resourceRestClient);
                    }

                    var restClient = _context.Library.GetRestClient(operation.GetHttpPath());

                    // check duplicated names
                    if (methodNames.TryGetValue(methodName, out MgmtRestOperation? duplicate))
                    {
                        ErrorHelpers.ThrowError($"Duplicated method name '{methodName}' is detected. Check operations '{duplicate.OperationId}' and '{MgmtRestOperation.BuildOperationId(restClient.OperationGroup, operation)}'. Consider to use directive 'rename-operation' to avoid conflicts.");
                    }

                    // get the MgmtRestOperation with a proper name
                    var restOperation = new MgmtRestOperation(
                        _context.Library.RestClientMethods[operation],
                        restClient,
                        requestPath,
                        contextualPath,
                        methodName); ;


                    if (result.TryGetValue(key, out var list))
                    {
                        list.Add(restOperation);
                    }
                    else
                    {
                        result.Add(key, new List<MgmtRestOperation> { restOperation });
                    }

                    methodNames.Add(methodName, restOperation);
                }
            }

            // now the operations should be properly categarized into the dictionary in the key of diff between contextual request path and the operation
            // TODO -- what if the response type is not the same? Also we need to verify they have the same parameters before we could union those together
            _clientOperationMap = result.Where(pair => pair.Value.Count > 0).ToDictionary(
                pair => pair.Key,
                pair => MgmtClientOperation.FromOperations(pair.Value)!); // We first filtered the ones with at least one operation, therefore this will never be null
            return _clientOperationMap;
        }

        /// <summary>
        /// This method returns the contextual path from one resource <see cref="OperationSet"/>
        /// In the <see cref="Resource"/> class, we just use the RequestPath of the OperationSet as its contextual path
        /// Also we need to replace the parameterized scope if there is any with the actual scope value.
        /// </summary>
        /// <param name="operationSet"></param>
        /// <param name="operationRequestPath"></param>
        /// <returns></returns>
        protected virtual RequestPath GetContextualPath(OperationSet operationSet, RequestPath operationRequestPath)
        {
            var contextualPath = operationSet.GetRequestPath(_context);
            // we need to replace the scope in this contextual path with the actual scope in the operation
            var scope = contextualPath.GetScopePath();
            if (!scope.IsParameterizedScope())
                return contextualPath;

            return operationRequestPath.GetScopePath().Append(contextualPath.TrimScope());
        }

        private bool IsListOperation(Operation operation, OperationSet operationSet)
        {
            return operation.IsResourceCollectionOperation(_context, out var resourceOperationSet) && resourceOperationSet == operationSet;
        }

        private IEnumerable<MgmtRestClient>? _restClients;
        public override IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients();

        private IEnumerable<MgmtRestClient> EnsureRestClients()
        {
            var childRestClients = ClientOperations.SelectMany(clientOperation => clientOperation.Select(restOperation => restOperation.RestClient)).Distinct();
            var resourceRestClients = OperationSets.Select(operationSet => _context.Library.GetRestClient(operationSet.RequestPath)).Distinct();

            return resourceRestClients.Concat(childRestClients).Distinct();
        }

        public virtual ResourceType ResourceType { get; }

        protected virtual string CreateDescription(string clientPrefix)
        {
            return $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.";
        }

        private string ParentPrefix(Resource resource) => string.Join("", resource.Parent(_context).Select(p => p.ResourceName));
    }
}
