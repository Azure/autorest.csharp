// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record ThrowStatement(ValueExpression ThrowExpression) : MethodBodyStatement
    {
        public sealed override void Write(CodeWriter writer)
        {
            ThrowExpression.Write(writer);
            writer.LineRaw(";");
        }
    }
}
