﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Models.Statements;
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
        public PagingOperationMethodsBuilder(OperationPaging paging, InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientPagingMethodParameters parameters)
            : base(paging, operation, restClient, fields, clientName, typeFactory, GetReturnType(operation, paging, typeFactory), parameters)
        {
        }

        private static ClientMethodReturnTypes GetReturnType(InputOperation operation, OperationPaging paging, TypeFactory typeFactory)
        {
            var responseType = GetResponseType(operation, typeFactory, paging);
            return new(responseType, typeof(Pageable<BinaryData>), new(typeof(Pageable<>), responseType));
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

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, ClientDiagnosticsDeclaration, PipelineField, typeof(BinaryData), CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, CreateMessageRequestContext, async));

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

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, ClientDiagnosticsDeclaration, PipelineField, ResponseType, CreateScopeName(methodName), ItemPropertyName, NextLinkName, requestContextVariable, async));

            return nextPageRequestLine is not null
                ? new[]{parameterConversions, firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{parameterConversions, firstPageRequestLine, returnLine};
        }

        protected override MethodBodyStatement CreateLegacyConvenienceMethodBody(bool async)
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

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, new MemberReference(null, $"_{KnownParameters.ClientDiagnostics.Name}"), PipelineField, ResponseType, CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, requestContextVariable, async));

            return nextPageRequestLine is not null
                ? new[]{parameterValidations, parameterConversions, firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{parameterValidations, parameterConversions, firstPageRequestLine, returnLine};
        }
    }
}
