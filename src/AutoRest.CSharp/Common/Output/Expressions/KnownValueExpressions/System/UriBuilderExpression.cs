// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record UriBuilderExpression(ValueExpression Untyped) : BaseRawRequestUriBuilderExpression(typeof(UriBuilder), Untyped)
    {
        protected override Type RequestUriBuilderExtensionsType => typeof(UriBuilder);
    }
}
