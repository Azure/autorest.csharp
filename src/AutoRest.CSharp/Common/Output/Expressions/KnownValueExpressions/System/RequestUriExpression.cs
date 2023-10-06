// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest.Internal;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record RequestUriExpression(ValueExpression Untyped) : BaseRawRequestUriBuilderExpression(typeof(RequestUri), Untyped)
    {
        protected override Type RequestUriBuilderExtensionsType => typeof(RequestUri);
    }
}
