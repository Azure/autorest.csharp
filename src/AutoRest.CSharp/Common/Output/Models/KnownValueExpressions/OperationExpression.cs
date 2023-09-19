// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record OperationExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Operation), Untyped)
    {
        public ValueExpression Value => Property(nameof(Operation<object>.Value));
        public ResponseExpression GetRawResponse() => new(Invoke(nameof(Operation.GetRawResponse)));
    }
}
