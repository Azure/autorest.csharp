// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record MultipartFormDataContentExpression(ValueExpression Untyped) : TypedValueExpression<MultipartFormDataContent>(Untyped)
    {
        public MethodBodyStatement Add(RequestContentExpression requestContent, string name, ValueExpression headers)
            => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataContent.Add), new[]{requestContent, Literal(name), headers}, false);

        public MethodBodyStatement ApplyToRequest(RequestExpression request)
            => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataContent.ApplyToRequest), request);
    }
}
