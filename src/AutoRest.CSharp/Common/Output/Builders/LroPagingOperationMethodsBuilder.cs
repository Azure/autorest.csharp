// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using Azure;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class LroPagingOperationMethodsBuilder : PagingOperationMethodsBuilderBase
    {
        private readonly OperationLongRunning _longRunning;

        public LroPagingOperationMethodsBuilder(OperationLongRunning longRunning, OperationPaging paging, InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientPagingMethodParameters parameters)
            : base(paging, operation, restClient, fields, clientName, typeFactory, GetReturnType(operation, paging, typeFactory), parameters)
        {
            _longRunning = longRunning;
        }

        private static ClientMethodReturnTypes GetReturnType(InputOperation operation, OperationPaging paging, TypeFactory typeFactory)
        {
            var responseType = GetResponseType(operation, typeFactory, paging);
            return new(responseType, typeof(Operation<Pageable<BinaryData>>), new(typeof(Operation<>), new CSharpType(typeof(Pageable<>), GetResponseType(operation, typeFactory, paging))));
        }

        protected override bool ShouldConvenienceMethodGenerated() => false;

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
        {
            CodeWriterDeclaration? createNextPageRequest = null;
            MethodBodyStatement? nextPageRequestLine = null;
            if (CreateNextPageMessageMethodName is not null)
            {
                var nextPageArguments = CreateNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(null, CreateNextPageMessageMethodName, nextPageArguments, out createNextPageRequest);
            }

            MethodBodyStatement declareMessageLine = Declare("message", InvokeCreateRequestMethod(), out var message);
            MethodBodyStatement returnLine = Return(CreatePageable(message, createNextPageRequest, ClientDiagnosticsDeclaration, PipelineField, typeof(BinaryData), _longRunning.FinalStateVia, CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, CreateMessageRequestContext, async));

            var body = nextPageRequestLine is not null
                ? new[]{nextPageRequestLine, declareMessageLine, returnLine}
                : new[]{declareMessageLine, returnLine};

            return WrapInDiagnosticScope(ProtocolMethodName, body);
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
            => throw new NotSupportedException("LRO Paging isn't supported yet!");

        protected override MethodBodyStatement CreateLegacyConvenienceMethodBody(bool async)
            => throw new NotSupportedException("LRO Paging isn't supported yet!");
    }
}
