// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record IfElsePreprocessorDirective(string Condition, MethodBodyStatement If, MethodBodyStatement? Else) : MethodBodyStatement
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.Line($"#if {Condition}");
            writer.AppendRaw("\t\t\t\t");
            If.Write(writer);
            if (Else is not null)
            {
                writer.LineRaw("#else");
                Else.Write(writer);
            }

            writer.LineRaw("#endif");
        }
    }
}
