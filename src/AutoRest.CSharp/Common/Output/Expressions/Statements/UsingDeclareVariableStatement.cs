// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record UsingDeclareVariableStatement(CSharpType? Type, CodeWriterDeclaration Name, ValueExpression Value) : MethodBodyStatement
    {
        public sealed override void Write(CodeWriter writer)
        {
            if (Type != null)
            {
                writer.Append($"using {Type}");
            }
            else
            {
                writer.AppendRaw("using var");
            }

            writer.Append($" {Name:D} = ");
            Value.Write(writer);
            writer.LineRaw(";");
        }
    }
}
