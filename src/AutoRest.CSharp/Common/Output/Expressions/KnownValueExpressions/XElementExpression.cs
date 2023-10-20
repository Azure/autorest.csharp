// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record XElementExpression(ValueExpression Untyped) : TypedValueExpression<XElement>(Untyped)
    {
        public XNameExpression Name => new(Property(nameof(XElement.Name)));
        public StringExpression Value => new(Property(nameof(XElement.Value)));

        public XAttributeExpression Attribute(string name)
            => new(Invoke(nameof(XElement.Attribute), Snippets.Literal(name)));

        public ValueExpression GetBytesFromBase64Value(string? format)
            => InvokeExtension(typeof(XElementExtensions), nameof(XElementExtensions.GetBytesFromBase64Value), Snippets.Literal(format));
        public ValueExpression GetDateTimeOffsetValue(string? format)
            => InvokeExtension(typeof(XElementExtensions), nameof(XElementExtensions.GetDateTimeOffsetValue), Snippets.Literal(format));
        public ValueExpression GetObjectValue(string? format)
            => InvokeExtension(typeof(XElementExtensions), nameof(XElementExtensions.GetObjectValue), Snippets.Literal(format));
        public ValueExpression GetTimeSpanValue(string? format)
            => InvokeExtension(typeof(XElementExtensions), nameof(XElementExtensions.GetTimeSpanValue), Snippets.Literal(format));

        public static XElementExpression Load(StreamExpression stream) => new(new InvokeStaticMethodExpression(typeof(XElement), nameof(XElement.Load), new[] { stream }));
    }
}
