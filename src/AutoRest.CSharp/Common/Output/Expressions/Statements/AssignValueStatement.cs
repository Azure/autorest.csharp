// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record AssignValueStatement(ValueExpression To, ValueExpression From) : MethodBodyStatement
    {
        public sealed override void Write(CodeWriter writer)
        {
            To.Write(writer);
            writer.AppendRaw(" = ");
            From.Write(writer);
            writer.LineRaw(";");
        }
    }
}
