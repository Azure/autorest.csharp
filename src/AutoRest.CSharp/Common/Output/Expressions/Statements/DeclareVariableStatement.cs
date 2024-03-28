// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record DeclareVariableStatement(CSharpType? Type, CodeWriterDeclaration Name, ValueExpression Value) : MethodBodyStatement
    {
        public sealed override void Write(CodeWriter writer)
        {
            if (Type != null)
            {
                writer.Append($"{Type}");
            }
            else
            {
                writer.AppendRaw("var");
            }

            writer.Append($" {Name:D} = ");
            Value.Write(writer);
            writer.LineRaw(";");
        }
    }
}
