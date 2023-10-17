// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Internal;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record Utf8JsonRequestBodyExpression(ValueExpression Untyped) : BaseUtf8JsonRequestContentExpression(typeof(Utf8JsonRequestBody), Untyped)
    {
    }
}
