// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record RawRequestUriBuilderExpression(ValueExpression Untyped) : BaseRawRequestUriBuilderExpression(typeof(RawRequestUriBuilder), Untyped)
    {
        protected override Type RequestUriBuilderExtensionsType => typeof(RequestUriBuilderExtensions);
    }
}
