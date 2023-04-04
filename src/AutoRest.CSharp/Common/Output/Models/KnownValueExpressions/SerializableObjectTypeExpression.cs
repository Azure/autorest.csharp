// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record SerializableObjectTypeExpression(SerializableObjectType ObjectType, ValueExpression Untyped) : TypedValueExpression(ObjectType.Type, Untyped)
    {
        public static ValueExpression FromResponseDelegate(SerializableObjectType serializableObjectType)
            => new MemberReference(new TypeReference(serializableObjectType.Type), "FromResponse");

        public static ValueExpression DeserializeDelegate(SerializableObjectType serializableObjectType)
            => new MemberReference(new TypeReference(serializableObjectType.Type), $"Deserialize{serializableObjectType.Declaration.Name}");

        public static SerializableObjectTypeExpression FromResponse(SerializableObjectType serializableObjectType, ResponseExpression response)
            => new(serializableObjectType, new InvokeStaticMethodExpression(serializableObjectType.Type, "FromResponse", new[]{ response }));

        public static SerializableObjectTypeExpression Deserialize(SerializableObjectType serializableObjectType, JsonElementExpression element)
            => new(serializableObjectType, new InvokeStaticMethodExpression(serializableObjectType.Type, $"Deserialize{serializableObjectType.Declaration.Name}", new[]{element}));

        public RequestContentExpression ToRequestContent()
            => new(new InvokeInstanceMethodExpression(Untyped, "ToRequestContent", Array.Empty<ValueExpression>(), false));
    }
}
