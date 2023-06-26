// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class PagingOperationMethodsBuilder : PagingOperationMethodsBuilderBase
    {
        private CSharpType PageItemType { get; }

        public PagingOperationMethodsBuilder(OperationPaging paging, InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientPagingMethodParameters parameters)
            : base(paging, operation, restClient, fields, clientName, typeFactory, GetReturnType(operation, paging, typeFactory), parameters)
        {
            if (ResponseType is null)
            {
                throw new InvalidOperationException($"Method {operation.Name} is pageable and has to have a return value");
            }

            PageItemType = GetPageItemType(ResponseType, paging);
        }

        private static OperationMethodReturnTypes GetReturnType(InputOperation operation, OperationPaging paging, TypeFactory typeFactory)
        {
            var responseType = GetResponseType(operation, typeFactory, paging);
            var pageItemType = GetPageItemType(responseType, paging);
            return new(responseType, typeof(Pageable<BinaryData>), new(typeof(Pageable<>), pageItemType));
        }

        private static CSharpType GetPageItemType(CSharpType responseType, OperationPaging paging)
        {
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

        protected override bool ShouldConvenienceMethodGenerated() => true;

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
        {
            var createRequestArguments = CreateMessageMethodParameters.Select(p => new ParameterReference(p));
            MethodBodyStatement firstPageRequestLine = DeclareFirstPageRequestLocalFunction(null, CreateMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            MethodBodyStatement? nextPageRequestLine = null;
            if (CreateNextPageMessageMethodName is not null)
            {
                var nextPageArguments = CreateNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(null, CreateNextPageMessageMethodName, nextPageArguments, out createNextPageRequest);
            }

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, ClientDiagnosticsProperty, PipelineField, typeof(BinaryData), CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, CreateMessageRequestContext, async));

            return nextPageRequestLine is not null
                ? new[]{firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{firstPageRequestLine, returnLine};
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
        {
            var createRequestArguments = new List<ValueExpression>();
            var parameterConversions = AddPageableMethodArguments(createRequestArguments, out var requestContextVariable).AsStatement();
            var firstPageRequestLine = DeclareFirstPageRequestLocalFunction(RestClient, CreateMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            DeclarationStatement? nextPageRequestLine = null;
            if (CreateNextPageMessageMethodName is not null)
            {
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(RestClient, CreateNextPageMessageMethodName, createRequestArguments.Prepend(KnownParameters.NextLink), out createNextPageRequest);
            }

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, ClientDiagnosticsProperty, PipelineField, PageItemType, CreateScopeName(methodName), ItemPropertyName, NextLinkName, requestContextVariable, async));

            return nextPageRequestLine is not null
                ? new[]{parameterConversions, firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{parameterConversions, firstPageRequestLine, returnLine};
        }

        protected override Method BuildLegacyConvenienceMethod(CSharpType? lroType, bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, ConvenienceModifiers, ConvenienceMethodParameters, ConvenienceMethodReturnType);
            var body = CreateLegacyConvenienceMethodBody(async);

            return new Method(signature.WithAsync(async), body);
        }

        private MethodBodyStatement CreateLegacyConvenienceMethodBody(bool async)
        {
            var createRequestArguments = new List<ValueExpression>();
            var parameterValidations = new ParameterValidationBlock(ConvenienceMethodParameters);
            var parameterConversions = AddPageableMethodArguments(createRequestArguments, out var requestContextVariable).AsStatement();
            var firstPageRequestLine = DeclareFirstPageRequestLocalFunction(RestClient, CreateMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            DeclarationStatement? nextPageRequestLine = null;
            if (CreateNextPageMessageMethodName is not null)
            {
                var arguments = CreateNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(RestClient, CreateNextPageMessageMethodName, arguments, out createNextPageRequest);
            }

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, new MemberReference(null, $"_{KnownParameters.ClientDiagnostics.Name}"), PipelineField, PageItemType, CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, requestContextVariable, async));

            return nextPageRequestLine is not null
                ? new[]{parameterValidations, parameterConversions, firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{parameterValidations, parameterConversions, firstPageRequestLine, returnLine};
        }
    }
}
