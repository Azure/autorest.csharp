// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record BinaryOperatorExpression(string Operator, ValueExpression Left, ValueExpression Right) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            // we should always write parenthesis around this expression since some or the logic operator has lower priority, and we might get trouble when there is a chain of binary operator expression, for instance (a || b) && c.
            writer.AppendRaw("(");
            Left.Write(writer);
            writer.AppendRaw(" ").AppendRaw(Operator).AppendRaw(" ");
            Right.Write(writer);
            writer.AppendRaw(")");
        }
    }
}
