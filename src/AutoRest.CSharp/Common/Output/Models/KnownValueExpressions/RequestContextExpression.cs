// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record RequestContextExpression(ValueExpression Untyped) : TypedValueExpression(typeof(RequestContext), Untyped)
    {
        public static Utf8JsonRequestContentExpression New(CancellationTokenExpression cancellationToken)
            => new(Snippets.New(typeof(RequestContext), new Dictionary<string, ValueExpression>{ [nameof(RequestContext.CancellationToken)] = cancellationToken }));

        public static RequestContextExpression FromCancellationToken()
            => new(new InvokeStaticMethodExpression(null, "FromCancellationToken", new ValueExpression[]{KnownParameters.CancellationTokenParameter}));
    }
}
