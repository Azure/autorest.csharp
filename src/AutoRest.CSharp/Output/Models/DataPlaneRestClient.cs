﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneRestClient : ClientBase
    {
        private readonly OperationGroup _operationGroup;
        private RestClientBuilder<DataPlaneOutputLibrary> _builder;
        private readonly BuildContext<DataPlaneOutputLibrary> _context;

        private Dictionary<ServiceRequest, RestClientMethod>? _requestMethods;
        private Dictionary<ServiceRequest, RestClientMethod>? _nextPageMethods;
        private RestClientMethod[]? _allMethods;

        public DataPlaneRestClient(OperationGroup operationGroup, BuildContext<DataPlaneOutputLibrary> context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            _builder = new RestClientBuilder<DataPlaneOutputLibrary> (operationGroup, context);

            Parameters = _builder.GetOrderedParameters ();

            var mainClient = context.Library.FindClient(operationGroup);

            ClientPrefix = GetClientPrefix(mainClient?.Declaration.Name ?? operationGroup.Language.Default.Name, context);
            RestClientSuffix = "Rest" + ClientSuffix;
            DefaultName = ClientPrefix + RestClientSuffix;
            Description = "";
        }

        protected string RestClientSuffix { get; }
        public Parameter[] Parameters { get; }
        public string Description { get; }
        public RestClientMethod[] Methods => _allMethods ??= BuildAllMethods().ToArray();
        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; } = "internal";

        private IEnumerable<RestClientMethod> BuildAllMethods()
        {
            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = GetOperationMethod(serviceRequest);
                    yield return method;
                }
            }

            foreach (var operation in _operationGroup.Operations)
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

        private Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            if (_requestMethods != null)
            {
                return _requestMethods;
            }

            _requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // See also LowLevelRestClient::EnsureNormalMethods if changing
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }
                    var headerModel = _context.Library.FindHeaderModel(operation);
                    _requestMethods.Add(serviceRequest, _builder.BuildMethod(operation, httpRequest, serviceRequest.Parameters, headerModel));
                }
            }

            return _requestMethods;
        }

        private Dictionary<ServiceRequest, RestClientMethod> EnsureGetNextPageMethods()
        {
            if (_nextPageMethods != null)
            {
                return _nextPageMethods;
            }

            _nextPageMethods = new Dictionary<ServiceRequest, RestClientMethod>();
            foreach (var operation in _operationGroup.Operations)
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
                        _nextPageMethods.Add(serviceRequest, nextMethod);
                    }
                }
            }

            return _nextPageMethods;
        }

        private static RestClientMethod BuildNextPageMethod(RestClientMethod method, Operation operation)
        {
            var nextPageUrlParameter = new Parameter(
                "nextLink",
                "The URL to the next page of results.",
                typeof(string),
                defaultValue: null,
                validateNotNull: true);

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
                isVisible: false);
        }

        public RestClientMethod? GetNextOperationMethod(ServiceRequest request)
        {
            EnsureGetNextPageMethods().TryGetValue(request, out RestClientMethod? value);
            return value;
        }

        public RestClientMethod GetOperationMethod(ServiceRequest request)
        {
            return EnsureNormalMethods()[request];
        }

        private Parameter BuildClientParameter(RequestParameter requestParameter)
        {
            var parameter = BuildParameter(requestParameter);
            if (requestParameter.Origin == "modelerfour:synthesized/host")
            {
                parameter = new Parameter(
                    "endpoint",
                    parameter.Description,
                    typeof(Uri),
                    parameter.DefaultValue,
                    parameter.ValidateNotNull
                );
            }

            return parameter;
        }
    }
}
