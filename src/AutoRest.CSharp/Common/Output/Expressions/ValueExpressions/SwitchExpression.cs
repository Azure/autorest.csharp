// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record SwitchExpression(ValueExpression MatchExpression, params SwitchCaseExpression[] Cases) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            using (writer.AmbientScope())
            {
                MatchExpression.Write(writer);
                writer.LineRaw(" switch");
                writer.LineRaw("{");
                foreach (var switchCase in Cases)
                {
                    switchCase.Case.Write(writer);
                    writer.AppendRaw(" => ");
                    switchCase.Expression.Write(writer);
                    writer.LineRaw(",");
                }
                writer.RemoveTrailingComma();
                writer.Line();
                writer.AppendRaw("}");
            }
        }
    }
}
