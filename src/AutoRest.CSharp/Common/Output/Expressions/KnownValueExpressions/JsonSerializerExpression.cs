// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal static class JsonSerializerExpression
    {
        public static InvokeStaticMethodStatement Serialize(ValueExpression writer, ValueExpression value)
            => new InvokeStaticMethodStatement(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), new[] { writer, value });

        public static MethodBodyStatement Serialize(ValueExpression writer, ValueExpression value, ValueExpression options)
            => new InvokeStaticMethodStatement(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), new[] { writer, value, options });

        public static ValueExpression Deserialize(JsonElementExpression element, CSharpType serializationType, ValueExpression? options = null)
        {
            var arguments = options is null
                ? new[] { element.GetRawText() }
                : new[] { element.GetRawText(), options };
            return new InvokeStaticMethodExpression(typeof(JsonSerializer), nameof(JsonSerializer.Deserialize), arguments, new[] { serializationType });
        }
    }
}
