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
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceCollection : Resource
    {
        private const string _suffixValue = "Collection";

        public ResourceCollection(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> operationSets, Resource resource, BuildContext<MgmtOutputLibrary> context)
            : base(operationSets, resource.ResourceName, resource.ResourceType, context)
        {
            Resource = resource;
            GetAllOperation = EnsureGetAllOperation();
        }

        public Resource Resource { get; }

        public MgmtClientOperation? GetAllOperation { get; }

        private MgmtClientOperation? EnsureGetAllOperation()
        {
            // if this resource was listed in list-exception section, we suppress the exception here
            // or if the debug flag `--mgmt-debug.suppress-list-exception` is on, we suppress the exception here
            var suppressListException = RequestPaths.Any(path => _context.Configuration.MgmtConfiguration.ListException.Contains(path))
                || _context.Configuration.MgmtConfiguration.MgmtDebug.SuppressListException;
            var candidates = ClientOperations.Where(operation => operation.Name == "GetAll" && !HasExtraParameter(operation));
            // we need to filter out the methods that does not have extra mandatory parameters in our current context
            if (!suppressListException && candidates.Count() > 1)
                throw new ErrorHelpers.ErrorException($"The ResourceCollection {Type.Name} (RequestPaths: {string.Join(", ", RequestPaths)}) contains more than one `GetAll` method with no required parameters.");
            if (!suppressListException && !candidates.Any())
                throw new ErrorHelpers.ErrorException($"The ResourceCollection {Type.Name} (RequestPaths: {string.Join(", ", RequestPaths)}) does not have a `GetAll` method with no required parameters");
            return candidates.FirstOrDefault();
        }

        private static bool HasExtraParameter(MgmtClientOperation clientOperation)
        {
            foreach (var operation in clientOperation)
            {
                RequestPath diff;
                if (operation.RequestPath.IsAncestorOf(operation.ContextualPath))
                    diff = operation.RequestPath.TrimAncestorFrom(operation.ContextualPath);
                else
                    diff = operation.ContextualPath.TrimAncestorFrom(operation.RequestPath);
                if (!diff.All(segment => segment.IsConstant))
                    return true;
                foreach (var parameter in operation.Parameters)
                {
                    if (!parameter.IsInPathOf(operation.Method) && parameter.IsMandatory())
                        return true;
                }
            }
            return false;
        }

        protected override bool ShouldIncludeOperation(Operation operation)
        {
            return !base.ShouldIncludeOperation(operation);
        }

        /// <summary>
        /// This method returns the contextual path from one resource <see cref="OperationSet"/>
        /// In the <see cref="ResourceCollection"/> class, we need to use the parent RequestPath of the OperationSet as its contextual path
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
            //    result.Add(DeleteOperation); // comment this back if we decide to include delete method in collections
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
