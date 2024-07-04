// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record PipelineMessageExpression(ValueExpression Untyped) : TypedValueExpression<PipelineMessage>(Untyped)
    {
        public PipelineRequestExpression Request => new(Property(nameof(PipelineMessage.Request)));

        public PipelineResponseExpression Response => new(Property(nameof(PipelineMessage.Response)));

        public BoolExpression BufferResponse => new(Property(nameof(PipelineMessage.BufferResponse)));

        public PipelineResponseExpression ExtractResponse() => new(new InvokeInstanceMethodExpression(Untyped, nameof(PipelineMessage.ExtractResponse), Array.Empty<ValueExpression>(), false));
    }
}
