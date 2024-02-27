// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Text.Json;
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

            public static BoolExpression IsDefined(TypedValueExpression value)
            {
                switch (value)
                {
                    case { Type: { Name: nameof(JsonElement) } }:
                        return NotEqual(new MemberExpression(value, nameof(JsonElement.ValueKind)), FrameworkEnumValue(JsonValueKind.Undefined));
                    case { Type: { IsNullable: true, IsValueType: true } }:
                        return new BoolExpression(new MemberExpression(value, "HasValue"));
                    default:
                        return NotEqual(value, Null);
                }
            }

            public static ValueExpression FallBackToChangeTrackingCollection(TypedValueExpression collection)
            {
                if (!TypeFactory.IsCollectionType(collection.Type) || TypeFactory.IsReadOnlyMemory(collection.Type))
                {
                    return collection;
                }

                var collectionType = collection.Type.Arguments.Count == 1 ? Configuration.ApiTypes.ChangeTrackingListType : Configuration.ApiTypes.ChangeTrackingDictionaryType;
                var changeTrackingType = new CSharpType(collectionType, collection.Type.Arguments);
                return NullCoalescing(collection, New.Instance(changeTrackingType));
            }

            public static ValueExpression ToNullable(ValueExpression optional) => new InvokeStaticMethodExpression(Configuration.ApiTypes.OptionalType, Configuration.ApiTypes.OptionalToNullableName, new[] { optional });

            public static MethodBodyStatement WrapInIsDefined(PropertySerialization serialization, MethodBodyStatement statement, bool isBicep = false)
            {
                //bicep shares its serialization types with JsonSerialization so we need the additional bool to know if we are serializing bicep.
                //if we are serializing bicep, we don't need to check if the property is required
                if (!isBicep && serialization.IsRequired)
                {
                    return statement;
                }

                if (!serialization.Value.Type.IsNullable && serialization.Value.Type.IsValueType)
                {
                    if (!serialization.Value.Type.Equals(typeof(JsonElement)))
                    {
                        return statement;
                    }
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
