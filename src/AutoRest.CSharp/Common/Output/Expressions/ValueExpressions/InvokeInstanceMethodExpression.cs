// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    // [TODO]: AddConfigureAwaitFalse is needed only in docs. Consider removing.
    internal record InvokeInstanceMethodExpression(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, IReadOnlyList<CSharpType>? TypeArguments, bool CallAsAsync, bool AddConfigureAwaitFalse = true) : ValueExpression;
}
