// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record CastExpression(ValueExpression Inner, CSharpType Type) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            // wrap the cast expression with parenthesis, so that it would not cause ambiguity for leading recursive calls
            // if the parenthesis are not needed, the roslyn reducer will remove it.
            writer.AppendRaw("(");
            writer.Append($"({Type})");
            Inner.Write(writer);
            writer.AppendRaw(")");
        }
    }
}
