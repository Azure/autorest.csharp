// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record EnumExpression(EnumType EnumType, ValueExpression Untyped) : TypedValueExpression(EnumType.Type, Untyped)
    {
        public ValueExpression ToSerial()
            => EnumType.SerializationMethod is {} serializationMethod
                ? EnumType.IsExtensible
                    ? new InvokeInstanceMethodExpression(Untyped, serializationMethod.Signature.Name)
                    : new InvokeStaticMethodExpression(EnumType.Type, serializationMethod.Signature.Name, new[]{Untyped}, null, true)
                : new InvokeInstanceMethodExpression(Untyped, nameof(object.ToString));
    }
}
