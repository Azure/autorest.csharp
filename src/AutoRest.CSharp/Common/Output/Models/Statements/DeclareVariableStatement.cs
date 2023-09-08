// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Models.Statements
{
    internal record DeclareVariableStatement(CSharpType? Type, CodeWriterDeclaration Name, ValueExpression Value) : DeclarationStatement
    {
        public DeclareVariableStatement(CSharpType? type, string name, ValueExpression value, out ValueExpression variable)
            : this(type, new CodeWriterDeclaration(name), value)
        {
            variable = Name;
        }
    }
}
