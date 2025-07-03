// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record IfElsePreprocessorExpression(string Condition, ValueExpression If, ValueExpression Else) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.Line($"#if {Condition}");
            writer.AppendRaw("\t\t\t\t");
            If.Write(writer);
            writer.Line();
            writer.LineRaw("#else");
            writer.AppendRaw("\t\t\t\t");
            Else.Write(writer);
            writer.Line();
            writer.LineRaw("#endif");
        }
    }
}
