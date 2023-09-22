// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base
{
    internal abstract record BaseResponseExpression(CSharpType Type, ValueExpression Untyped) : TypedValueExpression(Type, Untyped)
    {
        public abstract ValueExpression Status { get; }
        public abstract ValueExpression Value { get; }

        public abstract StreamExpression ContentStream { get; }
        public abstract BinaryDataExpression Content { get; }

        public abstract BaseResponseExpression GetRawResponse();

        public abstract BaseResponseExpression FromValue(ValueExpression value);
        public abstract BaseResponseExpression FromValue(CSharpType explicitValueType, ValueExpression value);

    }
}
