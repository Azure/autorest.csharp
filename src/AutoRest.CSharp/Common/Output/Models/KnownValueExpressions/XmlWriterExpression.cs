// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Serialization;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record XmlWriterExpression(ValueExpression Untyped) : TypedValueExpression(typeof(XmlWriter), Untyped)
    {
        public XmlWriterExpression(CodeWriterDeclaration variable) : this(new VariableReference(typeof(XmlWriter), variable)){}

        public MethodBodyStatement WriteStartAttribute(string localName) => new InvokeInstanceMethodStatement(Untyped, nameof(XmlWriter.WriteStartAttribute), Snippets.Literal(localName));
        public MethodBodyStatement WriteEndAttribute() => new InvokeInstanceMethodStatement(Untyped, nameof(XmlWriter.WriteEndAttribute));

        public MethodBodyStatement WriteStartElement(string localName) => WriteStartElement(Snippets.Literal(localName));
        public MethodBodyStatement WriteStartElement(ValueExpression localName) => new InvokeInstanceMethodStatement(Untyped, nameof(XmlWriter.WriteStartElement), localName);
        public MethodBodyStatement WriteEndElement() => new InvokeInstanceMethodStatement(Untyped, nameof(XmlWriter.WriteEndElement));

        public MethodBodyStatement WriteValue(ValueExpression value) => new InvokeInstanceMethodStatement(Untyped, nameof(XmlWriter.WriteValue), value);
        public MethodBodyStatement WriteValue(ValueExpression value, string format)
            => new InvokeStaticMethodStatement(typeof(XmlWriterExtensions), nameof(XmlWriterExtensions.WriteValue), new[]{Untyped, value, Snippets.Literal(format)}, CallAsExtension: true);

        public MethodBodyStatement WriteValue(ValueExpression value, Type frameworkType, SerializationFormat format)
        {
            bool writeFormat = frameworkType == typeof(byte[]) ||
                               frameworkType == typeof(DateTimeOffset) ||
                               frameworkType == typeof(DateTime) ||
                               frameworkType == typeof(TimeSpan);
            return writeFormat && format.ToFormatSpecifier() is { } formatSpecifier
                ? WriteValue(value, formatSpecifier)
                : WriteValue(value);
        }

        public MethodBodyStatement WriteObjectValue(ValueExpression value, string? nameHint)
            => new InvokeStaticMethodStatement(typeof(XmlWriterExtensions), nameof(XmlWriterExtensions.WriteObjectValue), new[]{Untyped, value, Snippets.Literal(nameHint)}, CallAsExtension: true);
    }
}
