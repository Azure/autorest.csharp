﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : MgmtTypeProvider
    {
        protected static readonly string ResourcePosition = "resource";
        protected static readonly string CollectionPosition = "collection";
        private const string DataFieldName = "_data";
        protected readonly Parameter[] _armClientCtorParameters;

        private static readonly HttpMethod[] MethodToExclude = new[] { HttpMethod.Put, HttpMethod.Get, HttpMethod.Delete, HttpMethod.Patch };

        private static readonly Parameter TagKeyParameter = new Parameter(
            "key",
            "The key for the tag.",
            typeof(string),
            null,
            true);

        private static readonly Parameter TagValueParameter = new Parameter(
            "value",
            "The value for the tag.",
            typeof(string),
            null,
            true);

        private static readonly Parameter TagSetParameter = new Parameter(
            "tags",
            "The set of tags to use as replacement.",
            typeof(IDictionary<string, string>),
            null,
            true);

        /// <summary>
        /// The position means which class an operation should go. Possible value of this property is `resource` or `collection`.
        /// There is a configuration in <see cref="MgmtConfiguration"/> which assign values to operations.
        /// </summary>
        protected string Position { get; }

        public OperationSet OperationSet { get; }

        protected IEnumerable<Operation> _clientOperations;

        private RequestPath? _requestPath;
        public RequestPath RequestPath => _requestPath ??= OperationSet.GetRequestPath(ResourceType);

        /// <summary>
        /// </summary>
        /// <param name="operations">The map that contains all possible operations in this resource and its corresponding resource collection class (if any)</param>
        /// <param name="resourceName">The name of the corresponding resource data model</param>
        /// <param name="resourceType">The type of this resource instance represents</param>
        /// <param name="resourceData">The corresponding resource data model</param>
        /// <param name="context">The build context of this resource instance</param>
        /// <param name="position">The position of operations of this class. <see cref="Position"/> for more information</param>
        protected internal Resource(OperationSet operationSet, IEnumerable<Operation> operations, string resourceName, ResourceTypeSegment resourceType, ResourceData resourceData, string position)
            : base(resourceName)
        {
            _armClientCtorParameters = new[] { ArmClientParameter, ResourceIdentifierParameter };
            OperationSet = operationSet;
            ResourceType = resourceType;
            ResourceData = resourceData;

            if (OperationSet.TryGetSingletonResourceSuffix(out var singletonResourceIdSuffix))
                SingletonResourceIdSuffix = singletonResourceIdSuffix;

            _clientOperations = GetClientOperations(operationSet, operations);

            IsById = OperationSet.IsById;

            Position = position;
        }

        protected override ConstructorSignature? EnsureArmClientCtor()
        {
            return new ConstructorSignature(
              Name: Type.Name,
              Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class.",
              Modifiers: Internal,
              Parameters: _armClientCtorParameters,
              Initializer: new(
                  isBase: true,
                  arguments: _armClientCtorParameters));
        }

        protected override ConstructorSignature? EnsureResourceDataCtor()
        {
            return new ConstructorSignature(
                Name: Type.Name,
                Description: $"Initializes a new instance of the <see cref = \"{Type.Name}\"/> class.",
                Modifiers: Internal,
                Parameters: new[] { ArmClientParameter, ResourceDataParameter },
                Initializer: new(
                    IsBase: false,
                    Arguments: new FormattableString[] { $"{ArmClientParameter.Name:I}", ResourceDataIdExpression($"{ResourceDataParameter.Name:I}") }));
        }

        public override CSharpType? BaseType => typeof(ArmResource);

        public override Resource? DefaultResource => this;

        protected override FieldModifiers FieldModifiers => base.FieldModifiers | FieldModifiers.ReadOnly;

        protected override IEnumerable<FieldDeclaration>? GetAdditionalFields()
        {
            yield return new FieldDeclaration(FieldModifiers, ResourceData.Type, DataFieldName);
        }

        public Resource(OperationSet operationSet, IEnumerable<Operation> operations, string resourceName, ResourceTypeSegment resourceType, ResourceData resourceData)
            : this(operationSet, operations, resourceName, resourceType, resourceData, ResourcePosition)
        { }

        private static IEnumerable<Operation> GetClientOperations(OperationSet operationSet, IEnumerable<Operation> operations)
            => operations.Concat(operationSet.Where(operation => !MethodToExclude.Contains(operation.GetHttpMethod())));

        protected bool IsById { get; }

        protected MgmtClientOperation? GetOperationWithVerb(HttpMethod method, string operationName, bool? isLongRunning = null, bool throwIfNull = false)
        {
            var result = new List<MgmtRestOperation>();
            var operation = OperationSet.GetOperation(method);
            if (operation is not null)
            {
                var restClient = MgmtContext.Library.GetRestClient(operation);
                var requestPath = operation.GetRequestPath(ResourceType);
                var contextualPath = GetContextualPath(OperationSet, requestPath);
                var restOperation = new MgmtRestOperation(
                    MgmtContext.Library.GetRestClientMethod(operation),
                    restClient,
                    requestPath,
                    contextualPath,
                    operationName,
                    isLongRunning,
                    throwIfNull);
                result.Add(restOperation);
            }

            return MgmtClientOperation.FromOperations(result);
        }

        public virtual Resource GetResource() => this;

        // name after `{ResourceName}Resource`, unless the `ResourceName` already ends with `Resource`
        protected override string DefaultName => Configuration.MgmtConfiguration.NoResourceSuffix.Contains(ResourceName) ? ResourceName : ResourceName.AddResourceSuffixToResourceName();

        public override FormattableString Description => CreateDescription(ResourceName);

        public bool IsSingleton => SingletonResourceIdSuffix != null;

        public string? SingletonResourceIdSuffix { get; }

        public bool IsTaggable => ResourceData.IsTaggable;

        /// <summary>
        /// Finds the corresponding <see cref="ResourceCollection"/> of this <see cref="Resource"/>
        /// Return null when this resource is a singleton.
        /// </summary>
        public ResourceCollection? ResourceCollection { get; internal set; }

        /// <summary>
        /// Finds the corresponding <see cref="ResourceData"/> of this <see cref="Resource"/>
        /// </summary>
        public ResourceData ResourceData { get; }

        public MgmtClientOperation? CreateOperation => GetOperationWithVerb(HttpMethod.Put, "CreateOrUpdate", true);
        public MgmtClientOperation GetOperation => GetOperationWithVerb(HttpMethod.Get, "Get", throwIfNull: true)!;
        public MgmtClientOperation? DeleteOperation => GetOperationWithVerb(HttpMethod.Delete, "Delete", true);
        public MgmtClientOperation? UpdateOperation => GetOperationWithVerb(HttpMethod.Patch, "Update");

        protected virtual bool ShouldIncludeOperation(Operation operation)
        {
            var operationId = operation.OperationId();
            if (Configuration.MgmtConfiguration.OperationPositions.TryGetValue(operationId, out var positions))
            {
                return positions.Contains(Position);
            }
            // In the resource class, we need to exclude the List operations
            var restClientMethod = MgmtContext.Library.GetRestClientMethod(operation);
            if (restClientMethod.IsListMethod(out var valueType))
                return !valueType.EqualsByName(ResourceData.Type);
            return true;
        }

        protected override IEnumerable<MgmtClientOperation> EnsureAllOperations()
        {
            var result = new List<MgmtClientOperation>();
            if (GetOperation != null)
                result.Add(GetOperation);
            if (DeleteOperation != null)
                result.Add(DeleteOperation);
            if (UpdateOperation is null)
            {
                if (ResourceCollection?.CreateOperation is not null)
                {
                    var createOrUpdateOperation = ResourceCollection.CreateOperation.OperationMappings.Values.First();
                    result.Add(MgmtClientOperation.FromOperation(
                        new MgmtRestOperation(
                            createOrUpdateOperation,
                            "Update",
                            createOrUpdateOperation.MgmtReturnType,
                            createOrUpdateOperation.Description ?? $"Update this {ResourceName}.",
                            createOrUpdateOperation.RequestPath)));
                }
            }
            else
            {
                result.Add(UpdateOperation);
            }
            if (IsSingleton && CreateOperation != null)
                result.Add(CreateOperation);
            result.AddRange(ClientOperations);
            if (GetOperation != null && IsTaggable)
            {
                var getOperation = GetOperation.OperationMappings.Values.First();
                result.Add(MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        getOperation,
                        "AddTag",
                        getOperation.MgmtReturnType,
                        "Add a tag to the current resource.",
                        TagKeyParameter,
                        TagValueParameter)));

                result.Add(MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        getOperation,
                        "SetTags",
                        getOperation.MgmtReturnType,
                        "Replace the tags on the resource with the given set.",
                        TagSetParameter)));

                result.Add(MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        getOperation,
                        "RemoveTag",
                        getOperation.MgmtReturnType,
                        "Removes a tag by key from the resource.",
                        TagKeyParameter)));
            }
            return result;
        }

        public override string BranchIdVariableName => "Id.Parent";

        public override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            return branch.ParentRequestPath().GetResourceType();
        }

        private IEnumerable<ContextualParameterMapping>? _extraContextualParameterMapping;
        public IEnumerable<ContextualParameterMapping> ExtraContextualParameterMapping => _extraContextualParameterMapping ??= EnsureExtraContextualParameterMapping();
        protected virtual IEnumerable<ContextualParameterMapping> EnsureExtraContextualParameterMapping() => Enumerable.Empty<ContextualParameterMapping>();

        /// <summary>
        /// A collection of ClientOperations.
        /// The List of <see cref="MgmtRestOperation"/> represents a set of the same operations under different parent (OperationSet)
        /// </summary>
        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations() => EnsureClientOperationMap().Values;

        /// <summary>
        /// This is a map from the diff request path between the operation and the contextual path to the actual operations
        /// </summary>
        private IDictionary<string, MgmtClientOperation>? _clientOperationMap;
        private IDictionary<string, MgmtClientOperation> EnsureClientOperationMap()
        {
            if (_clientOperationMap != null)
                return _clientOperationMap;

            var result = new Dictionary<string, List<MgmtRestOperation>>();
            var resourceRequestPath = OperationSet.GetRequestPath();
            var resourceRestClient = MgmtContext.Library.GetRestClient(OperationSet.First());
            // iterate over all the operations under this operationSet to get their diff between the corresponding contextual path
            foreach (var operation in _clientOperations)
            {
                if (!ShouldIncludeOperation(operation))
                    continue; // meaning this operation will be included in the collection
                var method = operation.GetHttpMethod();
                // considering the case of parameterized scope, we might do not have direct parenting relationship between the two paths
                // therefore we trim the scope off and then calculate the diff
                var requestPath = operation.GetRequestPath(ResourceType);
                var requestTrimmedPath = requestPath.TrimScope();
                var resourceTrimmedPath = resourceRequestPath.TrimScope();
                // the operations are grouped by the following key
                var key = $"{method}{resourceTrimmedPath.Minus(requestTrimmedPath)}";
                var contextualPath = GetContextualPath(OperationSet, requestPath);
                var methodName = IsListOperation(operation, OperationSet) ?
                    "GetAll" :// hard-code the name of a resource collection operation to "GetAll"
                    GetOperationName(operation, resourceRestClient.OperationGroup.Key);
                // get the MgmtRestOperation with a proper name
                var restClient = MgmtContext.Library.GetRestClient(operation);
                var restOperation = new MgmtRestOperation(
                    MgmtContext.Library.GetRestClientMethod(operation),
                    restClient,
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

            // now the operations should be properly categarized into the dictionary in the key of diff between contextual request path and the operation
            // TODO -- what if the response type is not the same? Also we need to verify they have the same parameters before we could union those together
            _clientOperationMap = result.Where(pair => pair.Value.Count > 0).ToDictionary(
                pair => pair.Key,
                pair => MgmtClientOperation.FromOperations(pair.Value)!); // We first filtered the ones with at least one operation, therefore this will never be null
            return _clientOperationMap;
        }

        /// <summary>
        /// This method returns the contextual path from one resource <see cref="Models.OperationSet"/>
        /// In the <see cref="Resource"/> class, we just use the RequestPath of the OperationSet as its contextual path
        /// Also we need to replace the parameterized scope if there is any with the actual scope value.
        /// </summary>
        /// <param name="operationSet"></param>
        /// <param name="operationRequestPath"></param>
        /// <returns></returns>
        protected virtual RequestPath GetContextualPath(OperationSet operationSet, RequestPath operationRequestPath)
        {
            var contextualPath = operationSet.GetRequestPath();
            // we need to replace the scope in this contextual path with the actual scope in the operation
            var scope = contextualPath.GetScopePath();
            if (!scope.IsParameterizedScope())
                return contextualPath;

            return operationRequestPath.GetScopePath().Append(contextualPath.TrimScope());
        }

        protected bool IsListOperation(Operation operation, OperationSet operationSet)
        {
            return operation.IsResourceCollectionOperation(out var resourceOperationSet) && resourceOperationSet == operationSet;
        }

        protected override IEnumerable<MgmtRestClient> EnsureRestClients()
        {
            var childRestClients = ClientOperations.SelectMany(clientOperation => clientOperation.Select(restOperation => restOperation.RestClient)).Distinct();
            var resourceRestClients = OperationSet.Select(operation => MgmtContext.Library.GetRestClient(operation)).Distinct();

            return resourceRestClients.Concat(childRestClients).Distinct();
        }

        private MgmtRestClient? _myRestClient;
        public MgmtRestClient MyRestClient => _myRestClient ??= RestClients.FirstOrDefault(client => client.Resources.Any(resource => resource.ResourceName == ResourceName)) ?? RestClients.First();

        public ResourceTypeSegment ResourceType { get; }

        protected virtual FormattableString CreateDescription(string clientPrefix)
        {
            var an = clientPrefix.StartsWithVowel() ? "an" : "a";
            List<FormattableString> lines = new List<FormattableString>();
            var parent = ResourceName.Equals("Tenant", StringComparison.Ordinal) ? null : this.Parent().First();

            lines.Add($"A Class representing {an} {ResourceName} along with the instance operations that can be performed on it.");
            lines.Add($"If you have a <see cref=\"{typeof(ResourceIdentifier)}\" /> you can construct {an} <see cref=\"{Type}\" />");
            lines.Add($"from an instance of <see cref=\"{typeof(ArmClient)}\" /> using the Get{DefaultName} method.");
            if (parent is not null)
            {
                var parentType = parent is MgmtExtensions mgmtExtensions ? mgmtExtensions.ArmCoreType : parent.Type;
                lines.Add($"Otherwise you can get one from its parent resource <see cref=\"{parentType}\" /> using the Get{ResourceName} method.");
            }

            return FormattableStringHelpers.Join(lines, "\r\n");
        }

        /// <summary>
        /// Returns the different method signature for different base path of this resource
        /// </summary>
        /// <returns></returns>
        public MethodSignature CreateResourceIdentifierMethodSignature()
        {
            return new MethodSignature(
                    Name: "CreateResourceIdentifier",
                    Description: $"Generate the resource identifier of a <see cref=\"{Type.Name}\"/> instance.",
                    Modifiers: Public | Static,
                    ReturnType: typeof(ResourceIdentifier),
                    ReturnDescription: null,
                    Parameters: RequestPath.Where(segment => segment.IsReference).Select(segment => new Parameter(segment.Reference.Name, null, segment.Reference.Type, null, true)).ToArray());
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

        public Parameter ResourceParameter => new Parameter(Name: "resource", Description: $"The client parameters to use in these operations.",
                            Type: typeof(Azure.ResourceManager.ArmResource), DefaultValue: null, Validate: false);
        public Parameter ResourceDataParameter => new Parameter(Name: "data", Description: $"The resource that is the target of operations.",
                        Type: ResourceData.Type, DefaultValue: null, Validate: false);
    }
}
