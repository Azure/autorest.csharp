// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceContainer : Resource
    {
        private const string _suffixValue = "Container";

        public ResourceContainer(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> operationSets, string resourceName, BuildContext<MgmtOutputLibrary> context)
            : base(operationSets, resourceName, ResourceType.Any, context) // The container might include multiple resource types, therefore we do not need the ResourceType property in Resource base class
        {
        }

        public Resource Resource => _context.Library.GetArmResource(RequestPaths.First());

        public override string ResourceName => Resource.ResourceName;

        protected override bool ShouldIncludeOperation(Operation operation)
        {
            return !base.ShouldIncludeOperation(operation);
        }

        /// <summary>
        /// This method returns the contextual path from one resource <see cref="OperationSet"/>
        /// In the <see cref="ResourceContainer"/> class, we need to use the parent RequestPath of the OperationSet as its contextual path
        /// </summary>
        /// <param name="operationSet"></param>
        /// <param name="operationRequestPath"></param>
        /// <returns></returns>
        protected override RequestPath GetContextualPath(OperationSet operationSet, RequestPath operationRequestPath)
        {
            var contextualPath = operationSet.ParentRequestPath(_context);
            // we need to replace the scope in this contextual path with the actual scope in the operation
            var scope = contextualPath.GetScopePath();
            if (!scope.IsParameterizedScope())
                return contextualPath;

            return operationRequestPath.GetScopePath().Append(contextualPath.TrimScope());
        }

        protected override string DefaultName => Resource.Type.Name + _suffixValue;

        protected override string CreateDescription(string clientPrefix)
        {
            return $"A class representing collection of {clientPrefix} and their operations over its parent.";
        }

        /// <summary>
        /// The resource container might support multiple resource types, therefore we should never use this property in <see cref="ResourceContainer"/>
        /// </summary>
        public override ResourceType ResourceType => throw new InvalidOperationException($"We should not use the property `ResourceType` in ResourceContainer. This is a bug in autorest.csharp, please file an issue about this");

        private IEnumerable<MgmtClientOperation>? _allOperations;
        public override IEnumerable<MgmtClientOperation> AllOperations => _allOperations ??= EnsureAllOperations();

        private IEnumerable<MgmtClientOperation> EnsureAllOperations()
        {
            var result = new List<MgmtClientOperation>();
            if (CreateOperation != null)
                result.Add(CreateOperation);
            if (GetOperation != null)
                result.Add(GetOperation);
            //if (DeleteOperation != null)
            //    result.Add(DeleteOperation); // comment this back if we decide to include delete method in containers
            result.AddRange(ClientOperations);

            return result;
        }

        private IDictionary<RequestPath, ISet<ResourceType>>? _resourceTypes;
        public IDictionary<RequestPath, ISet<ResourceType>> ResourceTypes => _resourceTypes ??= EnsureResourceTypes();

        private IDictionary<RequestPath, ISet<ResourceType>> EnsureResourceTypes()
        {
            var result = new Dictionary<RequestPath, ISet<ResourceType>>();
            foreach (var operation in AllOperations.SelectMany(o => o))
            {
                var resourceTypes = GetResourceTypes(operation.RequestPath, operation.ContextualPath);
                if (result.TryGetValue(operation.ContextualPath, out var set))
                {
                    set.UnionWith(resourceTypes);
                }
                else
                {
                    set = new HashSet<ResourceType>();
                    set.UnionWith(resourceTypes);
                    result.Add(operation.ContextualPath, set);
                }
            }
            return result;
        }

        private IEnumerable<ResourceType> GetResourceTypes(RequestPath requestPath, RequestPath contextualPath)
        {
            var type = contextualPath.GetResourceType(_context.Configuration.MgmtConfiguration);
            if (type == ResourceType.Scope)
                return requestPath.GetParameterizedScopeResourceTypes(_context.Configuration.MgmtConfiguration)!;

            return type.AsIEnumerable();
        }
    }
}
