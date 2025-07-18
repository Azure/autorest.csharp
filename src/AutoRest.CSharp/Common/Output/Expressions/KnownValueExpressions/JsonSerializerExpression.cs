﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal static class JsonSerializerExpression
    {
        public static InvokeStaticMethodExpression Serialize(ValueExpression writer, ValueExpression value, ValueExpression? options = null)
        {
            var arguments = options is null
                ? new[] { writer, value }
                : new[] { writer, value, options };
            return new InvokeStaticMethodExpression(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), arguments);
        }

        public static InvokeStaticMethodExpression Deserialize(JsonElementExpression element, CSharpType serializationType)
            => new InvokeStaticMethodExpression(typeof(JsonSerializer), nameof(JsonSerializer.Deserialize), [element.GetRawText()], [serializationType]);
    }
}
