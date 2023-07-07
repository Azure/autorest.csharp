// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record NewDictionaryExpression(CSharpType Type, IReadOnlyList<(ValueExpression Key, ValueExpression Value)>? Values = null) : ValueExpression;
}
