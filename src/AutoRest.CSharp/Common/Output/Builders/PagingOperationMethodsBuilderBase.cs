// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class PagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        protected OperationPaging Paging { get; }
        protected CSharpType ResponseType { get; }
        protected RequestContextExpression? RequestContext { get; }

        protected string? NextLinkName { get; }
        protected string ItemPropertyName { get; }
        protected string? CreateNextPageMessageMethodName { get; }
        protected IReadOnlyList<Parameter> CreateNextPageMessageMethodParameters { get; }

        protected PagingOperationMethodsBuilderBase(OperationPaging paging, InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodReturnTypes returnTypes, ClientPagingMethodParameters clientMethodsParameters)
            : base(operation, restClient, fields, clientName, typeFactory, returnTypes, clientMethodsParameters)
        {
            Paging = paging;
            ItemPropertyName = paging.ItemName ?? "value";
            NextLinkName = paging.NextLinkName;

            ResponseType = GetResponseType(operation, typeFactory, paging);
            RequestContext = ProtocolMethodParameters.Contains(KnownParameters.RequestContext)
                ? new RequestContextExpression(KnownParameters.RequestContext)
                : null;

            CreateNextPageMessageMethodName = paging is { NextLinkOperation: { } nextLinkOperation }
                ? $"Create{nextLinkOperation.Name.ToCleanName()}Request"
                : paging is { NextLinkName: { }} ? $"Create{ProtocolMethodName}NextPageRequest" : null;
            CreateNextPageMessageMethodParameters = clientMethodsParameters.CreateNextPageMessage;
        }

        protected override IEnumerable<RestClientMethod> BuildCreateRequestMethods(DataPlaneResponseHeaderGroupType? headerModel, CSharpType? resourceDataType)
        {
            var createMessageMethod = base.BuildCreateRequestMethods(headerModel, resourceDataType).Single();
            yield return createMessageMethod;
            if (CreateNextPageMessageMethodName is not null && Paging is { NextLinkOperation: null })
            {
                yield return BuildNextPageMethod(createMessageMethod);
            }
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

            var responseType = typeFactory.CreateType(firstResponseBodyType);
            if (responseType.IsFrameworkType || responseType.Implementation is not SerializableObjectType modelType)
            {
                return TypeFactory.IsList(responseType) ? TypeFactory.GetElementType(responseType) : responseType;
            }

            var property = modelType.GetPropertyBySerializedName(paging.ItemName ?? "value");
            var propertyType = property.ValueType.WithNullable(false);
            if (!TypeFactory.IsList(propertyType))
            {
                throw new InvalidOperationException($"'{modelType.Declaration.Name}.{property.Declaration.Name}' property must be a collection of items");
            }

            return TypeFactory.GetElementType(property.ValueType);
        }

        private static RequestContextExpression IfCancellationTokenCanBeCanceled(CancellationTokenExpression cancellationToken)
            => new(new TernaryConditionalOperator(cancellationToken.CanBeCanceled, RequestContextExpression.New(cancellationToken), Null));

        private static RestClientMethod BuildNextPageMethod(RestClientMethod method)
        {
            var nextPageUrlParameter = new Parameter("nextLink", "The URL to the next page of results.", typeof(string), DefaultValue: null, Validation.AssertNotNull, null);

            var pathSegments = method.Request.PathSegments
                .Where(ps => ps.IsRaw)
                .Append(new PathSegment(nextPageUrlParameter, false, SerializationFormat.Default, isRaw: true))
                .ToArray();

            var request = new Request(RequestMethod.Get, pathSegments, Array.Empty<QueryParameter>(), method.Request.Headers, null);
            var parameters = method.Parameters.Where(p => p.Name != nextPageUrlParameter.Name).Prepend(nextPageUrlParameter).ToArray();
            var responses = method.Responses;

            // We hardcode 200 as expected response code for paged LRO results
            if (method.Operation.LongRunning != null)
            {
                responses = new[]
                {
                    new Response(null, new[] { new StatusCodes(200, null) })
                };
            }

            return new RestClientMethod(
                $"{method.Name}NextPage",
                method.Summary,
                method.Description,
                method.ReturnType,
                request,
                parameters,
                responses,
                method.HeaderModel,
                bufferResponse: true,
                accessibility: "internal",
                method.Operation);
        }
    }
}
