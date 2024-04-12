// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static ValueExpression GetConversion(this ValueExpression expression, CSharpType from, CSharpType to)
        {
            if (CSharpType.RequiresToList(from, to))
            {
                if (from.IsNullable)
                    expression = new NullConditionalExpression(expression);
                return new InvokeStaticMethodExpression(typeof(Enumerable), nameof(Enumerable.ToList), new[] { expression }, CallAsExtension: true);
            }

            // null value cannot directly assign to extensible enum from string, because it invokes the implicit operator from string which invokes the ctor, and the ctor does not allow the value to be null
            if (RequiresNullCheckForExtensibleEnum(from, to))
            {
                expression = new TernaryConditionalOperator(
                    Equal(expression, Null),
                    to.IsNullable ? Null.CastTo(to) : Default.CastTo(to),
                    New.Instance(to, expression));
            }

            return expression;
        }

        /// <summary>
        /// null value cannot directly assign to extensible enum from string, because it invokes the implicit operator from string which invokes the ctor, and the ctor does not allow the value to be null
        /// This method checks if we need an explicitly null check
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static bool RequiresNullCheckForExtensibleEnum(CSharpType from, CSharpType to)
        {
            return from is { IsFrameworkType: true, FrameworkType: { } frameworkType } && frameworkType == typeof(string)
                && to is { IsFrameworkType: false, Implementation: EnumType { IsExtensible: true } };
        }

        internal static MethodBodyStatement Increment(ValueExpression value) => new UnaryOperatorStatement(new UnaryOperatorExpression("++", value, true));

        public static class InvokeConvert
        {
            public static ValueExpression ToDouble(StringExpression value) => new InvokeStaticMethodExpression(typeof(Convert), nameof(Convert.ToDouble), Arguments: new[] { value });
            public static ValueExpression ToInt32(StringExpression value) => new InvokeStaticMethodExpression(typeof(Convert), nameof(Convert.ToInt32), Arguments: new[] { value });
        }
    }
}
