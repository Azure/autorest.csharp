// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record AssignmentExpression(VariableReference Variable, ValueExpression Value) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.Append($"{Variable.Type} {Variable.Declaration:D} = {Value}");
        }
    }
}
