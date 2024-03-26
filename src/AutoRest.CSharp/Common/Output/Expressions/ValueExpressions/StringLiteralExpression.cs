// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record StringLiteralExpression(string Literal, bool U8) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.Literal(Literal);
            if (U8)
            {
                writer.AppendRaw("u8");
            }
        }
    }
}
