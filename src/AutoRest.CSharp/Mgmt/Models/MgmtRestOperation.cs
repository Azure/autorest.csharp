// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

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
        public string? Description => Method.Description;
        public IEnumerable<Parameter> Parameters => Method.Parameters;
        private CSharpType? _returnType;
        public CSharpType? ReturnType => _returnType ??= GetMgmtReturnType(Method.ReturnType) ?? Resource?.Type;
        public string Accessibility => Method.Accessibility;
        public bool IsPagingOperation => Operation.Language.Default.Paging != null;

        private bool _checkedListItemType;
        private CSharpType? _listItemType;
        private CSharpType? ListItemType => _checkedListItemType ? _listItemType : GetListMethodItemType();

        public bool IsListOperation => ListItemType != null;
        public CSharpType? OriginalReturnType => Method.ReturnType;

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

        public bool IsLongRunningOperation()
        {
            return _isLongRunning.HasValue ? _isLongRunning.Value : Operation.IsLongRunning;
        }


        public MgmtRestOperation(RestClientMethod method, MgmtRestClient restClient, RequestPath requestPath, RequestPath contextualPath, string methodName, CSharpType? returnType, BuildContext<MgmtOutputLibrary> context, bool? isLongRunning = null, bool throwIfNull = false)
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
            _returnType = returnType;
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
            if (parent is not null && AllMatchesSameParent(matchTypeMatches, _context, parent, out bool areAllSingleton) && areAllSingleton)
                return parent as Resource;

            //this throw catches anything we do not expect if it ever fires it means our logic is either incomplete or we need a directive to adjust the request paths
            throw new InvalidOperationException($"Found more than 1 candidate for {error}, results were ({string.Join(',', matchTypeMatches.Select(r => r.Type.Name))})");
        }

        private static bool AllMatchesSameParent(HashSet<Resource> matches, BuildContext<MgmtOutputLibrary> context, MgmtTypeProvider parent, out bool areAllSingleton)
        {
            areAllSingleton = true;
            foreach (var resource in matches)
            {
                areAllSingleton &= resource.IsSingleton;
                var current = resource.Parent(context).FirstOrDefault();
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

        private CSharpType? GetMgmtReturnType(CSharpType? originalType)
        {
            if (IsPagingOperation)
            {
                originalType = GetPagingMethod()!.PagingResponse.ItemType;
            }

            //try for list method
            originalType = GetListMethodItemType() ?? originalType;

            if (!IsResourceDataType(originalType, out var data))
                return originalType;

            if (_context.Configuration.MgmtConfiguration.IsArmCore)
            {
                // we need to find the correct resource type that links with this resource data
                var candidates = _context.Library.FindResources(data);

                // return null when there is no match
                if (!candidates.Any())
                    return originalType;

                // when we only find one result, just return it.
                if (candidates.Count() == 1)
                    return candidates.Single().Type;

                // if there is more candidates than one, we are going to some more matching to see if we could determine one
                var resourceType = RequestPath.GetResourceType(_context.Configuration.MgmtConfiguration);
                var filteredResources = candidates.Where(r => r.ResourceType == resourceType);

                if (filteredResources.Count() == 1)
                    return filteredResources.Single().Type;
            }
            if (Resource is null)
                throw new InvalidOperationException($"Found a resource data return type but resource was null. {originalType?.Name}");
            return Resource.Type;
        }

        public PagingMethod? GetPagingMethod()
        {
            if (_context.Library.PagingMethods.TryGetValue(Method, out var pagingMethod))
                return pagingMethod;

            return null;
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
                data = Resource?.ResourceData;
                return data != null && data.Type.Equals(type);
            }
        }

        private CSharpType? GetListMethodItemType()
        {
            if (_checkedListItemType)
                return _listItemType;

            CSharpType? itemType = null;
            var returnType = Method.ReturnType;
            if (returnType == null)
            {
                _checkedListItemType = true;
                return itemType;
            }

            var restClientMethod = _context.Library.GetRestClientMethod(Operation);
            _checkedListItemType = true;
            return restClientMethod.IsListMethod(out _listItemType) ? _listItemType : null;
        }
    }
}
