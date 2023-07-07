// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record NewArrayExpression(CSharpType? Type, IReadOnlyList<ValueExpression>? Items = null, bool IsInline = false) : ValueExpression;
}
