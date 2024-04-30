// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record MatchConditionsExpression(ValueExpression Untyped) : TypedValueExpression<MatchConditions>(Untyped)
    {
        public TypedValueExpression IfMatch => new(new CSharpType(typeof(ETag), true), Property(nameof(MatchConditions.IfMatch)));
        public TypedValueExpression IfNoneMatch => new(new CSharpType(typeof(ETag), true), Property(nameof(MatchConditions.IfNoneMatch)));
    }
}
