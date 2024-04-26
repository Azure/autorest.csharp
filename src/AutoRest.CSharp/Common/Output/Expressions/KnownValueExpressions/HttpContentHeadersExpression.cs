// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http.Headers;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record HttpContentHeadersExpression(ValueExpression Untyped) : TypedValueExpression<HttpContentHeaders>(Untyped)
    {
        public ValueExpression ContentType => Property(nameof(HttpContentHeaders.ContentType));
        public ValueExpression ContentLength => Property(nameof(HttpContentHeaders.ContentLength));
        public ValueExpression ContentDisposition => Property(nameof(HttpContentHeaders.ContentDisposition));
    }
}
