// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class LroPagingOperationMethodsBuilder : PagingOperationMethodsBuilderBase
    {
        private readonly OperationLongRunning _longRunning;

        public LroPagingOperationMethodsBuilder(OperationMethodsBuilderBaseArgs args, OperationPaging paging, OperationLongRunning longRunning)
            : base(args, paging, args.StatusCodeSwitchBuilder.CreateLroPagingNextPageSwitch())
        {
            _longRunning = longRunning;
        }

        protected override MethodBodyStatement CreateProtocolMethodBody(MethodSignatureBase createMessageSignature, MethodSignature? createNextPageMessageSignature, bool async)
        {
            CodeWriterDeclaration? createNextPageRequest = null;
            MethodBodyStatement? nextPageRequestLine = null;
            if (createNextPageMessageSignature is not null)
            {
                var nextPageArguments = createNextPageMessageSignature.Parameters.Select(p => (ValueExpression)p);
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(null, createNextPageMessageSignature.Name, nextPageArguments, out createNextPageRequest);
            }

            MethodBodyStatement declareMessageLine = UsingDeclare("message", InvokeCreateRequestMethod(createMessageSignature), out var message);
            MethodBodyStatement returnLine = Return(CreatePageable(message, createNextPageRequest, ClientDiagnosticsProperty, PipelineField, typeof(BinaryData), _longRunning.FinalStateVia, CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, new RequestContextExpression(KnownParameters.RequestContext), async));

            var body = nextPageRequestLine is not null
                ? new[]{nextPageRequestLine, declareMessageLine, returnLine}
                : new[]{declareMessageLine, returnLine};

            return WrapInDiagnosticScope(ProtocolMethodName, body);
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName,
            RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async)
            => throw new NotSupportedException("LRO Paging isn't supported yet!");
    }
}
