// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record EnumExpression(EnumType EnumType, ValueExpression Untyped) : TypedValueExpression(EnumType.Type, Untyped)
    {
        public StringExpression ToSerial()
            => EnumType.SerializationMethodName is {} serializationMethodName
                ? EnumType.IsExtensible
                    ? new StringExpression(Untyped.Invoke(serializationMethodName))
                    : new StringExpression(new InvokeStaticMethodExpression(EnumType.Type, serializationMethodName, new[]{Untyped}, null, true))
                : Untyped.InvokeToString();

        public static ValueExpression ToEnum(EnumType enumType, ValueExpression value)
            => enumType.IsExtensible
                ? Snippets.New.Instance(enumType.Type, value)
                : new InvokeStaticMethodExpression(enumType.Type, $"To{enumType.Declaration.Name}", new[]{value}, null, true);
    }
}
