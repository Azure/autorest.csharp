// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ResponseWithHeadersExpression(ValueExpression Untyped) : TypedValueExpression(typeof(ResponseWithHeaders<,>), Untyped)
    {
        public static ResponseWithHeadersExpression FromValue(ValueExpression value, ValueExpression headers, ResponseExpression response)
            => new(new InvokeStaticMethodExpression(typeof(ResponseWithHeaders), nameof(ResponseWithHeaders.FromValue), new[]{ value, headers, response }));

        public static ResponseWithHeadersExpression FromValue(CSharpType explicitValueType, ValueExpression value, ValueExpression headers, ResponseExpression response)
            => new(new InvokeStaticMethodExpression(typeof(ResponseWithHeaders), nameof(ResponseWithHeaders.FromValue), new[]{ value, headers, response }, new[]{ explicitValueType }));

        public static ResponseWithHeadersExpression FromValue(ValueExpression headers, ResponseExpression response)
            => new(new InvokeStaticMethodExpression(typeof(ResponseWithHeaders), nameof(ResponseWithHeaders.FromValue), new[]{ headers, response }));
    }
}
