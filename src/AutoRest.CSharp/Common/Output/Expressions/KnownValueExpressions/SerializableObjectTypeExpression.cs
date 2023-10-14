// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record SerializableObjectTypeExpression(SerializableObjectType ObjectType, ValueExpression Untyped) : TypedValueExpression(ObjectType.Type, Untyped)
    {
        public static MemberExpression FromResponseDelegate(SerializableObjectType serializableObjectType)
            => new(new TypeReference(serializableObjectType.Type), "FromResponse");

        public static MemberExpression DeserializeDelegate(SerializableObjectType serializableObjectType)
            => new(new TypeReference(serializableObjectType.Type), $"Deserialize{serializableObjectType.Declaration.Name}");

        public static SerializableObjectTypeExpression FromResponse(SerializableObjectType serializableObjectType, ResponseExpression response)
            => new(serializableObjectType, new InvokeStaticMethodExpression(serializableObjectType.Type, "FromResponse", new[] { response }));

        public static SerializableObjectTypeExpression Deserialize(SerializableObjectType serializableObjectType, ValueExpression element, ValueExpression options)
            => new(serializableObjectType, new InvokeStaticMethodExpression(serializableObjectType.Type, $"Deserialize{serializableObjectType.Declaration.Name}", new[] { element, options }));

        public RequestContentExpression ToRequestContent() => new(Untyped.Invoke("ToRequestContent"));

    }
}
