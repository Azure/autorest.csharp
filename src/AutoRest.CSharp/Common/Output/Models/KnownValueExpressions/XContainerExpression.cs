// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record XContainerExpression(ValueExpression Untyped) : TypedValueExpression(typeof(XContainer), Untyped)
    {
        public XElementExpression Element(string name) => new(new InvokeInstanceMethodExpression(Untyped, nameof(XDocument.Element), Snippets.Literal(name)));
        public DictionaryExpression Elements() => new(new InvokeInstanceMethodExpression(Untyped, nameof(XDocument.Elements)));
        public EnumerableExpression Elements(string name) => new(new InvokeInstanceMethodExpression(Untyped, nameof(XDocument.Elements), Snippets.Literal(name)));
    }
}
