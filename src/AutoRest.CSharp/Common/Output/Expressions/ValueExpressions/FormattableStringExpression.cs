// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal sealed record FormattableStringExpression(FormattableString literal) : ValueExpression;
}
