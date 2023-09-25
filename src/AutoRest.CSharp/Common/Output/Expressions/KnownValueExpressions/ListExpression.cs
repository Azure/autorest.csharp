﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record ListExpression(ValueExpression Untyped) : TypedValueExpression(typeof(List<>), Untyped)
    {
        public MethodBodyStatement Add(ValueExpression item) => new InvokeInstanceMethodStatement(Untyped, nameof(List<object>.Add), item);
    }
}
