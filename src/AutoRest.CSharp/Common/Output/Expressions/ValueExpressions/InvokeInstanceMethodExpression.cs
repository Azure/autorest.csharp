// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    // [TODO]: AddConfigureAwaitFalse is needed only in docs. Consider removing.
    internal record InvokeInstanceMethodExpression(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, IReadOnlyList<CSharpType>? TypeArguments, bool CallAsAsync, bool AddConfigureAwaitFalse = true) : ValueExpression
    {
        public InvokeInstanceMethodExpression(ValueExpression? instanceReference, string methodName, IReadOnlyList<ValueExpression> arguments, bool callAsAsync) : this(instanceReference, methodName, arguments, null, callAsAsync) { }

        public InvokeInstanceMethodExpression(ValueExpression? instanceReference, MethodSignature signature, IReadOnlyList<ValueExpression> arguments, bool addConfigureAwaitFalse = true)
            : this(instanceReference, signature.Name, arguments, signature.GenericArguments, signature.Modifiers.HasFlag(MethodSignatureModifiers.Async), addConfigureAwaitFalse) { }

        public InvokeInstanceMethodExpression(ValueExpression? instanceReference, MethodSignature signature, bool addConfigureAwaitFalse = true)
            : this(instanceReference, signature, signature.Parameters.Select(p => (ValueExpression)p).ToArray(), addConfigureAwaitFalse) { }

        public MethodBodyStatement ToStatement()
            => new InvokeInstanceMethodStatement(InstanceReference, MethodName, Arguments, CallAsAsync);

        public sealed override void Write(CodeWriter writer)
        {
            writer.AppendRawIf("await ", CallAsAsync);
            if (InstanceReference != null)
            {
                InstanceReference.Write(writer);
                writer.AppendRaw(".");
            }

            writer.AppendRaw(MethodName);
            writer.WriteTypeArguments(TypeArguments);
            writer.WriteArguments(Arguments);
            writer.AppendRawIf(".ConfigureAwait(false)", CallAsAsync && AddConfigureAwaitFalse);
        }
    }
}
