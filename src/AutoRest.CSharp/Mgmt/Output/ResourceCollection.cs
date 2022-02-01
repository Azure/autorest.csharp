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
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Core;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceCollection : Resource
    {
        private const string _suffixValue = "Collection";

        public ResourceCollection(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> operationSets, Resource resource, BuildContext<MgmtOutputLibrary> context)
            : base(operationSets, resource.ResourceName, resource.ResourceType, resource.ResourceData, context, CollectionPosition)
        {
            Resource = resource;
        }

        public override CSharpType? BaseType => typeof(ArmCollection);
        protected override IReadOnlyList<CSharpType> EnsureGetInterfaces()
        {
            if (GetAllOperation is null || GetAllOperation.MethodParameters.Any(p => p.IsRequired))
                return base.EnsureGetInterfaces();

            return new CSharpType[]
            {
                new CSharpType(typeof(IEnumerable<>), Resource.Type),
                new CSharpType(typeof(IAsyncEnumerable<>), Resource.Type)
            };
        }
        public Resource Resource { get; }

        public override Resource GetResource() => Resource;

        public override bool CanValidateResourceType => ResourceTypes.SelectMany(p => p.Value).Distinct().Count() == 1;

        public override string BranchIdVariableName => "Id";

        private MgmtClientOperation? _getAllOperation;
        public MgmtClientOperation? GetAllOperation => _getAllOperation ??= EnsureGetAllOperation();

        private Dictionary<Parameter, FormattableString> _extraConstructorParameters = new();
        private List<ContextualParameterMapping> _extraContextualParameterMapping = new();
        public IEnumerable<ContextualParameterMapping> ExtraContextualParameterMapping => _extraContextualParameterMapping;

        protected override IEnumerable<Parameter> EnsureExtraCtorParameters()
        {
            _ = GetAllOperation;
            return _extraConstructorParameters.Keys;
        }

        protected override ConstructorSignature? EnsureArmClientCtor()
        {
            return new ConstructorSignature(
              Name: Type.Name,
              Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class.",
              Modifiers: "internal",
              Parameters: _armClientCtorParameters.Concat(ExtraConstructorParameters).ToArray(),
              Initializer: new(
                  isBase: true,
                  arguments: _armClientCtorParameters));
        }
        protected override ConstructorSignature? EnsureResourceDataCtor() => null;

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

            // skip the following transformations for `ById` resources.
            // In ById resources, the required parameters of the GetAll operation is usually a scope, doing the following transform will require the constructor to accept a scope variable
            // which is not reasonable and causes problems
            if (IsById)
            {
                return ReferenceSegments(getAllOperation).Any() ? null : getAllOperation;
            }

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
            var requestPath = operation.GetHttpPath();
            if (Context.Configuration.MgmtConfiguration.OperationPositions.TryGetValue(requestPath, out var positions))
            {
                return positions.Contains(Position);
            }
            // if the position of this operation is not set in the configuration, we just include those are excluded in the resource class
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

        protected override IEnumerable<MgmtClientOperation> EnsureAllOperations()
        {
            var result = new List<MgmtClientOperation>();
            if (CreateOperation != null)
                result.Add(CreateOperation);
            if (GetOperation != null)
                result.Add(GetOperation);
            result.AddRange(ClientOperations);
            if (GetOperation != null)
            {
                var getMgmtRestOperation = GetOperation.OperationMappings.Values.First();
                result.Add(MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        getMgmtRestOperation,
                        "Exists",
                        typeof(bool),
                        $"Checks to see if the resource exists in azure.",
                        _context),
                    _context));
                result.Add(MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        getMgmtRestOperation,
                        "GetIfExists",
                        getMgmtRestOperation.MgmtReturnType,
                        $"Tries to get details for this resource from the service.",
                        _context),
                    _context));
            }

            return result;
        }

        public override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            return branch.GetResourceType(_context.Configuration.MgmtConfiguration);
        }

        protected override IEnumerable<FieldDeclaration> GetAdditionalFields()
        {
            foreach (var reference in ExtraConstructorParameters)
            {
                yield return new FieldDeclaration(FieldModifiers, reference.Type, GetFieldName(reference).ToString());
            }
        }

        private IDictionary<RequestPath, ISet<ResourceTypeSegment>>? _resourceTypes;
        public IDictionary<RequestPath, ISet<ResourceTypeSegment>> ResourceTypes => _resourceTypes ??= EnsureResourceTypes();

        private IDictionary<RequestPath, ISet<ResourceTypeSegment>> EnsureResourceTypes()
        {
            var result = new Dictionary<RequestPath, ISet<ResourceTypeSegment>>();
            foreach (var operation in AllOperations.SelectMany(o => o))
            {
                var resourceTypes = GetResourceTypes(operation.RequestPath, operation.ContextualPath);
                if (result.TryGetValue(operation.ContextualPath, out var set))
                {
                    set.UnionWith(resourceTypes);
                }
                else
                {
                    set = new HashSet<ResourceTypeSegment>();
                    set.UnionWith(resourceTypes);
                    result.Add(operation.ContextualPath, set);
                }
            }
            return result;
        }

        private IEnumerable<ResourceTypeSegment> GetResourceTypes(RequestPath requestPath, RequestPath contextualPath)
        {
            var type = contextualPath.GetResourceType(_context.Configuration.MgmtConfiguration);
            if (type == ResourceTypeSegment.Scope)
                return requestPath.GetParameterizedScopeResourceTypes(_context.Configuration.MgmtConfiguration)!;

            return type.AsIEnumerable();
        }

        public Parameter ParentParameter => ResourceParameter with
        {
            Name = "parent",
            Description = $"The resource representing the parent resource."
        };

        protected override string IdParamDescription => $"The identifier of the parent resource that is the target of operations.";
    }
}
