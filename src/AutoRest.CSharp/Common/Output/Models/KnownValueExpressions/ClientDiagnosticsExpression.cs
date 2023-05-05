// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal record ClientDiagnosticsExpression(ValueExpression Untyped) : TypedValueExpression(typeof(ClientDiagnostics), Untyped)
    {
        public ValueExpression CreateRequestFailedException(ResponseExpression response, bool async)
        {
            var methodName = async ? nameof(ClientDiagnostics.CreateRequestFailedExceptionAsync) : nameof(ClientDiagnostics.CreateRequestFailedException);
            return new InvokeInstanceMethodExpression(Untyped, methodName, new[]{response}, null, async);
        }
    }
}
