// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class InvokeOptional
        {
            public static BoolExpression IsCollectionDefined(ValueExpression collection) => new(new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalIsCollectionDefinedName, new[]{collection}));
            public static BoolExpression IsDefined(ValueExpression value) => new(new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalIsDefinedName, new[]{value}));
            public static ValueExpression ToDictionary(ValueExpression dictionary) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToDictionaryName, new[]{dictionary});
            public static ValueExpression ToList(ValueExpression collection) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToListName, new[]{collection});
            public static ValueExpression ToNullable(ValueExpression optional) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToNullableName, new[]{optional});

            // TODO -- maybe remove this?
            public static MethodBodyStatement WrapInIsDefined(PropertySerialization serialization, MethodBodyStatement statement)
            {
                if (serialization.IsRequired)
                {
                    return statement;
                }

                return TypeFactory.IsCollectionType(serialization.Value.Type)
                    ? new IfStatement(IsCollectionDefined(serialization.Value)) {statement}
                    : new IfStatement(IsDefined(serialization.Value)) {statement};
            }

            public static MethodBodyStatement WrapInJsonAndIsDefined(PropertySerialization serialization, BoolExpression formatCheckCondition, MethodBodyStatement statement)
            {
                // we have two conditions here, they may or may not exist.
                // first is if ShouldExcludeInWireSerialization, we need a formatCheckCondition
                // second is if the property is optional, we need a IsDefined condition
                // if we have none, return the statement without wrapping it around a if statement
                // if we only have one of the condition, we wrap the statement using a if statement
                // if we have both, we wrap the statement using a if statement with the condition of (first && second)
                BoolExpression? condition = null;
                if (serialization.ShouldExcludeInWireSerialization)
                {
                    condition = formatCheckCondition;
                }
                if (!serialization.IsRequired)
                {
                    var optionalCondition = BuildOptionalCondition(serialization);
                    if (condition == null)
                    {
                        condition = optionalCondition;
                    }
                    else
                    {
                        condition = And(condition, optionalCondition);
                    }
                }

                return condition == null
                    ? statement
                    : new IfStatement(condition) { statement };
            }

            private static BoolExpression BuildOptionalCondition(PropertySerialization serialization)
                => TypeFactory.IsCollectionType(serialization.Value.Type)
                            ? IsCollectionDefined(serialization.Value)
                            : IsDefined(serialization.Value);
        }
    }
}
