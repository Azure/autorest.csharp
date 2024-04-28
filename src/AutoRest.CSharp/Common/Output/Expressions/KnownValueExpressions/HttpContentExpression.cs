// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using System;

using System.Net.Http;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record HttpContentExpression(ValueExpression Untyped): TypedValueExpression<HttpContent>(Untyped)
    {
        public HttpContentHeadersExpression Headers => new HttpContentHeadersExpression(Property(nameof(HttpContent.Headers)));
    }
}
