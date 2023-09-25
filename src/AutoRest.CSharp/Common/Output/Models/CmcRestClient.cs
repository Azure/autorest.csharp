﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class CmcRestClient : TypeProvider
    {
        private readonly CachedDictionary<ServiceRequest, RestClientMethod> _requestMethods;
        private readonly CachedDictionary<ServiceRequest, RestClientMethod> _nextPageRequestMethods;
        private (Operation Operation, RestClientMethod Method)[]? _allMethods;
        private ConstructorSignature? _constructor;

        internal OperationGroup OperationGroup { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public (Operation Operation, RestClientMethod Method)[] Methods => _allMethods ??= BuildAllMethods().ToArray();
        public ConstructorSignature Constructor => _constructor ??= new ConstructorSignature(Type, $"Initializes a new instance of {Declaration.Name}", null, MethodSignatureModifiers.Public, Parameters.ToArray());

        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility => "internal";

        protected CmcRestClient(OperationGroup operationGroup, BuildContext context, string? clientName, IReadOnlyList<Parameter> parameters) : base(context)
        {
            OperationGroup = operationGroup;

            _requestMethods = new CachedDictionary<ServiceRequest, RestClientMethod>(EnsureNormalMethods);
            _nextPageRequestMethods = new CachedDictionary<ServiceRequest, RestClientMethod>(EnsureGetNextPageMethods);

            Parameters = parameters;

            var clientPrefix = ClientBuilder.GetClientPrefix(clientName ?? operationGroup.Language.Default.Name, context);
            ClientPrefix = clientPrefix;
            DefaultName = clientPrefix + "Rest" + ClientBuilder.GetClientSuffix();
        }

        private IEnumerable<(Operation Operation, RestClientMethod Method)> BuildAllMethods()
        {
            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = GetOperationMethod(serviceRequest);
                    yield return (operation, method);
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
                        yield return (operation, nextOperationMethod);
                    }
                }
            }
        }

        protected abstract Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods();

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
                        nextMethod = CmcRestClientBuilder.BuildNextPageMethod(operation, method);
                    }

                    if (nextMethod != null)
                    {
                        nextPageMethods.Add(serviceRequest, nextMethod);
                    }
                }
            }

            return nextPageMethods;
        }

        public RestClientMethod? GetNextOperationMethod(ServiceRequest request)
        {
            _nextPageRequestMethods.TryGetValue(request, out RestClientMethod? value);
            return value;
        }

        public RestClientMethod GetOperationMethod(ServiceRequest request)
        {
            return _requestMethods[request];
        }
    }
}
