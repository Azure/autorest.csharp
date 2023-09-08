// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record EnumExpression(EnumType EnumType, ValueExpression Untyped) : TypedValueExpression(EnumType.Type, Untyped)
    {
        public StringExpression ToSerial()
            => EnumType.SerializationMethod is {} serializationMethod
                ? EnumType.IsExtensible
                    ? new StringExpression(Untyped.Invoke(serializationMethod.Signature.Name))
                    : new StringExpression(new InvokeStaticMethodExpression(EnumType.Type, serializationMethod.Signature.Name, new[]{Untyped}, null, true))
                : Untyped.InvokeToString();

        public static ValueExpression ToEnum(EnumType enumType, ValueExpression value)
            => enumType.IsExtensible
                ? Snippets.New.Instance(enumType.Type, value)
                : new InvokeStaticMethodExpression(enumType.Type, $"To{enumType.Declaration.Name}", new[]{value}, null, true);
    }
}
