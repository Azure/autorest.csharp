﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class CmcRestClient : TypeProvider
    {
        private readonly Lazy<IReadOnlyDictionary<InputOperation, RestClientMethod>> _requestMethods;
        private readonly Lazy<IReadOnlyDictionary<InputOperation, RestClientMethod>> _nextPageRequestMethods;
        private (InputOperation Operation, RestClientMethod Method)[]? _allMethods;
        private ConstructorSignature? _constructor;

        internal InputClient InputClient { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public (InputOperation Operation, RestClientMethod Method)[] Methods => _allMethods ??= BuildAllMethods().ToArray();
        public ConstructorSignature Constructor => _constructor ??= new ConstructorSignature(Type, $"Initializes a new instance of {Declaration.Name}", null, MethodSignatureModifiers.Public, Parameters);

        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility => "internal";

        protected CmcRestClient(InputClient inputClient, BuildContext context, string? clientName, IReadOnlyList<Parameter> parameters) : base(context)
        {
            InputClient = inputClient;

            _requestMethods = new Lazy<IReadOnlyDictionary<InputOperation, RestClientMethod>>(EnsureNormalMethods);
            _nextPageRequestMethods = new Lazy<IReadOnlyDictionary<InputOperation, RestClientMethod>>(EnsureGetNextPageMethods);

            Parameters = parameters;

            var clientPrefix = ClientBuilder.GetClientPrefix(clientName ?? inputClient.Name, context);
            ClientPrefix = clientPrefix;
            DefaultName = clientPrefix + "Rest" + ClientBuilder.GetClientSuffix();
        }

        private IEnumerable<(InputOperation Operation, RestClientMethod Method)> BuildAllMethods()
        {
            foreach (var operation in InputClient.Operations)
            {
                RestClientMethod method = GetOperationMethod(operation);
                yield return (operation, method);
            }

            foreach (var operation in InputClient.Operations)
            {
                // remove duplicates when GetNextPage method is not autogenerated
                if (GetNextOperationMethod(operation) is { } nextOperationMethod &&
                    operation.Paging?.NextLinkOperation == null)
                {
                    yield return (operation, nextOperationMethod);
                }
            }
        }

        protected abstract Dictionary<InputOperation, RestClientMethod> EnsureNormalMethods();

        protected Dictionary<InputOperation, RestClientMethod> EnsureGetNextPageMethods()
        {
            var nextPageMethods = new Dictionary<InputOperation, RestClientMethod>();
            foreach (var operation in InputClient.Operations)
            {
                var paging = operation.Paging;
                if (paging == null)
                {
                    continue;
                }
                RestClientMethod? nextMethod = null;
                if (paging.NextLinkOperation != null)
                {
                    nextMethod = GetOperationMethod(paging.NextLinkOperation);
                }
                else if (paging.NextLinkName != null)
                {
                    var method = GetOperationMethod(operation);
                    nextMethod = CmcRestClientBuilder.BuildNextPageMethod(operation, method);
                }

                if (nextMethod != null)
                {
                    nextPageMethods.Add(operation, nextMethod);
                }
            }

            return nextPageMethods;
        }

        public RestClientMethod? GetNextOperationMethod(InputOperation operation)
        {
            _nextPageRequestMethods.Value.TryGetValue(operation, out RestClientMethod? value);
            return value;
        }

        public RestClientMethod GetOperationMethod(InputOperation operation)
        {
            return _requestMethods.Value[operation];
        }
    }
}
