// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record ResponseExpression(ValueExpression Untyped) : BaseResponseExpression(typeof(Response), Untyped)
    {
        public override ValueExpression Status => Property(nameof(Response.Status));
        public override ValueExpression Value => Property(nameof(Response<object>.Value));

        public override StreamExpression ContentStream => new(Property(nameof(Response.ContentStream)));
        public override BinaryDataExpression Content => new(Property(nameof(Response.Content)));

        public override BaseResponseExpression FromValue(ValueExpression value)
            => new ResponseExpression(new InvokeStaticMethodExpression(typeof(Response), nameof(Response.FromValue), new[] { value, this }));

        public override BaseResponseExpression FromValue(CSharpType explicitValueType, ValueExpression value)
            => new ResponseExpression(new InvokeStaticMethodExpression(typeof(Response), nameof(Response.FromValue), new[] { value, this }, new[] { explicitValueType }));

        public override BaseResponseExpression GetRawResponse() => new ResponseExpression(Invoke(nameof(Response<object>.GetRawResponse)));
    }
}
