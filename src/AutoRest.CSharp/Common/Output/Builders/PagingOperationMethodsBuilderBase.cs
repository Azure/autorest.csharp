// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class PagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        private readonly StatusCodeSwitchBuilder _nextPageStatusCodeSwitchBuilder;

        protected OperationPaging Paging { get; }

        protected string? NextLinkName { get; }
        protected string ItemPropertyName { get; }
        protected string? CreateNextPageMessageMethodName { get; }
        protected IReadOnlyList<Parameter> CreateNextPageMessageMethodParameters { get; }

        protected PagingOperationMethodsBuilderBase(OperationMethodsBuilderBaseArgs args, OperationPaging paging, StatusCodeSwitchBuilder nextPageStatusCodeSwitchBuilder, ClientPagingMethodParameters clientMethodsParameters)
            : base(args, clientMethodsParameters)
        {
            _nextPageStatusCodeSwitchBuilder = nextPageStatusCodeSwitchBuilder;
            Paging = paging;
            ItemPropertyName = paging.ItemName ?? "value";
            NextLinkName = paging.NextLinkName;

            CreateNextPageMessageMethodName = paging switch {
                { SelfNextLink: true } => $"Create{Operation.CleanName}Request",
                { NextLinkOperation: { } nextLinkOperation } => $"Create{nextLinkOperation.CleanName}Request",
                { NextLinkName: { }} => $"Create{ProtocolMethodName}NextPageRequest",
                _ => null
            };

            CreateNextPageMessageMethodParameters = clientMethodsParameters.CreateNextPageMessage;
        }

        public override LegacyMethods BuildLegacy()
        {
            var legacy = base.BuildLegacy();

            if (CreateNextPageMessageMethodName is null || Paging is not { NextLinkOperation: null, SelfNextLink: false })
            {
                return legacy with
                {
                    Order = this is LroPagingOperationMethodsBuilder ? 2 : 1
                };
            }

            var nextPageUrlParameter = new Parameter("nextLink", "The URL to the next page of results.", typeof(string), DefaultValue: null, Validation.AssertNotNull, null);

            var nextPageParameters = ConvenienceMethodParameters
                .Where(p => p.Name != nextPageUrlParameter.Name)
                .Prepend(nextPageUrlParameter)
                .ToArray();

            var createNextPageRequest = BuildCreateNextPageRequestMethod(CreateNextPageMessageMethodName, legacy.CreateRequest.Signature.Summary, legacy.CreateRequest.Signature.Description);

            var methodName = ProtocolMethodName + "NextPage";
            var invokeCreateRequestMethod = InvokeCreateRequestMethod(null, createNextPageRequest.Signature.Name, createNextPageRequest.Signature.Parameters);

            var restClientNextPageMethods = new[]
            {
                BuildRestClientConvenienceMethod(methodName, nextPageParameters, invokeCreateRequestMethod, _nextPageStatusCodeSwitchBuilder, true),
                BuildRestClientConvenienceMethod(methodName, nextPageParameters, invokeCreateRequestMethod, _nextPageStatusCodeSwitchBuilder, false)
            };

            return legacy with
            {
                CreateNextPageRequest = createNextPageRequest,
                RestClientNextPageConvenience = restClientNextPageMethods,
                Order = this is LroPagingOperationMethodsBuilder ? 2 : 1
            };
        }

        protected override IEnumerable<Method> BuildCreateRequestMethods(ResponseClassifierType responseClassifierType)
        {
            var createRequestMethod = BuildCreateRequestMethod(responseClassifierType);
            yield return createRequestMethod;
            if (CreateNextPageMessageMethodName is not null && Paging is { NextLinkOperation: null, SelfNextLink: false })
            {
                yield return BuildCreateNextPageRequestMethod(CreateNextPageMessageMethodName, createRequestMethod.Signature.Summary, createRequestMethod.Signature.Description);
            }
        }

        private Method BuildCreateNextPageRequestMethod(string name, string? summary, string? description)
        {
            var signature = new MethodSignature(name, summary, description, MethodSignatureModifiers.Internal, typeof(HttpMessage), null, CreateNextPageMessageMethodParameters);
            return new Method(signature, BuildCreateNextPageRequestMethodBody().AsStatement());
        }

        private IEnumerable<MethodBodyStatement> BuildCreateNextPageRequestMethodBody()
        {
            yield return CreateHttpMessage(_nextPageStatusCodeSwitchBuilder.ResponseClassifier, RequestMethod.Get, out var message, out var request, out var uriBuilder);
            yield return AddUri(uriBuilder, Operation.Uri);
            yield return uriBuilder.AppendRawNextLink(KnownParameters.NextLink, false);
            yield return Assign(request.Uri, uriBuilder);

            yield return AddHeaders(request, false).AsStatement();
            yield return AddUserAgent(message);
            yield return Return(message);
        }

        protected IEnumerable<MethodBodyStatement> AddPageableMethodArguments(List<ValueExpression> createRequestArguments, out ValueExpression? requestContextVariable)
        {
            var conversions = new List<MethodBodyStatement>();
            requestContextVariable = null;
            foreach (var protocolParameter in ProtocolMethodParameters)
            {
                if (ArgumentsMap.TryGetValue(protocolParameter, out var argument))
                {
                    createRequestArguments.Add(argument);
                    if (protocolParameter == KnownParameters.RequestContext)
                    {
                        requestContextVariable = argument;
                    }

                    if (ConversionsMap.TryGetValue(protocolParameter, out var conversion))
                    {
                        conversions.Add(conversion);
                    }
                }
                else
                {
                    createRequestArguments.Add(protocolParameter);
                }
            }

            if (requestContextVariable == null && ConvenienceMethodParameters.Contains(KnownParameters.CancellationTokenParameter))
            {
                requestContextVariable = KnownParameters.CancellationTokenParameter;
            }

            return conversions;
        }
    }
}
