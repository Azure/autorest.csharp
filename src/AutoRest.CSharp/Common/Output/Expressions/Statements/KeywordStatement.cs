// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record KeywordStatement(string Keyword, ValueExpression? Expression) : MethodBodyStatement
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.AppendRaw(Keyword);
            if (Expression is not null)
            {
                writer.AppendRaw(" ");
                Expression.Write(writer);
            }
            writer.LineRaw(";");
        }
    }
}
