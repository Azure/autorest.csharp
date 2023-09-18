// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record XDocumentExpression(ValueExpression Untyped) : TypedValueExpression(typeof(XDocument), Untyped)
    {
        public static XDocumentExpression Load(StreamExpression stream, LoadOptions loadOptions)
            => new(new InvokeStaticMethodExpression(typeof(XDocument), nameof(XDocument.Load), new[]{stream, FrameworkEnumValue(loadOptions)}));

        public XElementExpression Element(string name) => new(Untyped.Invoke(nameof(XDocument.Element), Literal(name)));
    }
}
