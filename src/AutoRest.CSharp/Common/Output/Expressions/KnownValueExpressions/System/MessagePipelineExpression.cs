// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ClientModel.Core.Pipeline;
using System.Net.ClientModel.Internal;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record MessagePipelineExpression(ValueExpression Untyped) : TypedValueExpression<MessagePipeline>(Untyped)
    {
        public PipelineResponseExpression ProcessMessage(TypedValueExpression message, RequestOptionsExpression? requestContext, CancellationTokenExpression? cancellationToken, bool async)
        {
            var arguments = new List<ValueExpression>
            {
                message,
                requestContext ?? Snippets.Null
            };

            if (cancellationToken != null)
            {
                arguments.Add(cancellationToken);
            }

            var methodName = async ? nameof(PipelineProtocolExtensions.ProcessMessageAsync) : nameof(PipelineProtocolExtensions.ProcessMessage);
            return new(InvokeExtension(typeof(PipelineProtocolExtensions), methodName, arguments, async));
        }

        public ResultExpression ProcessHeadAsBoolMessage(TypedValueExpression message, ValueExpression clientDiagnostics, RequestOptionsExpression? requestContext, bool async)
        {
            var arguments = new List<ValueExpression>
            {
                message,
                clientDiagnostics,
                requestContext ?? Snippets.Null
            };

            var methodName = async ? nameof(PipelineProtocolExtensions.ProcessHeadAsBoolMessageAsync) : nameof(PipelineProtocolExtensions.ProcessHeadAsBoolMessage);
            return new(InvokeExtension(typeof(PipelineProtocolExtensions), methodName, arguments, async));
        }
    }
}
