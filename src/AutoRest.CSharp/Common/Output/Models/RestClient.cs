﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Output.Models
{
    internal class RestClient : TypeProvider
    {
        private CachedDictionary<ServiceRequest, RestClientMethod> _requestMethods;
        private CachedDictionary<ServiceRequest, RestClientMethod> _nextPageMethods;
        private RestClientMethod[]? _allMethods;

        public RestClient(OperationGroup operationGroup, BuildContext context, string? clientName) : base(context)
        {
            OperationGroup = operationGroup;
            Builder = new RestClientBuilder(operationGroup, context);

            _requestMethods = new CachedDictionary<ServiceRequest, RestClientMethod>(EnsureNormalMethods);
            _nextPageMethods = new CachedDictionary<ServiceRequest, RestClientMethod>(EnsureGetNextPageMethods);

            Parameters = Builder.GetOrderedParameters();

            ClientPrefix = ClientBuilder.GetClientPrefix(clientName ?? operationGroup.Language.Default.Name, context);
            RestClientSuffix = "Rest" + ClientBuilder.GetClientSuffix(context);
            DefaultName = ClientPrefix + RestClientSuffix;
            Description = "";
        }

        protected RestClientBuilder Builder;
        internal OperationGroup OperationGroup { get; }
        protected string RestClientSuffix { get; }
        public Parameter[] Parameters { get; }
        public string Description { get; }
        public RestClientMethod[] Methods => _allMethods ??= BuildAllMethods().ToArray();
        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; } = "internal";

        private IEnumerable<RestClientMethod> BuildAllMethods()
        {
            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = GetOperationMethod(serviceRequest);
                    yield return method;
                }
            }

            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // remove duplicates when GetNextPage method is not autogenerated
                    if (GetNextOperationMethod(serviceRequest) is { } nextOperationMethod &&
                        operation.Language.Default.Paging?.NextLinkOperation == null)
                    {
                        yield return nextOperationMethod;
                    }
                }
            }
        }

        protected virtual Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // See also LowLevelRestClient::EnsureNormalMethods if changing
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }
                    requestMethods.Add(serviceRequest, Builder.BuildMethod(operation, httpRequest, serviceRequest.Parameters, null, "public", ShouldReturnNullOn404(operation)));
                }
            }

            return requestMethods;
        }

        protected virtual Func<string?, bool> ShouldReturnNullOn404(Operation operation)
        {
            return (responseBodyType) => false;
        }

        protected Dictionary<ServiceRequest, RestClientMethod> EnsureGetNextPageMethods()
        {
            var nextPageMethods = new Dictionary<ServiceRequest, RestClientMethod>();
            foreach (var operation in OperationGroup.Operations)
            {
                var paging = operation.Language.Default.Paging;
                if (paging == null)
                {
                    continue;
                }
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod? nextMethod = null;
                    if (paging.NextLinkOperation != null)
                    {
                        nextMethod = GetOperationMethod(paging.NextLinkOperation.Requests.Single());
                    }
                    else if (paging.NextLinkName != null)
                    {
                        var method = GetOperationMethod(serviceRequest);
                        nextMethod = BuildNextPageMethod(method, operation);
                    }

                    if (nextMethod != null)
                    {
                        nextPageMethods.Add(serviceRequest, nextMethod);
                    }
                }
            }

            return nextPageMethods;
        }

        protected static RestClientMethod BuildNextPageMethod(RestClientMethod method, Operation operation)
        {
            var nextPageUrlParameter = new Parameter(
                "nextLink",
                "The URL to the next page of results.",
                typeof(string),
                DefaultValue: null,
                ValidateNotNull: true);

            PathSegment[] pathSegments = method.Request.PathSegments
                .Where(ps => ps.IsRaw)
                .Append(new PathSegment(nextPageUrlParameter, false, SerializationFormat.Default, isRaw: true))
                .ToArray();
            var request = new Request(
                RequestMethod.Get,
                pathSegments,
                Array.Empty<QueryParameter>(),
                method.Request.Headers,
                null
            );

            Parameter[] parameters = method.Parameters.Where(p => p.Name != nextPageUrlParameter.Name)
                .Prepend(nextPageUrlParameter)
                .ToArray();

            var responses = method.Responses;

            // We hardcode 200 as expected response code for paged LRO results
            if (operation.IsLongRunning)
            {
                responses = new[]
                {
                    new Response(null, new[] { new StatusCodes(200, null) })
                };
            }

            return new RestClientMethod(
                $"{method.Name}NextPage",
                method.Description,
                method.ReturnType,
                request,
                parameters,
                responses,
                method.HeaderModel,
                bufferResponse: true,
                accessibility: "internal",
                operation);
        }

        public RestClientMethod? GetNextOperationMethod(ServiceRequest request)
        {
            _nextPageMethods.TryGetValue(request, out RestClientMethod? value);
            return value;
        }

        public RestClientMethod GetOperationMethod(ServiceRequest request)
        {
            return _requestMethods[request];
        }
    }
}
