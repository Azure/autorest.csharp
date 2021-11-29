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
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

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

        private Dictionary<Parameter, FormattableString> _extraConstructorParameters = new();
        public IEnumerable<Parameter> ExtraConstructorParameters => _extraConstructorParameters.Keys;

        private List<ContextualParameterMapping> _extraContextualParameterMapping = new();
        public IEnumerable<ContextualParameterMapping> ExtraContextualParameterMapping => _extraContextualParameterMapping;

        private MgmtClientOperation? EnsureGetAllOperation()
        {
            // if this resource was listed in list-exception section, we suppress the exception here
            // or if the debug flag `--mgmt-debug.suppress-list-exception` is on, we suppress the exception here
            var suppressListException = RequestPaths.Any(path => _context.Configuration.MgmtConfiguration.ListException.Contains(path))
                || _context.Configuration.MgmtConfiguration.MgmtDebug.SuppressListException;
            var getAllOperation = ClientOperations.Where(operation => operation.Name == "GetAll").OrderBy(operation => ReferenceSegments(operation).Count()).FirstOrDefault();
            if (!suppressListException && getAllOperation == null)
                throw new ErrorHelpers.ErrorException($"The ResourceCollection {Type.Name} (RequestPaths: {string.Join(", ", RequestPaths)}) does not have a `GetAll` method");

            if (getAllOperation == null)
                return getAllOperation;

            // calculate the ResourceType from the RequestPath of this resource
            var resourceType = RequestPaths.GetResourceType(_context);
            var resourceTypeSegments = resourceType.Select((segment, index) => (segment, index)).Where(tuple => tuple.segment.IsReference).ToList();
            // iterate over all the reference segments in the diff of this GetAll operation
            var candidatesOfParameters = new List<Parameter>(getAllOperation.Parameters);
            foreach (var segment in ReferenceSegments(getAllOperation))
            {
                var index = resourceTypeSegments.FindIndex(tuple => tuple.segment == segment);
                if (index < 0)
                {
                    var parameter = candidatesOfParameters.First(p => p.Name == segment.ReferenceName && p.Type.Equals(segment.Type));
                    candidatesOfParameters.Remove(parameter);
                    // this reference is not in the resource type, therefore this parameter goes to the constructor
                    _extraConstructorParameters.Add(parameter, $"_{segment.ReferenceName}");
                    // there is a key for this parameter, get the key and add this one to contextual parameter mapping
                    var key = ParameterMappingBuilder.FindKeyOfParameter(parameter, getAllOperation.First().RequestPath);
                    _extraContextualParameterMapping.Add(new ContextualParameterMapping(key, segment, GetFieldName(parameter)));
                }
                else
                {
                    var candidate = resourceTypeSegments[index];
                    var value = ResourceType[candidate.index];
                    _extraContextualParameterMapping.Add(new ContextualParameterMapping("", segment, $"\"{value.ConstantValue}\""));
                }
            }

            return getAllOperation;
        }

        public FormattableString GetFieldName(Parameter parameter)
        {
            return _extraConstructorParameters[parameter];
        }

        private static IEnumerable<Segment> ReferenceSegments(MgmtClientOperation clientOperation)
        {
            var operation = clientOperation.First();
            RequestPath diff;
            if (operation.RequestPath.IsAncestorOf(operation.ContextualPath))
                diff = operation.RequestPath.TrimAncestorFrom(operation.ContextualPath);
            else
                diff = operation.ContextualPath.TrimAncestorFrom(operation.RequestPath);
            return diff.Where(segment => segment.IsReference);
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
