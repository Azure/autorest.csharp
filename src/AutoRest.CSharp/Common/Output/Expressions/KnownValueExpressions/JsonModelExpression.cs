// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal static class JsonModelExpression
    {
        public static InvokeInstanceMethodExpression Write(ValueExpression writer, ValueExpression value, ValueExpression? options = null)
        {
            var arguments = options is null
                ? new[] { writer, }
                : new[] { writer, options };
            return new InvokeInstanceMethodExpression(value, "Write", arguments, callAsAsync: false);
        }
    }
}
