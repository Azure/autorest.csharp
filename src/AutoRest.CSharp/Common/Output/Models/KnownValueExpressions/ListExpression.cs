// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ListExpression(ValueExpression Untyped) : TypedValueExpression(typeof(List<>), Untyped)
    {
        public static ListExpression New(CSharpType listType) => new(Snippets.New(listType));
        public MethodBodyStatement Add(ValueExpression item) => new InvokeInstanceMethodStatement(Untyped, nameof(List<object>.Add), item);
    }
}
