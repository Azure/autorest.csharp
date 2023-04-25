// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record XmlWriterContentExpression(ValueExpression Untyped) : TypedValueExpression(typeof(XmlWriterContent), Untyped)
    {
        public static XmlWriterContentExpression New() => new(Snippets.New(typeof(XmlWriterContent)));
        public XmlWriterExpression XmlWriter { get; }  = new(new MemberReference(Untyped, nameof(XmlWriterContent.XmlWriter)));
        public static implicit operator RequestContentExpression(XmlWriterContentExpression xmlWriterContent) => new(xmlWriterContent.Untyped);
    }
}
