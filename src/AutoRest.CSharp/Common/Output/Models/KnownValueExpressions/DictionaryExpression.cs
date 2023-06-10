// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record DictionaryExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Dictionary<,>), Untyped)
    {
        public static DictionaryExpression New(CSharpType listType) => new(Snippets.New(listType));

        public MethodBodyStatement Add(ValueExpression key, ValueExpression value)
            => new InvokeInstanceMethodStatement(Untyped, nameof(Dictionary<object, object>.Add), key, value);
    }
}
