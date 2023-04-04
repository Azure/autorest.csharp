// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record InvokeInstanceMethodExpression(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, IReadOnlyList<CSharpType>? TypeArguments, bool CallAsAsync) : ValueExpression
    {
        public InvokeInstanceMethodExpression(ValueExpression? instance, string methodName) : this(instance, methodName, Array.Empty<ValueExpression>(), null, false) {}
        public InvokeInstanceMethodExpression(ValueExpression? instance, string methodName, ValueExpression arg) : this(instance, methodName, new[]{arg}, null, false) {}
    }
}
