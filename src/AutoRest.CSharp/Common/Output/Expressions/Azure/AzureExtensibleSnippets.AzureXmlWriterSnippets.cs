// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.Azure
{
    internal partial class AzureExtensibleSnippets
    {
        private class AzureXmlWriterSnippets : XmlWriterSnippets
        {
            public override MethodBodyStatement WriteValue(XmlWriterExpression xmlWriter, ValueExpression value, string format)
                => XmlWriterExtensionsProvider.Instance.WriteValue(xmlWriter, value, format);

            public override MethodBodyStatement WriteObjectValue(XmlWriterExpression xmlWriter, ValueExpression value, string? nameHint)
                => XmlWriterExtensionsProvider.Instance.WriteObjectValue(xmlWriter, value, nameHint);
        }
    }
}
