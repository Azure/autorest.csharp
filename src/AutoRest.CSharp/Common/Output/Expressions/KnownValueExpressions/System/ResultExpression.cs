// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record ResultExpression(ValueExpression Untyped) : BaseResponseExpression(typeof(Result), Untyped)
    {
        public override ValueExpression Status => Property(nameof(Result.Status));
        public override ValueExpression Value => Property(nameof(Result<object>.Value));

        public override StreamExpression ContentStream => new(Property(nameof(Result.ContentStream)));
        public override BinaryDataExpression Content => new(Property(nameof(Result.Content)));

        public override BaseResponseExpression FromValue(ValueExpression value)
            => new ResultExpression(new InvokeStaticMethodExpression(typeof(Result), nameof(Result.FromValue), new[] { value, this }));

        public override BaseResponseExpression FromValue(CSharpType explicitValueType, ValueExpression value)
            => new ResultExpression(new InvokeStaticMethodExpression(typeof(Result), nameof(Result.FromValue), new[] { value, this }, new[] { explicitValueType }));

        public override BaseResponseExpression GetRawResponse() => new ResultExpression(Invoke(nameof(Result<object>.GetRawResult)));
    }
}
