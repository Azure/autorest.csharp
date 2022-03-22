﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// MgmtTypeProvider represents the information that corresponds to the generated class in the SDK that contains operations in it.
    /// This includes <see cref="Resource"/>, <see cref="ResourceCollection"/>, <see cref="ArmClientExtensions"/>, <see cref="TenantExtensions"/>,
    /// <see cref="SubscriptionExtensions"/>, <see cref="ResourceGroupExtensions"/> and <see cref="ManagementGroupExtensions"/>
    /// </summary>
    internal abstract class MgmtTypeProvider : TypeProvider
    {
        protected bool IsArmCore { get; }

        protected MgmtTypeProvider(string resourceName) : base(MgmtContext.Context)
        {
            ResourceName = resourceName;
            IsArmCore = Configuration.MgmtConfiguration.IsArmCore;
            IsStatic = !IsArmCore && BaseType is null && (this is MgmtExtensions extension || this is MgmtExtensionsWrapper);
        }

        protected virtual string IdParamDescription => $"The identifier of the resource that is the target of operations.";
        public Parameter ResourceIdentifierParameter => new Parameter(Name: "id", Description: IdParamDescription,
                Type: typeof(ResourceIdentifier), DefaultValue: null, Validate: false);
        public static Parameter ArmClientParameter => new Parameter(Name: "client", Description: $"The client parameters to use in these operations.",
            Type: typeof(ArmClient), DefaultValue: null, Validate: false);

        public string Accessibility => DefaultAccessibility;
        protected override string DefaultAccessibility => "public";

        public virtual bool CanValidateResourceType => true;

        public virtual string BranchIdVariableName => "Id";

        public string Namespace => DefaultNamespace;
        public abstract CSharpType? BaseType { get; }

        private IReadOnlyList<CSharpType>? _enumerableInterfaces;
        public IEnumerable<CSharpType> EnumerableInterfaces => _enumerableInterfaces ??= EnsureGetInterfaces();
        protected virtual IReadOnlyList<CSharpType> EnsureGetInterfaces()
        {
            return Array.Empty<CSharpType>();
        }

        public IEnumerable<CSharpType> GetImplementsList()
        {
            if (BaseType is not null)
                yield return BaseType;

            foreach (var type in EnumerableInterfaces)
            {
                yield return type;
            }
        }
        public bool IsStatic { get; }

        public abstract string Description { get; }

        private HashSet<NameSetKey>? _uniqueSets;
        public HashSet<NameSetKey> UniqueSets => _uniqueSets ??= EnsureUniqueSets();

        public virtual Resource? DefaultResource { get; } = null;

        private IEnumerable<Parameter>? _extraConstructorParameters;
        public IEnumerable<Parameter> ExtraConstructorParameters => _extraConstructorParameters ??= EnsureExtraCtorParameters();
        protected virtual IEnumerable<Parameter> EnsureExtraCtorParameters() => new List<Parameter>();

        protected virtual FieldModifiers FieldModifiers { get; } = FieldModifiers.Private;

        private IEnumerable<FieldDeclaration>? _fields;
        public IEnumerable<FieldDeclaration> Fields => _fields ??= EnsureFieldDeclaration();
        protected virtual IEnumerable<FieldDeclaration> EnsureFieldDeclaration()
        {
            foreach (var set in UniqueSets)
            {
                var nameSet = GetRestDiagNames(set);
                yield return new FieldDeclaration(
                    FieldModifiers,
                    typeof(ClientDiagnostics),
                    nameSet.DiagnosticField);
                yield return new FieldDeclaration(
                    FieldModifiers,
                    set.RestClient.Type,
                    nameSet.RestField);
            }

            var additionalFields = GetAdditionalFields();
            if (additionalFields is null)
                yield break;

            foreach (var field in additionalFields)
            {
                yield return field;
            }
        }
        protected virtual IEnumerable<FieldDeclaration>? GetAdditionalFields() => null;

        private ConstructorSignature? _mockingCtor;
        public ConstructorSignature? MockingCtor => _mockingCtor ??= EnsureMockingCtor();
        protected virtual ConstructorSignature? EnsureMockingCtor()
        {
            return new ConstructorSignature(
                Name: Type.Name,
                Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class for mocking.",
                Modifiers: Protected,
                Parameters: Array.Empty<Parameter>());
        }

        private ConstructorSignature? _armClientCtor;
        public ConstructorSignature? ArmClientCtor => _armClientCtor ??= EnsureArmClientCtor();
        protected virtual ConstructorSignature? EnsureArmClientCtor() => null;
        private ConstructorSignature? _resourceDataCtor;
        public ConstructorSignature? ResourceDataCtor => _resourceDataCtor ??= EnsureResourceDataCtor();
        protected virtual ConstructorSignature? EnsureResourceDataCtor() => null;

        private Dictionary<NameSetKey, NameSet> _nameCache = new Dictionary<NameSetKey, NameSet>();
        public NameSet GetRestDiagNames(NameSetKey set)
        {
            if (_nameCache.TryGetValue(set, out NameSet names))
                return names;

            var resource = set.Resource;
            var client = set.RestClient;
            string? resourceName = resource is not null ? resource.Type.Name : client.Resources.Contains(DefaultResource) ? DefaultResource?.Type.Name : null;

            string uniqueName = GetUniqueName(resourceName, client.OperationGroup.Key);

            string uniqueVariable = uniqueName.ToVariableName();
            var result = new NameSet(
                $"_{uniqueVariable}ClientDiagnostics",
                $"{uniqueName}ClientDiagnostics",
                $"_{uniqueVariable}RestClient",
                $"{uniqueName}RestClient",
                $"{uniqueVariable}ApiVersion");
            _nameCache.Add(set, result);

            return result;
        }

        private string GetUniqueName(string? resourceName, string clientName)
        {
            if (resourceName is not null)
            {
                if (string.IsNullOrEmpty(clientName))
                {
                    return resourceName;
                }
                else
                {
                    var singularClientName = clientName.ToSingular(true);
                    return resourceName.Equals(singularClientName, StringComparison.Ordinal)
                        ? resourceName
                        : $"{resourceName}{clientName}";
                }
            }
            else
            {
                return string.IsNullOrEmpty(clientName) ? "Default" : clientName;
            }
        }

        /// <summary>
        /// This is the display name for this TypeProvider.
        /// If this TypeProvider generates an extension class, this will be the resource name of whatever it extends from.
        /// </summary>
        public string ResourceName { get; }

        private IEnumerable<MgmtClientOperation>? _clientOperations;
        /// <summary>
        /// The collection of operations that will be included in this generated class.
        /// </summary>
        public IEnumerable<MgmtClientOperation> ClientOperations => _clientOperations ??= EnsureClientOperations();
        protected abstract IEnumerable<MgmtClientOperation> EnsureClientOperations();

        private IEnumerable<MgmtClientOperation>? _allOperations;
        public IEnumerable<MgmtClientOperation> AllOperations => _allOperations ??= EnsureAllOperations();
        protected virtual IEnumerable<MgmtClientOperation> EnsureAllOperations() => ClientOperations;

        public virtual ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            throw new InvalidOperationException($"Tried to get a branch resource type from a type provider that doesn't support it {GetType().Name}.");
        }

        private IEnumerable<Resource>? _childResources;
        /// <summary>
        /// The collection of <see cref="Resource"/> that is a child of this generated class.
        /// </summary>
        public virtual IEnumerable<Resource> ChildResources => _childResources ??= MgmtContext.Library.ArmResources.Where(resource => resource.Parent().Contains(this));

        protected string GetOperationName(Operation operation, string clientResourceName)
        {
            // search the configuration for a override of this operation
            if (operation.TryGetConfigOperationName(out var name))
                return name;

            return CalculateOperationName(operation, clientResourceName);
        }

        /// <summary>
        /// If the operationGroup of this operation is the same as the resource operation group, we just use operation.CSharpName()
        /// If it is not, we append the operation group key after operation.CSharpName() to make sure this operation has an unique name.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="clientResourceName">For extension classes, use the ResourceName. For resources, use its operation group name</param>
        /// <returns></returns>
        protected virtual string CalculateOperationName(Operation operation, string clientResourceName)
        {
            // search the configuration for a override of this operation
            if (operation.TryGetConfigOperationName(out var name))
                return name;

            var operationGroup = MgmtContext.Library.GetRestClient(operation).OperationGroup;
            if (operationGroup.Key == clientResourceName)
            {
                return operation.MgmtCSharpName(false);
            }

            var resourceName = string.Empty;
            if (MgmtContext.Library.GetRestClientMethod(operation).IsListMethod(out _))
            {
                resourceName = operationGroup.Key.IsNullOrEmpty() ? string.Empty : operationGroup.Key.ResourceNameToPlural();
                var opName = operation.MgmtCSharpName(!resourceName.IsNullOrEmpty());
                // Remove 'By[Resource]' if the method is put in the [Resource] class. For instance, GetByDatabaseDatabaseColumns now becomes GetDatabaseColumns under Database resource class.
                if (opName.EndsWith($"By{clientResourceName.LastWordToSingular()}"))
                {
                    opName = opName.Substring(0, opName.IndexOf($"By{clientResourceName.LastWordToSingular()}"));
                }
                // For other variants, move By[Resource] to the end. For instance, GetByInstanceServerTrustGroups becomes GetServerTrustGroupsByInstance.
                else if (opName.StartsWith("GetBy") && opName.SplitByCamelCase().ToList()[1] == "By")
                {
                    return $"Get{resourceName}{opName.Substring(opName.IndexOf("By"))}";
                }
                return $"{opName}{resourceName}";
            }
            resourceName = operationGroup.Key.IsNullOrEmpty() ? string.Empty : operationGroup.Key.LastWordToSingular();
            return $"{operation.MgmtCSharpName(!resourceName.IsNullOrEmpty())}{resourceName}";
        }

        private HashSet<NameSetKey> EnsureUniqueSets()
        {
            HashSet<NameSetKey> uniqueSets = new HashSet<NameSetKey>();
            foreach (var operation in AllOperations)
            {
                Resource? resource = operation.Resource;
                if (resource is null && operation.RestClient.Resources.Contains(DefaultResource))
                    resource = DefaultResource;

                NameSetKey key = new NameSetKey(operation.RestClient, resource);
                if (uniqueSets.Contains(key))
                    continue;
                uniqueSets.Add(key);
            }
            return uniqueSets;
        }

        private IEnumerable<MgmtRestClient>? _restClients;
        public IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients();

        protected virtual IEnumerable<MgmtRestClient> EnsureRestClients()
        {
            return ClientOperations.SelectMany(operation => operation.Select(restOperation => restOperation.RestClient)).Distinct();
        }
    }
}
