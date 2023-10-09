// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record TypeReference(CSharpType Type) : ValueExpression
    {
        public ValueExpression InvokeStatic(string methodName)
            => new InvokeStaticMethodExpression(Type, methodName, Array.Empty<ValueExpression>(), null, false);

        public ValueExpression InvokeStatic(string methodName, ValueExpression arg)
            => new InvokeStaticMethodExpression(Type, methodName, new[] { arg }, null, false);

        public ValueExpression InvokeStatic(string methodName, ValueExpression arg1, ValueExpression arg2)
            => new InvokeStaticMethodExpression(Type, methodName, new[] { arg1, arg2 }, null, false);

        public ValueExpression InvokeStatic(string methodName, IReadOnlyList<ValueExpression> arguments)
            => new InvokeStaticMethodExpression(Type, methodName, arguments, null, false);

        public ValueExpression InvokeStatic(MethodSignature method)
            => new InvokeStaticMethodExpression(Type, method.Name, method.Parameters.Select(p => (ValueExpression)p).ToList(), null, method.Modifiers.HasFlag(MethodSignatureModifiers.Async));

        public ValueExpression InvokeStatic(MethodSignature method, IReadOnlyList<ValueExpression> arguments)
            => new InvokeStaticMethodExpression(Type, method.Name, arguments, null, method.Modifiers.HasFlag(MethodSignatureModifiers.Async));

        public ValueExpression InvokeStatic(string methodName, bool async)
            => new InvokeStaticMethodExpression(Type, methodName, Array.Empty<ValueExpression>(), null, async);

        public ValueExpression InvokeStatic(string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
            => new InvokeStaticMethodExpression(Type, methodName, arguments, null, async);
    }
}
