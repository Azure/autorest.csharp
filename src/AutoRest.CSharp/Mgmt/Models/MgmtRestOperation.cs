// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Operation = AutoRest.CSharp.Input.Operation;

namespace AutoRest.CSharp.Mgmt.Models
{
    /// <summary>
    /// A <see cref="MgmtRestOperation"/> includes some invocation information of a <see cref="RestClientMethod"/>
    /// We have the <see cref="RestClientMethod"/> that will be invoked, also we have the "Contextual Path" of this method,
    /// which records the context of this method invocation,
    /// providing you the information that which part of the `Id` we should pass to the parameter of <see cref="RestClientMethod"/>
    /// </summary>
    internal record MgmtRestOperation
    {
        private bool? _isLongRunning;
        private BuildContext<MgmtOutputLibrary> _context;

        /// <summary>
        /// The underlying <see cref="Operation"/> object.
        /// </summary>
        public Operation Operation => Method.Operation;
        /// <summary>
        /// We use the <see cref="OperationGroup"/> to get a fully quanlified name for this operation
        /// </summary>
        public OperationGroup OperationGroup => RestClient.OperationGroup;
        public string OperationId => Operation.OperationId(OperationGroup);
        /// <summary>
        /// The name of this operation
        /// </summary>
        public string Name { get; }

        private string? _description;
        public string? Description => _description ??= Method.Description;
        public IEnumerable<Parameter> Parameters => Method.Parameters;

        public OperationSource? OperationSource { get; }

        private Func<bool, FormattableString>? _returnsDescription;
        public Func<bool, FormattableString>? ReturnsDescription => IsPagingOperation ? _returnsDescription ??= EnsureReturnsDescription() : null;

        private PagingMethodWrapper? _pagingMethodWrapper;
        public PagingMethodWrapper? PagingMethod => _pagingMethodWrapper ??= EnsurePagingMethodWrapper();

        private CSharpType? _mgmtReturnType;
        public CSharpType? MgmtReturnType => _mgmtReturnType ??= GetMgmtReturnType(OriginalReturnType);

        public CSharpType? ListItemType => IsPagingOperation ? MgmtReturnType : null;

        private CSharpType? _wrappedMgmtReturnType;
        public CSharpType ReturnType => _wrappedMgmtReturnType ??= GetWrappedMgmtReturnType(MgmtReturnType);

        public string Accessibility => Method.Accessibility;
        public bool IsPagingOperation => Operation.Language.Default.Paging != null || IsListOperation;

        private bool? _isListOperation;
        private bool IsListOperation => _isListOperation ??= _context.Library.GetRestClientMethod(Operation).IsListMethod(out var _);
        public CSharpType? OriginalReturnType { get; }

        /// <summary>
        /// The actual operation
        /// </summary>
        public RestClientMethod Method { get; }
        /// <summary>
        /// The request path of this operation
        /// </summary>
        public RequestPath RequestPath { get; }
        /// <summary>
        /// The contextual path of this operation
        /// </summary>
        public RequestPath ContextualPath { get; }
        /// <summary>
        /// From which RestClient is this operation invoked
        /// </summary>
        public MgmtRestClient RestClient { get; }

        public Resource? Resource { get; }

        public bool ThrowIfNull { get; }

        public bool IsLongRunningOperation => _isLongRunning.HasValue ? _isLongRunning.Value : Operation.IsLongRunning;

        public bool IsFakeLro => IsLongRunningOperation && !Operation.IsLongRunning;

        public Parameter[] OverrideParameters { get; } = new Parameter[] { };

        public OperationFinalStateVia? FinalStateVia { get; }

        public Schema? FinalResponseSchema => Method.Operation.IsLongRunning ? Method.Operation.LongRunningFinalResponse.ResponseSchema : null;

        public MgmtRestOperation(RestClientMethod method, MgmtRestClient restClient, RequestPath requestPath, RequestPath contextualPath, string methodName, BuildContext<MgmtOutputLibrary> context, bool? isLongRunning = null, bool throwIfNull = false)
        {
            _context = context;
            _isLongRunning = isLongRunning;
            ThrowIfNull = throwIfNull;
            Method = method;
            RestClient = restClient;
            RequestPath = requestPath;
            ContextualPath = contextualPath;
            Name = methodName;
            Resource = GetResourceMatch(restClient, method, requestPath);
            FinalStateVia = Method.Operation.IsLongRunning? Method.Operation.LongRunningFinalStateVia : null;
            OriginalReturnType = Method.Operation.IsLongRunning ? GetFinalResponse() : Method.ReturnType;
            OperationSource = GetOperationSource();
        }

        public MgmtRestOperation(MgmtRestOperation other, string nameOverride, CSharpType? overrideReturnType, string overrideDescription, BuildContext<MgmtOutputLibrary> context, params Parameter[] overrideParameters)
        {
            //copy values from other method
            _context = context;
            _isLongRunning = other.IsLongRunningOperation;
            ThrowIfNull = other.ThrowIfNull;
            Method = other.Method;
            RestClient = other.RestClient;
            RequestPath = other.RequestPath;
            ContextualPath = other.ContextualPath;
            Resource = other.Resource;
            FinalStateVia = other.FinalStateVia;
            OriginalReturnType = other.OriginalReturnType;
            OperationSource = other.OperationSource;

            //modify some of the values
            Name = nameOverride;
            _mgmtReturnType = overrideReturnType;
            _description = overrideDescription;
            OverrideParameters = overrideParameters;
        }

        private OperationSource? GetOperationSource()
        {
            if (!IsLongRunningOperation)
                return null;

            if (MgmtReturnType is null)
                return null;

            if (!_context.Library.CSharpTypeToOperationSource.TryGetValue(MgmtReturnType, out var operationSource))
            {
                operationSource = new OperationSource(MgmtReturnType, Resource, FinalResponseSchema!);
                _context.Library.CSharpTypeToOperationSource.Add(MgmtReturnType, operationSource);
            }
            return operationSource;
        }

        private CSharpType? GetFinalResponse()
        {
            var finalSchema = Method.Operation.LongRunningFinalResponse.ResponseSchema;
            if (finalSchema is null)
                return null;

            try
            {
                return finalSchema.Type == AllSchemaTypes.Object ? _context.Library.FindTypeForSchema(finalSchema) : new TypeFactory(_context.Library).CreateType(finalSchema, false);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Final response for {RestClient.OperationGroup.Key}.{Method.Name} was not found it was of type {finalSchema.Name}", ex);
            }
        }

        internal enum ResourceMatchType
        {
            Exact,
            ParentList,
            AncestorList,
            ChildList,
            Context,
            CheckName,
            None
        }

        private Resource? GetResourceMatch(MgmtRestClient restClient, RestClientMethod method, RequestPath requestPath)
        {
            if (restClient.Resources.Count == 1)
                return restClient.Resources[0];

            Dictionary<ResourceMatchType, HashSet<Resource>> matches = new Dictionary<ResourceMatchType, HashSet<Resource>>();
            foreach (var resource in restClient.Resources)
            {
                foreach (var resourcePath in resource.RequestPaths)
                {
                    var match = GetMatchType(method.Operation.GetHttpMethod(), resourcePath, requestPath, method.IsListMethod(out var _));
                    if (match == ResourceMatchType.Exact)
                        return resource;
                    if (match != ResourceMatchType.None)
                    {
                        if (!matches.TryGetValue(match, out var result))
                        {
                            result = new HashSet<Resource>();
                            matches.Add(match, result);
                        }
                        result.Add(resource);
                    }
                }
            }

            FormattableString errorText = (FormattableString)$"{restClient.Type.Name}.{method.Name}";
            foreach (ResourceMatchType? matchType in Enum.GetValues(typeof(ResourceMatchType)))
            {
                var resource = GetMatch(matchType!.Value, matches, errorText);

                if (resource is not null)
                    return resource;
            }
            return null;
        }

        private Resource? GetMatch(ResourceMatchType matchType, Dictionary<ResourceMatchType, HashSet<Resource>> matches, FormattableString error)
        {
            if (!matches.TryGetValue(matchType, out var matchTypeMatches))
                return null;

            var first = matchTypeMatches.First();
            if (matchTypeMatches.Count == 1)
                return first;

            var parent = first.Parent(_context).First();
            if (parent is not null && AllMatchesSameParent(matchTypeMatches, parent, out bool areAllSingleton) && areAllSingleton)
                return parent as Resource;

            //this throw catches anything we do not expect if it ever fires it means our logic is either incomplete or we need a directive to adjust the request paths
            throw new InvalidOperationException($"Found more than 1 candidate for {error}, results were ({string.Join(',', matchTypeMatches.Select(r => r.Type.Name))})");
        }

        private bool AllMatchesSameParent(HashSet<Resource> matches, MgmtTypeProvider parent, out bool areAllSingleton)
        {
            areAllSingleton = true;
            foreach (var resource in matches)
            {
                areAllSingleton &= resource.IsSingleton;
                var current = resource.Parent(_context).FirstOrDefault();
                if (current is null)
                    return false;
                if (!current.Equals(parent))
                    return false;
            }
            return true;
        }

        internal static ResourceMatchType GetMatchType(HttpMethod httpMethod, RequestPath resourcePath, RequestPath requestPath, bool isList)
        {
            //check exact match
            if (resourcePath == requestPath)
                return ResourceMatchType.Exact;

            //check for a list by an ancestor
            var requestLastSegment = requestPath[requestPath.Count - 1];
            if (isList &&
                httpMethod == HttpMethod.Get &&
                requestPath.Count < resourcePath.Count &&
                requestLastSegment.IsConstant &&
                resourcePath[0] == requestPath[0] && //first two items much be the same
                resourcePath[1] == requestPath[1] &&
                AreEqualBackToProvider(resourcePath, requestPath, 1, 0))
            {
                return AreEqualUpToProvider(resourcePath, requestPath) ? ResourceMatchType.ParentList : ResourceMatchType.AncestorList;
            }

            //check for single value methods after the GET path which are typically POST methods
            if (resourcePath.Count == requestPath.Count - 1 && requestLastSegment.IsConstant && AreEqualBackToProvider(resourcePath, requestPath, 0, 1))
                return isList ? ResourceMatchType.ChildList : ResourceMatchType.Context;

            if (httpMethod == HttpMethod.Get)
                return ResourceMatchType.None;

            var resourceLastSegement = resourcePath[resourcePath.Count - 1];
            //sometimes for singletons the POST methods show up at the same level
            if (resourcePath.Count == requestPath.Count && requestLastSegment.IsConstant && resourceLastSegement.IsConstant && AreEqualBackToProvider(resourcePath, requestPath, 1, 1))
                return ResourceMatchType.Context;

            //catch check name availability where the provider ending matches
            //this one catches a lot so we are narrowing it down to containing "name" dont know all the checknameavailability name types
            if (requestLastSegment.IsConstant &&
                requestPath.ToString()!.StartsWith("/subscriptions/{{subscriptionId}}", StringComparison.Ordinal) &&
                requestLastSegment.ToString()!.Contains("name", StringComparison.OrdinalIgnoreCase) &&
                AreEqualBackToProvider(resourcePath, requestPath, 2, 1))
                return ResourceMatchType.CheckName;

            return ResourceMatchType.None;
        }

        private static bool AreEqualBackToProvider(RequestPath resourcePath, RequestPath requestPath, int resourceSkips, int requestSkips)
        {
            int resourceStart = resourcePath.Count - 1 - resourceSkips;
            int requestStart = requestPath.Count - 1 - requestSkips;
            //resourcePath will have an extra reference segment for the resource name.  Skip this and walk back to the providers or beginning of array and everything must match to that point
            for (int resourceIndex = resourceStart, requestIndex = requestStart; resourceIndex >= 0 && requestIndex >= 0; resourceIndex--, requestIndex--)
            {
                if (resourcePath[resourceIndex].IsReference && resourcePath[resourceIndex].Equals(requestPath[requestIndex], false))
                    continue; //there are sometimes name differences in the path variable used but the rest of the context is the same

                if (resourcePath[resourceIndex] != requestPath[requestIndex])
                    return false;

                if (resourcePath[resourceIndex] == Segment.Providers)
                    return true;
            }
            return true;
        }

        private static bool AreEqualUpToProvider(RequestPath resourcePath, RequestPath requestPath)
        {
            for (int i = 0; i < Math.Min(resourcePath.Count, requestPath.Count); i++)
            {
                if (resourcePath[i] == Segment.Providers)
                    return true;

                if (resourcePath[i] != requestPath[i])
                    return false;
            }
            return true;
        }

        private CSharpType GetWrappedMgmtReturnType(CSharpType? originalType)
        {
            if (originalType is null)
                return IsLongRunningOperation ? typeof(ArmOperation) : typeof(Response);

            if (IsPagingOperation)
                return originalType;

            return IsLongRunningOperation ? originalType.WrapOperation(false) : originalType.WrapResponse(false);
        }

        private CSharpType? GetMgmtReturnType(CSharpType? originalType)
        {
            _context.Library.PagingMethods.TryGetValue(Method, out var pagingMethod);

            if (pagingMethod is not null)
            {
                originalType = pagingMethod.PagingResponse.ItemType;
            }

            //try for list method
            originalType = GetListMethodItemType() ?? originalType;

            if (!IsResourceDataType(originalType, out var data))
                return originalType;

            if (Resource is not null && Resource.ResourceData.Type.Equals(originalType))
                return Resource.Type;

            var foundResource = _context.Library.ArmResources.FirstOrDefault(resource => resource.ResourceData.Type.Equals(originalType));
            if (foundResource is not null)
                return foundResource.Type;

            throw new InvalidOperationException($"Found a resource data return type but resource was null for method {RestClient.Type.Name}.{Method.Name}: {originalType?.Name}");
        }

        private bool IsResourceDataType(CSharpType? type, [MaybeNullWhen(false)] out ResourceData data)
        {
            data = null;
            if (_context.Configuration.MgmtConfiguration.IsArmCore)
            {
                if (type == null || type.IsFrameworkType)
                    return false;

                if (_context.Library.TryGetTypeProvider(type.Name, out var provider))
                {
                    data = provider as ResourceData;
                    return data != null;
                }
                return false;
            }
            else
            {
                data = _context.Library.ResourceData.FirstOrDefault(d => d.Type.Equals(type));
                return data != null;
            }
        }

        private CSharpType? GetListMethodItemType()
        {
            if (Method.ReturnType is null)
                return null;

            var restClientMethod = _context.Library.GetRestClientMethod(Operation);
            return restClientMethod.IsListMethod(out var item) ? item : null;
        }

        private PagingMethodWrapper EnsurePagingMethodWrapper()
        {
            _context.Library.PagingMethods.TryGetValue(Method, out var pagingMethod);
            return pagingMethod is null ? new PagingMethodWrapper(Method) : new PagingMethodWrapper(pagingMethod);
        }

        private Func<bool, FormattableString> EnsureReturnsDescription()
            => (isAsync) => $"{(isAsync ? "An async" : "A")} collection of <see cref=\"{ListItemType!}\" /> that may take multiple service requests to iterate over.";
    }
}
