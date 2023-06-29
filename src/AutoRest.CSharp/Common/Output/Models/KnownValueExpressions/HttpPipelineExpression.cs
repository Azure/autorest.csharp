// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record HttpPipelineExpression(ValueExpression Untyped) : TypedValueExpression(typeof(HttpPipeline), Untyped)
    {
        public HttpMessageExpression CreateMessage() => new(new InvokeInstanceMethodExpression(Untyped, nameof(HttpPipeline.CreateMessage)));
        public HttpMessageExpression CreateMessage(RequestContextExpression requestContext) => new(new InvokeInstanceMethodExpression(Untyped, nameof(HttpPipeline.CreateMessage), requestContext));
        public HttpMessageExpression CreateMessage(RequestContextExpression requestContext, ValueExpression responseClassifier) => new(new InvokeInstanceMethodExpression(Untyped, nameof(HttpPipeline.CreateMessage), requestContext, responseClassifier));

        public ValueExpression ProcessMessage(HttpMessageExpression message, RequestContextExpression? requestContext, CancellationTokenExpression? cancellationToken, bool async)
        {
            var arguments = new List<ValueExpression>
            {
                Untyped,
                message,
                requestContext ?? Snippets.Null
            };

            if (cancellationToken != null)
            {
                arguments.Add(cancellationToken);
            }

            var methodName = async ? nameof(HttpPipelineExtensions.ProcessMessageAsync) : nameof(HttpPipelineExtensions.ProcessMessage);
            return new InvokeStaticMethodExpression(typeof(HttpPipelineExtensions), methodName, arguments, null, true, async);
        }

        public MethodBodyStatement Send(HttpMessageExpression message, CancellationTokenExpression cancellationToken, bool async)
        {
            var methodName = async ? nameof(HttpPipeline.SendAsync) : nameof(HttpPipeline.Send);
            return new InvokeInstanceMethodStatement(Untyped, methodName, new ValueExpression[]{message, cancellationToken}, async);
        }

        public ValueExpression ProcessHeadAsBoolMessage(HttpMessageExpression message, ValueExpression clientDiagnostics, RequestContextExpression? requestContext, bool async)
        {
            var arguments = new List<ValueExpression>
            {
                Untyped,
                message,
                clientDiagnostics,
                requestContext ?? Snippets.Null
            };

            var methodName = async ? nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessageAsync) : nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessage);
            return new InvokeStaticMethodExpression(typeof(HttpPipelineExtensions), methodName, arguments, null, true, async);
        }
    }
}
