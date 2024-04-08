// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record ArrayElementExpression(ValueExpression Array, ValueExpression Index) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            Array.Write(writer);
            writer.AppendRaw("[");
            Index.Write(writer);
            writer.AppendRaw("]");
        }
    }
}
