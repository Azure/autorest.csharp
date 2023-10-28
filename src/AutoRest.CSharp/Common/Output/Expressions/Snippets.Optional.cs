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
            public static BoolExpression IsCollectionDefined(ValueExpression collection) => new(new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalIsCollectionDefinedName, new[] { collection }));
            public static BoolExpression IsDefined(ValueExpression value) => new(new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalIsDefinedName, new[] { value }));
            public static ValueExpression ToDictionary(ValueExpression dictionary) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToDictionaryName, new[] { dictionary });
            public static ValueExpression ToList(ValueExpression collection) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToListName, new[] { collection });
            public static ValueExpression ToNullable(ValueExpression optional) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToNullableName, new[] { optional });

            public static MethodBodyStatement WrapInIsDefined(PropertySerialization serialization, MethodBodyStatement statement)
            {
                if (serialization.IsRequired || TypeFactory.IsReadOnlyMemory(serialization.Value.Type))
                {
                    return statement;
                }

                return TypeFactory.IsCollectionType(serialization.Value.Type)
                    ? new IfStatement(IsCollectionDefined(serialization.Value)) { statement }
                    : new IfStatement(IsDefined(serialization.Value)) { statement };
            }
        }
    }
}
