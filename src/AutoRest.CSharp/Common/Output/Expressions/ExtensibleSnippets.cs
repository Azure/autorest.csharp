// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal abstract class ExtensibleSnippets
    {
        public abstract JsonElementSnippets JsonElement { get; }
        public abstract XElementSnippets XElement { get; }
        public abstract XmlWriterSnippets XmlWriter { get; }
        public abstract OperationResponseSnippets OperationResponse { get; }

        internal abstract class OperationResponseSnippets
        {
            public abstract TypedValueExpression FromValue(TypedValueExpression value, TypedValueExpression response);
        }

        internal abstract class JsonElementSnippets
        {
            public abstract ValueExpression GetBytesFromBase64(JsonElementExpression element, string? format);
            public abstract ValueExpression GetChar(JsonElementExpression element);
            public abstract ValueExpression GetDateTimeOffset(JsonElementExpression element, string? format);
            public abstract ValueExpression GetObject(JsonElementExpression element);
            public abstract ValueExpression GetTimeSpan(JsonElementExpression element, string? format);

            public abstract MethodBodyStatement ThrowNonNullablePropertyIsNull(JsonPropertyExpression property);
        }

        internal abstract class XElementSnippets
        {
            public abstract ValueExpression GetBytesFromBase64Value(XElementExpression xElement, string? format);
            public abstract ValueExpression GetDateTimeOffsetValue(XElementExpression xElement, string? format);
            public abstract ValueExpression GetObjectValue(XElementExpression xElement, string? format);
            public abstract ValueExpression GetTimeSpanValue(XElementExpression xElement, string? format);
        }

        internal abstract class XmlWriterSnippets
        {
            public abstract MethodBodyStatement WriteValue(XmlWriterExpression xmlWriter, ValueExpression value, string format);
            public abstract MethodBodyStatement WriteObjectValue(XmlWriterExpression xmlWriter, ValueExpression value, string? nameHint);
        }

        protected static InvokeStaticMethodExpression InvokeExtension(CSharpType extensionType, ValueExpression instance, string methodName)
            => new(extensionType, methodName, new[] { instance }, CallAsAsync: false, CallAsExtension: true);

        protected static InvokeStaticMethodExpression InvokeExtension(CSharpType extensionType, ValueExpression instance, string methodName, ValueExpression arg)
            => new(extensionType, methodName, new[] { instance, arg }, CallAsAsync: false, CallAsExtension: true);
    }
}
