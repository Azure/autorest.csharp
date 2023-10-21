// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal class AzureExtensibleSnippets : ExtensibleSnippets
    {
        public override JsonElementSnippets JsonElement { get; } = new AzureJsonElementSnippets();
        public override XElementSnippets XElement { get; } = new AzureXElementSnippets();
        public override XmlWriterSnippets XmlWriter { get; } = new AzureXmlWriterSnippets();
        public override OperationResponseSnippets OperationResponse { get; } = new AzureOperationResponseSnippets();

        internal class AzureOperationResponseSnippets : OperationResponseSnippets
        {
            public override TypedValueExpression FromValue(TypedValueExpression value, TypedValueExpression response)
                => ResponseExpression.FromValue(value, new ResponseExpression(response).GetRawResponse());
        }

        private class AzureJsonElementSnippets : JsonElementSnippets
        {
            public override ValueExpression GetBytesFromBase64(JsonElementExpression element, string? format) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetBytesFromBase64), Literal(format));
            public override ValueExpression GetChar(JsonElementExpression element) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetChar));
            public override ValueExpression GetDateTimeOffset(JsonElementExpression element, string? format) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetDateTimeOffset), Literal(format));
            public override ValueExpression GetObject(JsonElementExpression element) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetObject));
            public override ValueExpression GetTimeSpan(JsonElementExpression element, string? format) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetTimeSpan), Literal(format));

            public override MethodBodyStatement ThrowNonNullablePropertyIsNull(JsonPropertyExpression property)
                => new InvokeStaticMethodStatement(typeof(JsonElementExtensions), nameof(JsonElementExtensions.ThrowNonNullablePropertyIsNull), new[] { property }, CallAsExtension: true);
        }

        private class AzureXElementSnippets : XElementSnippets
        {
            public override ValueExpression GetBytesFromBase64Value(XElementExpression xElement, string? format)
                => InvokeExtension(typeof(XElementExtensions), xElement, nameof(XElementExtensions.GetBytesFromBase64Value), Literal(format));
            public override ValueExpression GetDateTimeOffsetValue(XElementExpression xElement, string? format)
                => InvokeExtension(typeof(XElementExtensions), xElement, nameof(XElementExtensions.GetDateTimeOffsetValue), Literal(format));
            public override ValueExpression GetObjectValue(XElementExpression xElement, string? format)
                => InvokeExtension(typeof(XElementExtensions), xElement, nameof(XElementExtensions.GetObjectValue), Literal(format));
            public override ValueExpression GetTimeSpanValue(XElementExpression xElement, string? format)
                => InvokeExtension(typeof(XElementExtensions), xElement, nameof(XElementExtensions.GetTimeSpanValue), Literal(format));
        }

        private class AzureXmlWriterSnippets : XmlWriterSnippets
        {
            public override MethodBodyStatement WriteValue(XmlWriterExpression xmlWriter, ValueExpression value, string format)
                => new InvokeStaticMethodStatement(typeof(XmlWriterExtensions), nameof(XmlWriterExtensions.WriteValue), new[] { xmlWriter, value, Snippets.Literal(format) }, CallAsExtension: true);

            public override MethodBodyStatement WriteObjectValue(XmlWriterExpression xmlWriter, ValueExpression value, string? nameHint)
                => new InvokeStaticMethodStatement(typeof(XmlWriterExtensions), nameof(XmlWriterExtensions.WriteObjectValue), new[] { xmlWriter, value, Snippets.Literal(nameHint) }, CallAsExtension: true);
        }
    }
}
