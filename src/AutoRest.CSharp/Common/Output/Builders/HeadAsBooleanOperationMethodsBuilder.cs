// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Output.Models;
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
                Extensible.RestOperations.DeclareHttpMessage(createMessageSignature, out var message),
                Extensible.RestOperations.InvokeServiceOperationCallAndReturnHeadAsBool(PipelineField, message, ClientDiagnosticsProperty, async)
            );

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async)
            => throw new NotImplementedException($"{methodName} protocol method returns `Response<bool>`, hence it should not have convenience method");
    }
}
