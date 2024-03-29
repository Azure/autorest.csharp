// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record TypeReference(CSharpType Type) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.Append($"{Type}");
        }
    }
}
