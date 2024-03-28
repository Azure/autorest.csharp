// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record TernaryConditionalOperator(ValueExpression Condition, ValueExpression Consequent, ValueExpression Alternative) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            Condition.Write(writer);
            writer.AppendRaw(" ? ");
            Consequent.Write(writer);
            writer.AppendRaw(" : ");
            Alternative.Write(writer);
        }
    }
}
