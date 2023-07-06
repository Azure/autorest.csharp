// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record NewInstanceExpression(CSharpType Type, IReadOnlyList<ValueExpression> Arguments, ObjectInitializerExpression? Properties = null) : ValueExpression;
    internal record NewArrayExpression(CSharpType Type, IReadOnlyList<ValueExpression>? Items = null) : ValueExpression;
    internal record NewDictionaryExpression(CSharpType Type, IReadOnlyList<(ValueExpression Key, ValueExpression Value)>? Values = null) : ValueExpression;

    internal record ObjectInitializerExpression(IReadOnlyDictionary<string, ValueExpression>? Properties = null, bool IsInline = true) : ValueExpression;
}
