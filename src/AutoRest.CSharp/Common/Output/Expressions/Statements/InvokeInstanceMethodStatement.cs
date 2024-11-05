// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record InvokeInstanceMethodStatement(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, bool CallAsAsync, bool AddConfigureAwaitFalse = true) : MethodBodyStatement
    {
        public InvokeInstanceMethodStatement(ValueExpression? instance, string methodName) : this(instance, methodName, Array.Empty<ValueExpression>(), false) { }
        public InvokeInstanceMethodStatement(ValueExpression? instance, string methodName, ValueExpression arg) : this(instance, methodName, new[] { arg }, false) { }
        public InvokeInstanceMethodStatement(ValueExpression? instance, string methodName, ValueExpression arg1, ValueExpression arg2) : this(instance, methodName, new[] { arg1, arg2 }, false) { }
        public InvokeInstanceMethodStatement(ValueExpression? instance, string methodName, ValueExpression arg1, ValueExpression arg2, ValueExpression arg3) : this(instance, methodName, new[] { arg1, arg2, arg3 }, false) { }

        public InvokeInstanceMethodStatement(InvokeInstanceMethodExpression expression) : this(expression.InstanceReference, expression.MethodName, expression.Arguments, expression.CallAsAsync, expression.AddConfigureAwaitFalse) { }

        public sealed override void Write(CodeWriter writer)
        {
            new InvokeInstanceMethodExpression(InstanceReference, MethodName, Arguments, null, CallAsAsync, AddConfigureAwaitFalse).Write(writer);
            writer.LineRaw(";");
        }
    }
}
