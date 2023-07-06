// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record CancellationTokenExpression(ValueExpression Untyped) : TypedValueExpression(typeof(CancellationToken), Untyped)
    {
        public static CancellationTokenExpression KnownParameter { get; } = new(KnownParameters.CancellationTokenParameter);
        public ValueExpression CanBeCanceled { get; } = new MemberExpression(Untyped, nameof(CancellationToken.CanBeCanceled));
    }
}
