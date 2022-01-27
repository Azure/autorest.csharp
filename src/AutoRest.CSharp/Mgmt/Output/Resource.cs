﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : MgmtTypeProvider
    {
        protected static readonly string ResourcePosition = "resource";
        protected static readonly string CollectionPosition = "collection";

        private static readonly HttpMethod[] MethodToExclude = new[] { HttpMethod.Put, HttpMethod.Get, HttpMethod.Delete, HttpMethod.Patch };

        /// <summary>
        /// The position means which class an operation should go. Possible value of this property is `resource` or `collection`.
        /// There is a configuration in <see cref="MgmtConfiguration"/> which assign values to operations.
        /// </summary>
        protected string Position { get; }

        public IEnumerable<OperationSet> OperationSets { get; }

        private IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> _allOperationMap;

        private IEnumerable<RequestPath>? _requestPaths;
        public IEnumerable<RequestPath> RequestPaths => _requestPaths ??= OperationSets.Select(operationSet => operationSet.GetRequestPath(_context));

        /// <summary>
        /// </summary>
        /// <param name="allOperations">The map that contains all possible operations in this resource and its corresponding resource collection class (if any)</param>
        /// <param name="resourceName">The name of the corresponding resource data model</param>
        /// <param name="resourceType">The type of this resource instance represents</param>
        /// <param name="resourceData">The corresponding resource data model</param>
        /// <param name="context">The build context of this resource instance</param>
        /// <param name="position">The position of operations of this class. <see cref="Position"/> for more information</param>
        protected internal Resource(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> allOperations, string resourceName, ResourceTypeSegment resourceType, ResourceData resourceData, BuildContext<MgmtOutputLibrary> context, string position)
            : base(context, resourceName)
        {
            _context = context;
            OperationSets = allOperations.Keys;
            ResourceType = resourceType;
            ResourceData = resourceData;

            if (OperationSets.First().TryGetSingletonResourceSuffix(context, out var singletonResourceIdSuffix))
                SingletonResourceIdSuffix = singletonResourceIdSuffix;

            _allOperationMap = GetAllOperationsMap(allOperations);

            IsById = OperationSets.Any(operationSet => operationSet.IsById(_context));

            Position = position;
        }

        public Resource(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> allOperations, string resourceName, ResourceTypeSegment resourceType, ResourceData resourceData, BuildContext<MgmtOutputLibrary> context)
            : this(allOperations, resourceName, resourceType, resourceData, context, ResourcePosition)
        { }

        private IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> GetAllOperationsMap(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> allOperations)
        {
            var result = new Dictionary<OperationSet, IEnumerable<Operation>>();

            foreach ((var operationSet, var operations) in allOperations)
            {
                result.Add(operationSet, operations.Concat(operationSet.Where(operation => !MethodToExclude.Contains(operation.GetHttpRequest()!.Method))));
            }

            return result;
        }

        public bool IsInOperationMap(Operation operation)
        {
            foreach (var opSet in _allOperationMap.Keys)
            {
                if (opSet.Contains(operation))
                    return true;
            }

            foreach (var opSet in _allOperationMap.Values)
            {
                if (opSet.Contains(operation))
                    return true;
            }

            return false;
        }

        protected bool IsById { get; }

        protected MgmtClientOperation? GetOperationWithVerb(HttpMethod method, string operationName)
        {
            var result = new List<MgmtRestOperation>();
            foreach (var operationSet in OperationSets)
            {
                var operation = operationSet.GetOperation(method);
                if (operation is not null)
                {
                    var restClient = _context.Library.GetRestClient(operation);
                    var requestPath = operation.GetRequestPath(_context);
                    var contextualPath = GetContextualPath(operationSet, requestPath);
                    var restOperation = new MgmtRestOperation(
                        _context.Library.GetRestClientMethod(operation),
                        restClient,
                        requestPath,
                        contextualPath,
                        operationName,
                        operation.GetReturnTypeAsLongRunningOperation(this, operationName, _context),
                        _context);
                    result.Add(restOperation);
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
                var name = string.Join("", types.Select(segment => segment.ConstantValue.LastWordToSingular().FirstCharToUpperCase()));
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
                if (_context.Configuration.MgmtConfiguration.RequestPathToResourceName.TryGetValue($"{operationSet.RequestPath}|{ResourceType}", out name))
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
        public ResourceCollection? ResourceCollection { get; internal set; }

        /// <summary>
        /// Finds the corresponding <see cref="ResourceData"/> of this <see cref="Resource"/>
        /// </summary>
        public ResourceData ResourceData { get; }

        public MgmtClientOperation? CreateOperation => GetOperationWithVerb(HttpMethod.Put, "CreateOrUpdate");
        public MgmtClientOperation GetOperation => GetOperationWithVerb(HttpMethod.Get, "Get")!;
        public MgmtClientOperation? DeleteOperation => GetOperationWithVerb(HttpMethod.Delete, "Delete");
        public MgmtClientOperation? UpdateOperation => GetOperationWithVerb(HttpMethod.Patch, "Update");

        protected virtual bool ShouldIncludeOperation(Operation operation)
        {
            var requestPath = operation.GetHttpPath();
            if (Context.Configuration.MgmtConfiguration.OperationPositions.TryGetValue(requestPath, out var positions))
            {
                return positions.Contains(Position);
            }
            // In the resource class, we need to exclude the List operations
            var restClientMethod = _context.Library.GetRestClientMethod(operation);
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
            foreach ((var operationSet, var operations) in _allOperationMap)
            {
                var resourceRequestPath = operationSet.GetRequestPath(_context);
                var resourceRestClient = _context.Library.GetRestClient(operationSet.First());
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
                    // the operations are grouped by the following key
                    var key = $"{method}{resourceTrimmedPath.Minus(requestTrimmedPath)}";
                    var contextualPath = GetContextualPath(operationSet, requestPath);
                    var methodName = IsListOperation(operation, operationSet) ?
                        "GetAll" :// hard-code the name of a resource collection operation to "GetAll"
                        GetOperationName(operation, resourceRestClient.OperationGroup.Key);
                    // get the MgmtRestOperation with a proper name
                    var restClient = _context.Library.GetRestClient(operation);
                    var restOperation = new MgmtRestOperation(
                        _context.Library.GetRestClientMethod(operation),
                        restClient,
                        requestPath,
                        contextualPath,
                        methodName,
                        operation.GetReturnTypeAsLongRunningOperation(this, methodName, _context),
                        _context);

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
            var resourceRestClients = OperationSets.SelectMany(operationSet => operationSet.Select(operation => _context.Library.GetRestClient(operation))).Distinct();

            return resourceRestClients.Concat(childRestClients).Distinct();
        }

        private MgmtRestClient? _myRestClient;
        public MgmtRestClient MyRestClient => _myRestClient ??= RestClients.FirstOrDefault(client => client.Resources.Any(resource => resource.ResourceName == ResourceName)) ?? RestClients.First();

        private IEnumerable<MgmtRestClient>? _otherRestClients;
        public IEnumerable<MgmtRestClient> OtherRestClients => _otherRestClients ??= RestClients.Where(client => client != MyRestClient);

        public ResourceTypeSegment ResourceType { get; }

        protected virtual string CreateDescription(string clientPrefix)
        {
            return $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.";
        }

        private string ParentPrefix(Resource resource) => string.Join("", resource.Parent(_context).Select(p => p.ResourceName));

        /// <summary>
        /// Returns the different method signature for different base path of this resource
        /// </summary>
        /// <returns></returns>
        public IDictionary<RequestPath, MethodSignature> CreateResourceIdentifierMethodSignature()
        {
            return RequestPaths.ToDictionary(requestPath => requestPath,
                requestPath => new MethodSignature(
                    Name: "CreateResourceIdentifier",
                    Description: $"Generate the resource identifier of a <see cref=\"{Type.Name}\"/> instance.",
                    Modifiers: "public static",
                    ReturnType: typeof(ResourceIdentifier),
                    ReturnDescription: null,
                    Parameters: requestPath.Where(segment => segment.IsReference).Select(segment => new Parameter(segment.Reference.Name, null, segment.Reference.Type, null, true)).ToArray()));
        }

        public FormattableString ResourceDataIdExpression(FormattableString dataExpression)
        {
            var typeOfId = ResourceData.TypeOfId;
            if (typeOfId != null && typeOfId.Equals(typeof(string)))
            {
                return $"new {typeof(ResourceIdentifier)}({dataExpression}.Id)";
            }
            else
            {
                // we have ensured other cases we would have an Id of Azure.Core.ResourceIdentifier type
                return $"{dataExpression}.Id";
            }
        }

        public static Parameter ArmClientParameter => new Parameter(Name: "armClient", Description: $"The client parameters to use in these operations.",
                    Type: typeof(Azure.ResourceManager.ArmClient), DefaultValue: null, ValidateNotNull: false);
        public Parameter ResourceParameter => new Parameter(Name: "resource", Description: $"The client parameters to use in these operations.",
                            Type: typeof(Azure.ResourceManager.Core.ArmResource), DefaultValue: null, ValidateNotNull: false);
        public Parameter ResourceDataParameter => new Parameter(Name: "data", Description: $"The resource that is the target of operations.",
                        Type: ResourceData.Type, DefaultValue: null, ValidateNotNull: false);
        public static Parameter ResourceIdentifierParameter => new Parameter(Name: "id", Description: $"The identifier of the resource that is the target of operations.",
                        Type: typeof(Azure.Core.ResourceIdentifier), DefaultValue: null, ValidateNotNull: false);
    }
}
