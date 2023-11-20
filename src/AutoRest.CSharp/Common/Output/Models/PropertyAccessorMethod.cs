// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal class PropertyAccessorMethod : MethodBase
    {
        public MethodSignatureModifiers Modifiers { get; }
        public bool IsInline => BodyExpression == null && Body == null;

        public PropertyAccessorMethod(MethodSignatureModifiers modifiers)
        {
            Modifiers = modifiers;
        }

        public PropertyAccessorMethod(MethodSignatureModifiers modifiers, ValueExpression expression) : this(modifiers)
        {
            BodyExpression = expression;
        }

        public PropertyAccessorMethod(ValueExpression expression) : this(MethodSignatureModifiers.None)
        {
            BodyExpression = expression;
        }

        public PropertyAccessorMethod(MethodSignatureModifiers modifiers, MethodBodyStatement body) : this(modifiers)
        {
            Body = body;
        }

        public PropertyAccessorMethod(MethodBodyStatement body) : this(MethodSignatureModifiers.None)
        {
            Body = body;
        }
    }
}
