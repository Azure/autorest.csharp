// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models.Shared;
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
        protected MethodSignature? CreateNextPageMessageMethodSignature { get; }

        protected PagingOperationMethodsBuilderBase(OperationMethodsBuilderBaseArgs args, OperationPaging paging, StatusCodeSwitchBuilder nextPageStatusCodeSwitchBuilder, ClientPagingMethodParameters clientMethodsParameters)
            : base(args, clientMethodsParameters)
        {
            _nextPageStatusCodeSwitchBuilder = nextPageStatusCodeSwitchBuilder;
            Paging = paging;

            var createNextPageMessageMethodName = paging switch {
                { SelfNextLink: true } => $"Create{Operation.CleanName}Request",
                { NextLinkOperation: { } nextLinkOperation } => $"Create{nextLinkOperation.CleanName}Request",
                { NextLinkName: { }} => $"Create{ProtocolMethodName}NextPageRequest",
                _ => null
            };

            CreateNextPageMessageMethodSignature = createNextPageMessageMethodName is not null
                ? new MethodSignature(createNextPageMessageMethodName, null, null, MethodSignatureModifiers.Internal, typeof(HttpMessage), null, clientMethodsParameters.CreateNextPageMessage)
                : null;

            ItemPropertyName = paging.ItemName ?? "value";
            NextLinkName = paging.NextLinkName;
        }

        public override RestClientOperationMethods BuildLegacy()
        {
            var methods = base.BuildLegacy();

            if (CreateNextPageMessageMethodSignature is null || Paging is not { NextLinkOperation: null, SelfNextLink: false })
            {
                return methods with
                {
                    Order = this is LroPagingOperationMethodsBuilder ? 2 : 1
                };
            }

            var nextPageUrlParameter = new Parameter("nextLink", "The URL to the next page of results.", typeof(string), DefaultValue: null, Validation.AssertNotNull, null);

            var nextPageParameters = ConvenienceMethodParameters


                .Where(p => p.Name != nextPageUrlParameter.Name)
                .Prepend(nextPageUrlParameter)
                .ToArray();

            var methodName = ProtocolMethodName + "NextPage";
            var invokeCreateRequestMethod = InvokeCreateRequestMethod(CreateNextPageMessageMethodSignature.Name, CreateNextPageMessageMethodSignature.Parameters);

            return methods with
            {
                CreateNextPageMessage = new Method(CreateNextPageMessageMethodSignature, BuildCreateNextPageRequestMethodBody().AsStatement()),
                NextPageConvenience = BuildLegacyConvenienceMethod(methodName, nextPageParameters, invokeCreateRequestMethod, _nextPageStatusCodeSwitchBuilder, false),
                NextPageConvenienceAsync = BuildLegacyConvenienceMethod(methodName, nextPageParameters, invokeCreateRequestMethod, _nextPageStatusCodeSwitchBuilder, true),
                Order = this is LroPagingOperationMethodsBuilder ? 2 : 1
            };
        }

        protected override Method? BuildCreateNextPageMessageMethod(ResponseClassifierType responseClassifierType)
        {
            return CreateNextPageMessageMethodSignature is not null && Paging is { NextLinkOperation: null, SelfNextLink: false }
                ? new Method(CreateNextPageMessageMethodSignature, BuildCreateNextPageRequestMethodBody().AsStatement())
                : null;
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
