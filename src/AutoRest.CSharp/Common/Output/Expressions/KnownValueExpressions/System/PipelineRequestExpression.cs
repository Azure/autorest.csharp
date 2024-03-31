// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record PipelineRequestExpression(ValueExpression Untyped) : TypedValueExpression<PipelineRequest>(Untyped)
    {
        public TypedValueExpression Uri => new FrameworkTypeExpression(typeof(Uri), Property(nameof(PipelineRequest.Uri)));
        public BinaryContentExpression Content => new(Property(nameof(PipelineRequest.Content)));
        public MethodBodyStatement SetMethod(string method) => Assign(Untyped.Property("Method"), Literal(method));
        public MethodBodyStatement SetHeaderValue(string name, StringExpression value)
            => new InvokeInstanceMethodStatement(Untyped.Property(nameof(PipelineRequest.Headers)), nameof(PipelineRequestHeaders.Set), Literal(name), value);
    }
}
