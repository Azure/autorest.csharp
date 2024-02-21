﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class InvokeOptional
        {
            public static BoolExpression IsCollectionDefined(TypedValueExpression collection)
            {
                CodeWriterDeclaration collectionDeclaration = new("collection");
                CSharpType collectionType = new(collection.Type.Arguments.Count == 1 ? Configuration.ApiTypes.ChangeTrackingListType : Configuration.ApiTypes.ChangeTrackingDictionaryType, collection.Type.Arguments);
                VariableReference collectionReference = new VariableReference(collectionType, collectionDeclaration);
                DeclarationExpression collectionDeclarationExpression = new(collectionReference, false);
                return Not(BoolExpression.Is(collection, collectionDeclarationExpression)
                    .And(new MemberExpression(collectionReference, "IsUndefined")));
            }
            public static BoolExpression IsDefined(ValueExpression value) => new(new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalIsDefinedName, new[] { value }));
            public static ValueExpression ToDictionary(ValueExpression dictionary) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToDictionaryName, new[] { dictionary });
            public static ValueExpression ToList(ValueExpression collection) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToListName, new[] { collection });
            public static ValueExpression ToNullable(ValueExpression optional) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToNullableName, new[] { optional });

            public static MethodBodyStatement WrapInIsDefined(PropertySerialization serialization, MethodBodyStatement statement, bool forceCheck = false)
            {
                if (!forceCheck && serialization.IsRequired)
                {
                    return statement;
                }

                return TypeFactory.IsCollectionType(serialization.Value.Type) && !TypeFactory.IsReadOnlyMemory(serialization.Value.Type)
                    ? new IfStatement(IsCollectionDefined(serialization.Value)) { statement }
                    : new IfStatement(IsDefined(serialization.Value)) { statement };
            }

            public static MethodBodyStatement WrapInIsNotEmpty(PropertySerialization serialization, MethodBodyStatement statement)
            {
                return TypeFactory.IsCollectionType(serialization.Value.Type) && !TypeFactory.IsReadOnlyMemory(serialization.Value.Type)
                    ? new IfStatement(new BoolExpression(InvokeStaticMethodExpression.Extension(typeof(Enumerable), nameof(Enumerable.Any), serialization.Value))) { statement }
                    : statement;
            }
        }
    }
}
