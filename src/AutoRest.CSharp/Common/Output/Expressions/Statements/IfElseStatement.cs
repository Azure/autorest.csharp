// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record IfElseStatement(IfStatement If, MethodBodyStatement? Else) : MethodBodyStatement
    {
        public IfElseStatement(BoolExpression condition, MethodBodyStatement ifStatement, MethodBodyStatement? elseStatement, bool inline = false, bool addBraces = true)
            : this(new IfStatement(condition, inline, addBraces) { ifStatement }, elseStatement) { }

        public sealed override void Write(CodeWriter writer)
        {
            If.Write(writer);
            if (Else is null)
            {
                return;
            }

            if (If.Inline || !If.AddBraces)
            {
                using (writer.AmbientScope())
                {
                    writer.AppendRaw("else ");
                    if (!If.Inline)
                    {
                        writer.Line();
                    }
                    Else.Write(writer);
                }
            }
            else
            {
                using (writer.Scope($"else"))
                {
                    Else.Write(writer);
                }
            }
        }
    }
}
