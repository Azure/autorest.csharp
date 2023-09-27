// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record UsingStatement(CSharpType? Type, CodeWriterDeclaration Name, ValueExpression Value) : MethodBodyStatement, IEnumerable<MethodBodyStatement>
    {
        private readonly List<MethodBodyStatement> _body = new();
        public IReadOnlyList<MethodBodyStatement> Body => _body;

        public UsingStatement(CSharpType type, string name, ValueExpression value, out VariableReference variable) : this(type, new CodeWriterDeclaration(name), value)
        {
            variable = new VariableReference(type, Name);
        }

        public void Add(MethodBodyStatement statement) => _body.Add(statement);
        public IEnumerator<MethodBodyStatement> GetEnumerator() => _body.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((System.Collections.IEnumerable)_body).GetEnumerator();
    }
}
