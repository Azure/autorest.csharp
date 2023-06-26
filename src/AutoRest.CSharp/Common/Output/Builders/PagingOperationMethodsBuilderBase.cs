// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using Response = AutoRest.CSharp.Output.Models.Responses.Response;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class PagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        private static readonly ResponseClassifierType NextPageStatusCodes = new(new[] { new StatusCodes(200, null) }.OrderBy(sc => sc.Code));
        private readonly TypeFactory _typeFactory;

        protected OperationPaging Paging { get; }

        protected string? NextLinkName { get; }
        protected string ItemPropertyName { get; }
        protected string? CreateNextPageMessageMethodName { get; }
        protected IReadOnlyList<Parameter> CreateNextPageMessageMethodParameters { get; }

        protected PagingOperationMethodsBuilderBase(OperationPaging paging, InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, OperationMethodReturnTypes returnTypes, ClientPagingMethodParameters clientMethodsParameters)
            : base(operation, restClient, fields, clientName, typeFactory, returnTypes, clientMethodsParameters)
        {
            _typeFactory = typeFactory;
            Paging = paging;
            ItemPropertyName = paging.ItemName ?? "value";
            NextLinkName = paging.NextLinkName;

            CreateNextPageMessageMethodName = paging is { NextLinkOperation: { } nextLinkOperation }
                ? $"Create{nextLinkOperation.Name.ToCleanName()}Request"
                : paging is { NextLinkName: { }} ? $"Create{ProtocolMethodName}NextPageRequest" : null;

            CreateNextPageMessageMethodParameters = clientMethodsParameters.CreateNextPageMessage;
        }

        public override LegacyMethods BuildLegacy(CSharpType? headerModelType, CSharpType? lroType, CSharpType? resourceDataType)
        {
            var legacy = base.BuildLegacy(headerModelType, lroType, resourceDataType);

            if (CreateNextPageMessageMethodName is null || Paging is not { NextLinkOperation: null })
            {
                return legacy with { Order = this is LroPagingOperationMethodsBuilder ? 2 : 1 };
            }

            var nextPageUrlParameter = new Parameter("nextLink", "The URL to the next page of results.", typeof(string), DefaultValue: null, Validation.AssertNotNull, null);

            var nextPageParameters = ConvenienceMethodParameters
                .Where(p => p.Name != nextPageUrlParameter.Name)
                .Prepend(nextPageUrlParameter)
                .ToArray();

            var nextPageResponses = Operation.LongRunning is null
                ? RestClientBuilder.BuildResponses(Operation, resourceDataType, _typeFactory)
                : new[] { new Response(null, new[] { new StatusCodes(200, null) }) };

            var createNextPageRequest = BuildCreateNextPageRequestMethod(CreateNextPageMessageMethodName, legacy.CreateRequest.Signature.Summary, legacy.CreateRequest.Signature.Description);

            var methodName = ProtocolMethodName + "NextPage";
            var invokeCreateRequestMethod = InvokeCreateRequestMethod(null, createNextPageRequest.Signature.Name, createNextPageRequest.Signature.Parameters);
            var returnType = headerModelType is not null
                ? ResponseType is not null ? new CSharpType(typeof(ResponseWithHeaders<>), ResponseType, headerModelType) : new CSharpType(typeof(ResponseWithHeaders))
                : ResponseType is not null ? new CSharpType(typeof(Response<>), ResponseType) : new CSharpType(typeof(Azure.Response));

            var restClientNextPageMethods = new[]
            {
                BuildRestClientConvenienceMethod(methodName, nextPageParameters, invokeCreateRequestMethod, nextPageResponses, headerModelType, returnType, true),
                BuildRestClientConvenienceMethod(methodName, nextPageParameters, invokeCreateRequestMethod, nextPageResponses, headerModelType, returnType, false)
            };

            return new LegacyMethods
            (
                legacy.CreateRequest,
                createNextPageRequest,
                legacy.RestClientConvenience,
                restClientNextPageMethods,
                legacy.Convenience,

                this is LroPagingOperationMethodsBuilder ? 2 : 1,
                Operation,
                null,
                legacy.ResponseType
            );
        }

        protected override IEnumerable<Method> BuildCreateRequestMethods(ResponseClassifierType responseClassifierType)
        {
            var createRequestMethod = BuildCreateRequestMethod(responseClassifierType);
            yield return createRequestMethod;
            if (CreateNextPageMessageMethodName is not null && Paging is { NextLinkOperation: null })
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
            yield return CreateHttpMessage(NextPageStatusCodes, RequestMethod.Get, out var message, out var request, out var uriBuilder);
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

        protected static CSharpType GetResponseType(InputOperation operation, TypeFactory typeFactory, OperationPaging paging)
        {
            var firstResponseBodyType = operation.Responses.Where(r => !r.IsErrorResponse).Select(r => r.BodyType).Distinct().FirstOrDefault();
            if (firstResponseBodyType is null)
            {
                throw new InvalidOperationException($"Method {operation.Name} is pageable and has to have a return value");
            }

            return typeFactory.CreateType(firstResponseBodyType);
        }
    }
}
