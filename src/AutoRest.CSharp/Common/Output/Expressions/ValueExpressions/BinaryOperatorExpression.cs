// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record BinaryOperatorExpression(string Operator, ValueExpression Left, ValueExpression Right) : ValueExpression
    {
        public override void Write(CodeWriter writer)
        {
            writer.AppendRaw("(");
            Left.Write(writer);
            writer.AppendRaw(" ").AppendRaw(Operator).AppendRaw(" ");
            Right.Write(writer);
            writer.AppendRaw(")");
        }
    }
}
