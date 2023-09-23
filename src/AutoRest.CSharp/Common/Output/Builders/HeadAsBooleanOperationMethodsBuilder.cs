// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class HeadAsBooleanOperationMethodsBuilder : NonPagingOperationMethodsBuilderBase
    {
        public HeadAsBooleanOperationMethodsBuilder(OperationMethodsBuilderBaseArgs args)
            : base(args)
        {

        }

        protected override MethodBodyStatement CreateProtocolMethodBody(MethodSignatureBase createMessageSignature, MethodSignature? createNextPageMessageSignature, bool async)
            => WrapInDiagnosticScope(ProtocolMethodName,
                UsingDeclare("message", InvokeCreateRequestMethod(createMessageSignature), out var message),
                Return(PipelineField.ProcessHeadAsBoolMessage(message, ClientDiagnosticsProperty, new RequestContextExpression(KnownParameters.RequestContext), async))
            );

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async)
            => throw new System.NotImplementedException();
    }
}
