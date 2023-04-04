// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record RequestExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Request), Untyped)
    {
        public RequestContentExpression Content => new(new MemberReference(Untyped, nameof(Request.Content)));
    }
}
