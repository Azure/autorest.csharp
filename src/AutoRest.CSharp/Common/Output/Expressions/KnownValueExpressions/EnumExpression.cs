// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record EnumExpression(EnumType EnumType, ValueExpression Untyped) : TypedValueExpression(EnumType.Type, Untyped)
    {
        public TypedValueExpression ToSerial()
            => EnumType.SerializationMethod is { Signature: MethodSignature { Name: var name, ReturnType: { IsFrameworkType: true } toType }}
                ? EnumType.IsExtensible
                    ? new FrameworkTypeExpression(toType.FrameworkType, Untyped.Invoke(name))
                    : new FrameworkTypeExpression(toType.FrameworkType, new InvokeStaticMethodExpression(EnumType.Type, name, new[] { Untyped }, null, true))
                : EnumType is { IsExtensible: true, IsStringValueType: true }
                    ? Untyped.InvokeToString()
                    : throw new InvalidOperationException($"No conversion available fom {EnumType.Type.ToStringForDocs()}");

        public static TypedValueExpression ToEnum(EnumType enumType, ValueExpression value)
            => enumType.IsExtensible
                ? new EnumExpression(enumType, Snippets.New.Instance(enumType.Type, value))
                : new EnumExpression(enumType, new InvokeStaticMethodExpression(enumType.Type, $"To{enumType.Declaration.Name}", new[] { value }, null, true));
    }
}
