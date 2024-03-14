// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class InvokeBicep
        {
            public static InvokeStaticMethodStatement AppendChildObject(
                ValueExpression stringBuilder,
                ValueExpression expression,
                ConstantExpression spaces,
                BoolExpression isArrayElement,
                StringExpression formattedPropertyName)
            {
                return BicepSerializationTypeProvider.Instance.AppendChildObject(stringBuilder, expression, spaces, isArrayElement, formattedPropertyName);
            }
        }
    }
}
