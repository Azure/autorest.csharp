// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record XElementExpression(ValueExpression Untyped) : TypedValueExpression(typeof(XElement), Untyped)
    {
        public XNameExpression Name => new(new MemberExpression(Untyped, nameof(XElement.Name)));
        public StringExpression Value => new(new MemberExpression(Untyped, nameof(XElement.Value)));

        public XAttributeExpression Attribute(string name)
            => new(Untyped.Invoke(nameof(XElement.Attribute), Snippets.Literal(name)));

        public ValueExpression GetBytesFromBase64Value(string? format)
            => InvokeStaticMethodExpression.Extension(typeof(XElementExtensions), nameof(XElementExtensions.GetBytesFromBase64Value), Untyped, Snippets.Literal(format));
        public ValueExpression GetDateTimeOffsetValue(string? format)
            => InvokeStaticMethodExpression.Extension(typeof(XElementExtensions), nameof(XElementExtensions.GetDateTimeOffsetValue), Untyped, Snippets.Literal(format));
        public ValueExpression GetObjectValue(string? format)
            => InvokeStaticMethodExpression.Extension(typeof(XElementExtensions), nameof(XElementExtensions.GetObjectValue), Untyped, Snippets.Literal(format));
        public ValueExpression GetTimeSpanValue(string? format)
            => InvokeStaticMethodExpression.Extension(typeof(XElementExtensions), nameof(XElementExtensions.GetTimeSpanValue), Untyped, Snippets.Literal(format));
    }

    internal sealed record XAttributeExpression(ValueExpression Untyped) : TypedValueExpression(typeof(XAttribute), Untyped)
    {
        public XNameExpression Name => new(new MemberExpression(Untyped, nameof(XAttribute.Name)));
        public StringExpression Value => new(new MemberExpression(Untyped, nameof(XAttribute.Value)));
    }
}
