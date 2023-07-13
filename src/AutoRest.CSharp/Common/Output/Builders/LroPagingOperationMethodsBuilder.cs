// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class LroPagingOperationMethodsBuilder : PagingOperationMethodsBuilderBase
    {
        private readonly OperationLongRunning _longRunning;

        public LroPagingOperationMethodsBuilder(OperationMethodsBuilderBaseArgs args, OperationPaging paging, ClientPagingMethodParameters parameters, OperationLongRunning longRunning)
            : base(args, paging, args.StatusCodeSwitchBuilder.CreateLroPagingNextPageSwitch(), parameters)
        {
            _longRunning = longRunning;
        }

        protected override bool ShouldConvenienceMethodGenerated() => false;

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
        {
            CodeWriterDeclaration? createNextPageRequest = null;
            MethodBodyStatement? nextPageRequestLine = null;
            if (CreateNextPageMessageMethodSignature is not null)
            {
                var nextPageArguments = CreateNextPageMessageMethodSignature.Parameters.Select(p => new ParameterReference(p));
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(null, CreateNextPageMessageMethodSignature.Name, nextPageArguments, out createNextPageRequest);
            }

            MethodBodyStatement declareMessageLine = Declare("message", InvokeCreateRequestMethod(), out var message);
            MethodBodyStatement returnLine = Return(CreatePageable(message, createNextPageRequest, ClientDiagnosticsProperty, PipelineField, typeof(BinaryData), _longRunning.FinalStateVia, CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, CreateMessageRequestContext, async));

            var body = nextPageRequestLine is not null
                ? new[]{nextPageRequestLine, declareMessageLine, returnLine}
                : new[]{declareMessageLine, returnLine};

            return WrapInDiagnosticScope(ProtocolMethodName, body);
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
            => throw new NotSupportedException("LRO Paging isn't supported yet!");
    }
}
