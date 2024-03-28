// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record UnaryOperatorExpression(string Operator, ValueExpression Operand, bool OperandOnTheLeft) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.AppendRawIf(Operator, !OperandOnTheLeft);
            Operand.Write(writer);
            writer.AppendRawIf(Operator, OperandOnTheLeft);
        }
    }
}
