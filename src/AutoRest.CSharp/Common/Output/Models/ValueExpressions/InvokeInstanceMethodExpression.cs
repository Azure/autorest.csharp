// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record InvokeInstanceMethodExpression(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, bool CallAsAsync) : ValueExpression
    {
        public InvokeInstanceMethodExpression(ValueExpression instance, string methodName) : this(instance, methodName, Array.Empty<ValueExpression>(), false) {}
    }
}
