// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record DeclarationExpression(VariableReference Variable, bool IsOut) : ValueExpression
    {
        public DeclarationExpression(CSharpType type, string name, out VariableReference variable, bool isOut = false) : this(new VariableReference(type, name), isOut)
        {
            variable = Variable;
        }

        public sealed override void Write(CodeWriter writer)
        {
            writer.AppendRawIf("out ", IsOut);
            writer.Append($"{Variable.Type} {Variable.Declaration:D}");
        }
    }
}
