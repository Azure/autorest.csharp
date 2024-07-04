// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record IntExpression(ValueExpression Untyped) : TypedValueExpression<int>(Untyped)
    {
        public static IntExpression MaxValue => new(StaticProperty(nameof(int.MaxValue)));

        public IntExpression Add(IntExpression value) => Operator("+", value);
        public IntExpression Minus(IntExpression value) => Operator("-", value);
        public IntExpression Multiply(IntExpression value) => Operator("*", value);
        public IntExpression DivideBy(IntExpression value) => Operator("/", value);

        public static IntExpression operator +(IntExpression left, IntExpression right) => left.Add(right);
        public static IntExpression operator -(IntExpression left, IntExpression right) => left.Minus(right);
        public static IntExpression operator *(IntExpression left, IntExpression right) => left.Multiply(right);
        public static IntExpression operator /(IntExpression left, IntExpression right) => left.DivideBy(right);

        private IntExpression Operator(string op, IntExpression other) => new(new BinaryOperatorExpression(op, this, other));
    }
}
