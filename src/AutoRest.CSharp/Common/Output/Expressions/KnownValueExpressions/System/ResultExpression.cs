// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record ResultExpression(ValueExpression Untyped) : BaseResponseExpression(typeof(Result), Untyped)
    {
        public override ValueExpression Value => Property(nameof(Result<object>.Value));
        public override BinaryDataExpression Content => throw new InvalidOperationException("Result does not have a Content property");
        public override StreamExpression ContentStream => throw new InvalidOperationException("Result does not have a ContentStream property");

        public override BaseResponseExpression FromValue(ValueExpression value)
            => new ResultExpression(new InvokeStaticMethodExpression(typeof(Result), nameof(Result.FromValue), new[] { value, this }));

        public override BaseResponseExpression FromValue(CSharpType explicitValueType, ValueExpression value)
            => new ResultExpression(new InvokeStaticMethodExpression(typeof(Result), nameof(Result.FromValue), new[] { value, this }, new[] { explicitValueType }));

        public override BaseResponseExpression GetRawResponse() => new ResultExpression(Invoke(nameof(Result<object>.GetRawResponse)));
    }
}
