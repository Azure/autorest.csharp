// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record NewInstanceExpression(CSharpType Type, IReadOnlyList<ValueExpression> Arguments, IReadOnlyDictionary<string, ValueExpression>? Properties = null) : ValueExpression;
}
