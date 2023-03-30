// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record HttpPipelineExpression(ValueExpression Untyped) : TypedValueExpression(typeof(HttpPipeline), Untyped)
    {
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
            return new StaticMethodCallExpression(typeof(HttpPipelineExtensions), methodName, arguments, null, true, async);
        }

        public ValueExpression ProcessHeadAsBoolMessage(HttpMessageExpression message, CodeWriterDeclaration clientDiagnostics, RequestContextExpression? requestContext, bool async)
        {
            var arguments = new List<ValueExpression>
            {
                Untyped,
                message,
                clientDiagnostics,
                requestContext ?? Snippets.Null
            };

            var methodName = async ? nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessageAsync) : nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessage);
            return new StaticMethodCallExpression(typeof(HttpPipelineExtensions), methodName, arguments, null, true, async);
        }
    }
}
