// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record ForStatement(CSharpType ItemType, CodeWriterDeclaration Indexer, CodeWriterDeclaration Item, ValueExpression Enumerable) : MethodBodyStatement, IEnumerable<MethodBodyStatement>
    {
        private readonly List<MethodBodyStatement> _body = new();
        public IReadOnlyList<MethodBodyStatement> Body => _body;

        public ForStatement(CSharpType itemType, string indexerName, string itemName, ListExpression enumerable, out TypedValueExpression indexer, out TypedValueExpression item)
            : this(itemType, new CodeWriterDeclaration(indexerName), new CodeWriterDeclaration(itemName), enumerable)
        {
            indexer = new VariableReference(typeof(int), Indexer);
            item = new VariableReference(ItemType, Item);
        }

        public void Add(MethodBodyStatement statement) => _body.Add(statement);
        public IEnumerator<MethodBodyStatement> GetEnumerator() => _body.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_body).GetEnumerator();
    }
}
