// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record Utf8JsonRequestContentExpression(ValueExpression Untyped) : BaseUtf8JsonRequestContentExpression(typeof(Utf8JsonRequestContent), Untyped)
    {
    }
}
