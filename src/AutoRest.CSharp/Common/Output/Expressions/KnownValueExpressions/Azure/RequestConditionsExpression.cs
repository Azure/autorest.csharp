// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record RequestConditionsExpression(ValueExpression Untyped) : TypedValueExpression<RequestConditions>(Untyped)
    {
        public TypedValueExpression IfMatch => new(new CSharpType(typeof(ETag), true), Property(nameof(RequestConditions.IfMatch)));

        public TypedValueExpression IfNoneMatch => new(new CSharpType(typeof(ETag), true),Property(nameof(RequestConditions.IfNoneMatch)));

        public TypedValueExpression IfModifiedSince => new(new CSharpType(typeof(DateTimeOffset), true), Property(nameof(RequestConditions.IfModifiedSince)));

        public TypedValueExpression IfUnmodifiedSince => new(new CSharpType(typeof(DateTimeOffset), true), Property(nameof(RequestConditions.IfUnmodifiedSince)));
    }
}
