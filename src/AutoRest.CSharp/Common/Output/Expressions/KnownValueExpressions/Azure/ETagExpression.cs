// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using Azure;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record ETagExpression(ValueExpression Untyped) : TypedValueExpression<ETag>(Untyped)
    {
        public StringExpression InvokeToString(ValueExpression format) => new(Invoke(nameof(ETag.ToString), format));
    }
}
