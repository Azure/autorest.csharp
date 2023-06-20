// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record StringRequestContentExpression(ValueExpression Untyped) : TypedValueExpression(typeof(StringRequestContent), Untyped);
}
