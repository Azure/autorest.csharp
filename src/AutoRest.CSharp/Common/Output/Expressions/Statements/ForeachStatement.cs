// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record ForeachStatement(CSharpType? ItemType, CodeWriterDeclaration Item, ValueExpression Enumerable, bool IsAsync = false, bool UseVarAsItemType = false) : MethodBodyStatement, IEnumerable<MethodBodyStatement>
    {
        private readonly List<MethodBodyStatement> _body = new();
        public IReadOnlyList<MethodBodyStatement> Body => _body;

        public ForeachStatement(string itemName, EnumerableExpression enumerable, out ValueExpression item, bool useVarAsItemType = false)
            : this(enumerable.ItemType, new CodeWriterDeclaration(itemName), enumerable, UseVarAsItemType: useVarAsItemType)
        {
            item = new VariableReference(enumerable.ItemType, Item);
        }

        public ForeachStatement(string itemName, EnumerableExpression enumerable, bool isAsync, out ValueExpression item)
            : this(enumerable.ItemType, new CodeWriterDeclaration(itemName), enumerable, isAsync, true)
        {
            item = new VariableReference(enumerable.ItemType, Item);
        }

        public ForeachStatement(string itemName, DictionaryExpression dictionary, out KeyValuePairExpression item)
            : this(null, new CodeWriterDeclaration(itemName), dictionary) // TODO -- figure out the type here
        {
            item = new KeyValuePairExpression(new VariableReference(dictionary.ValueType, Item));
        }

        public void Add(MethodBodyStatement statement) => _body.Add(statement);
        public IEnumerator<MethodBodyStatement> GetEnumerator() => _body.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((System.Collections.IEnumerable)_body).GetEnumerator();
    }
}
