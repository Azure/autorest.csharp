// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Types.System;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record ClientPipelineExpression(ValueExpression Untyped) : TypedValueExpression<ClientPipeline>(Untyped)
    {
        public PipelineMessageExpression CreateMessage(RequestOptionsExpression requestOptions, ValueExpression responseClassifier) => new(Invoke(nameof(ClientPipeline.CreateMessage), requestOptions, responseClassifier));

        public PipelineResponseExpression ProcessMessage(TypedValueExpression message, RequestOptionsExpression? requestOptions, bool async)
        {
            var arguments = new List<ValueExpression>
            {
                Untyped,
                message,
                requestOptions ?? Snippets.Null
            };

            return ClientPipelineExtensionsProvider.Instance.ProcessMessage(arguments, async);
        }

        public ClientResultExpression ProcessHeadAsBoolMessage(TypedValueExpression message, RequestOptionsExpression? requestContext, bool async)
        {
            var arguments = new List<ValueExpression>
            {
                Untyped,
                message,
                requestContext ?? Snippets.Null
            };

            return ClientPipelineExtensionsProvider.Instance.ProcessHeadAsBoolMessage(arguments, async);
        }
    }
}
