// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record EnumExpression(EnumType EnumType, ValueExpression Untyped) : TypedValueExpression(EnumType.Type, Untyped)
    {
        public ValueExpression InvokeToString()
            => EnumType.IsExtensible
                ? new InvokeInstanceMethodExpression(Untyped, nameof(object.ToString))
                : new InvokeStaticMethodExpression(EnumType.Type, $"ToSerial{EnumType.ValueType.Name.FirstCharToUpperCase()}", new[]{Untyped}, null, true);
    }
}
