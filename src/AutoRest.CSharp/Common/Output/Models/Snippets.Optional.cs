// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class InvokeOptional
        {
            public static BoolExpression IsCollectionDefined(ValueExpression collection) => new(new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.IsCollectionDefined), new[]{collection}));
            public static BoolExpression IsDefined(ValueExpression value) => new(new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.IsDefined), new[]{value}));
            public static ValueExpression ToDictionary(ValueExpression dictionary) => new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.ToDictionary), new[]{dictionary});
            public static ValueExpression ToList(ValueExpression collection) => new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.ToList), new[]{collection});
            public static ValueExpression ToNullable(ValueExpression optional) => new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.ToNullable), new[]{optional});

            public static MethodBodyStatement WrapInIsDefined(PropertySerialization serialization, MethodBodyStatement statement)
            {
                if (serialization.IsRequired)
                {
                    return statement;
                }

                return TypeFactory.IsCollectionType(serialization.ValueType)
                    ? new IfElseStatement(IsCollectionDefined(serialization.Value), statement, null)
                    : new IfElseStatement(IsDefined(serialization.Value), statement, null);
            }
        }
    }
}
