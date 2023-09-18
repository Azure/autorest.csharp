// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Models.Statements
{
    internal record DeclareVariableStatement(CSharpType? Type, CodeWriterDeclaration Name, ValueExpression Value) : DeclarationStatement
    {
        public DeclareVariableStatement(CSharpType type, string name, ValueExpression value)
            : this(type, new CodeWriterDeclaration(name), value)
        { }

        public DeclareVariableStatement(string name, ValueExpression value)
            : this(null, new CodeWriterDeclaration(name), value)
        { }

        public DeclareVariableStatement(CSharpType type, string name, ValueExpression value, out ValueExpression variable)
            : this(type, new CodeWriterDeclaration(name), value)
        {
            variable = new VariableReference(type, Name);
        }

        public DeclareVariableStatement(string name, TypedValueExpression value, out ValueExpression variable)
            : this(null, new CodeWriterDeclaration(name), value)
        {
            variable = new VariableReference(value.Type, Name);
        }
    }
}
