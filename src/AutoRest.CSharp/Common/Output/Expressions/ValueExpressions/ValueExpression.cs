// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    internal record ValueExpression
    {
        public static implicit operator ValueExpression(Type type) => new TypeReference(type);
        public static implicit operator ValueExpression(CSharpType type) => new TypeReference(type);
        public static implicit operator ValueExpression(Parameter parameter) => new ParameterReference(parameter);
        public static implicit operator ValueExpression(FieldDeclaration name) => new VariableReference(name.Type, name.Declaration);

        public ValueExpression NullableStructValue(CSharpType candidateType) => this is not ConstantExpression && candidateType is { IsNullable: true, IsValueType: true } ? new MemberExpression(this, nameof(Nullable<int>.Value)) : this;
        public StringExpression InvokeToString() => new(Invoke(nameof(ToString)));

        public ValueExpression Invoke(string methodName)
            => new InvokeInstanceMethodExpression(this, methodName, Array.Empty<ValueExpression>(), null, false);

        public ValueExpression Invoke(string methodName, ValueExpression arg)
            => new InvokeInstanceMethodExpression(this, methodName, new[] { arg }, null, false);

        public ValueExpression Invoke(string methodName, ValueExpression arg1, ValueExpression arg2)
            => new InvokeInstanceMethodExpression(this, methodName, new[] { arg1, arg2 }, null, false);

        public ValueExpression Invoke(string methodName, IReadOnlyList<ValueExpression> arguments)
            => new InvokeInstanceMethodExpression(this, methodName, arguments, null, false);

        public ValueExpression Invoke(MethodSignature method)
            => new InvokeInstanceMethodExpression(this, method.Name, method.Parameters.Select(p => (ValueExpression)p).ToList(), null, false);

        public ValueExpression Invoke(MethodSignature method, bool async)
            => new InvokeInstanceMethodExpression(this, method.Name, method.Parameters.Select(p => (ValueExpression)p).ToList(), null, async);

        public ValueExpression Invoke(string methodName, bool async)
            => new InvokeInstanceMethodExpression(this, methodName, Array.Empty<ValueExpression>(), null, async);

        public ValueExpression Invoke(string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
            => new InvokeInstanceMethodExpression(this, methodName, arguments, null, async);

        private string GetDebuggerDisplay()
        {
            using var writer = new DebuggerCodeWriter();
            writer.WriteValueExpression(this);
            return writer.ToString();
        }
    }
}
