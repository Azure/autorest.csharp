// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ResponseOfTExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Response<>), Untyped)
    {
    }
}
