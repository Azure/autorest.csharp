// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record CatchStatement(ValueExpression? Exception, MethodBodyStatement Body)
    {
        public void Write(CodeWriter writer)
        {
            writer.AppendRaw("catch");
            if (Exception != null)
            {
                writer.AppendRaw(" (");
                Exception.Write(writer);
                writer.AppendRaw(")");
            }
            writer.LineRaw("{");
            Body.Write(writer);
            writer.LineRaw("}");
        }
    }
}
