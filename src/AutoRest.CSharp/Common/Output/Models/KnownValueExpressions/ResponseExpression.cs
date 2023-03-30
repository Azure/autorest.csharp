// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ResponseExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Response), Untyped)
    {
        public static ResponseExpression<T> FromValue<T>(T valueExpression, ResponseExpression response) where T : TypedValueExpression
        {
            return new ResponseExpression<T>(new StaticMethodCallExpression(typeof(Response), nameof(Response.FromValue), new ValueExpression[]{valueExpression, response}));
        }
    }
}
