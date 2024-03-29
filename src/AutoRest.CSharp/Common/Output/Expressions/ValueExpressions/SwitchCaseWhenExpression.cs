// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record SwitchCaseWhenExpression(ValueExpression Case, BoolExpression Condition) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            Case.Write(writer);
            writer.AppendRaw(" when ");
            Condition.Write(writer);
        }
    }
}
