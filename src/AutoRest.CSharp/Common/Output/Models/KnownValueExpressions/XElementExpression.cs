// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
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
    }

    internal sealed record XAttributeExpression(ValueExpression Untyped) : TypedValueExpression<XAttribute>(Untyped)
    {
        public XNameExpression Name => new(Property(nameof(XAttribute.Name)));
        public StringExpression Value => new(Property(nameof(XAttribute.Value)));
    }
}
