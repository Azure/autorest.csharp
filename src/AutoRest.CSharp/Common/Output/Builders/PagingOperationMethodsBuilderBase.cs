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
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class PagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        protected OperationPaging Paging { get; }
        protected CSharpType ResponseType { get; }

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

            CreateNextPageMessageMethodName = paging is { NextLinkOperation: { } nextLinkOperation }
                ? $"Create{nextLinkOperation.Name.ToCleanName()}Request"
                : paging is { NextLinkName: { }} ? $"Create{ProtocolMethodName}NextPageRequest" : null;

            CreateNextPageMessageMethodParameters = clientMethodsParameters.CreateNextPageMessage;
        }

        protected override IEnumerable<Method> BuildCreateRequestMethods(ResponseClassifierType responseClassifierType)
        {
            var createRequestMethod = base.BuildCreateRequestMethods(responseClassifierType).Single();
            yield return createRequestMethod;
            if (CreateNextPageMessageMethodName is not null && Paging is { NextLinkOperation: null })
            {
                yield return BuildCreateNextPageRequestMethod(CreateNextPageMessageMethodName, createRequestMethod.Signature.Summary, createRequestMethod.Signature.Description, responseClassifierType);
            }
        }

        private Method BuildCreateNextPageRequestMethod(string name, string? summary, string? description, ResponseClassifierType responseClassifierType)
        {
            var signature = new MethodSignature(name, summary, description, MethodSignatureModifiers.Internal, typeof(HttpMessage), null, CreateNextPageMessageMethodParameters);
            return new Method(signature, BuildCreateNextPageRequestMethodBody(responseClassifierType).AsStatement());
        }

        private IEnumerable<MethodBodyStatement> BuildCreateNextPageRequestMethodBody(ResponseClassifierType responseClassifierType)
        {
            yield return CreateHttpMessage(responseClassifierType, RequestMethod.Get, out var message, out var request, out var uriBuilder);
            yield return AddUri(uriBuilder, Operation.Uri);
            yield return uriBuilder.AppendRawNextLink(KnownParameters.NextLink, false);
            yield return Assign(request.Uri, uriBuilder);

            yield return AddHeaders(request, false).AsStatement();
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
    }
}
