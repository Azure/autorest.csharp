// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    /// <summary>
    /// A wrapper around ValueExpression that also specifies return type of the expression
    /// Return type doesn't affect how expression is written, but help creating strong-typed helpers to create value expressions
    /// </summary>
    /// <param name="Type">Type expected to be returned by value expression</param>
    /// <param name="Untyped"></param>
    internal abstract record TypedValueExpression(CSharpType Type, ValueExpression Untyped) : ValueExpression
    {
        public static implicit operator TypedValueExpression(FieldDeclaration name) => new VariableReference(name.Type, name.Declaration);
        public static implicit operator TypedValueExpression(Parameter parameter) => new ParameterReference(parameter);

        protected MemberExpression Property(string name) => new(this, name);
        protected static MemberExpression StaticProperty(Type type, string name) => new(type, name);

        protected static ValueExpression ValidateType(TypedValueExpression typed, CSharpType type)
        {
            if (type.EqualsIgnoreNullable(typed.Type))
            {
                return typed.Untyped;
            }

            throw new InvalidOperationException($"Expression with return type {typed.Type.ToStringForDocs()} is cast to type {type.ToStringForDocs()}");
        }
    }

    internal abstract record TypedValueExpression<T>(ValueExpression Untyped) : TypedValueExpression(typeof(T), Untyped)
    {
        protected static InvokeStaticMethodExpression InvokeStatic(string methodName)
            => new InvokeStaticMethodExpression(typeof(T), methodName, Array.Empty<ValueExpression>(), null, false);

        protected static InvokeStaticMethodExpression InvokeStatic(string methodName, ValueExpression arg)
            => new InvokeStaticMethodExpression(typeof(T), methodName, new[]{arg}, null, false);

        protected static InvokeStaticMethodExpression InvokeStatic(string methodName, ValueExpression arg1, ValueExpression arg2)
            => new InvokeStaticMethodExpression(typeof(T), methodName, new[]{arg1, arg2}, null, false);

        protected static InvokeStaticMethodExpression InvokeStatic(string methodName, IReadOnlyList<ValueExpression> arguments)
            => new InvokeStaticMethodExpression(typeof(T), methodName, arguments, null, false);

        protected static InvokeStaticMethodExpression InvokeStatic(MethodSignature method)
            => new InvokeStaticMethodExpression(typeof(T), method.Name, method.Parameters.Select(p => (ValueExpression)p).ToList(), null, false);

        protected static InvokeStaticMethodExpression InvokeStatic(MethodSignature method, bool async)
            => new InvokeStaticMethodExpression(typeof(T), method.Name, method.Parameters.Select(p => (ValueExpression)p).ToList(), null, async);

        protected static InvokeStaticMethodExpression InvokeStatic(string methodName, bool async)
            => new InvokeStaticMethodExpression(typeof(T), methodName, Array.Empty<ValueExpression>(), null, async);

        protected static InvokeStaticMethodExpression InvokeStatic(string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
            => new InvokeStaticMethodExpression(typeof(T), methodName, arguments, null, async);
    }
}
