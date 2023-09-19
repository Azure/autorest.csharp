// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record XNameExpression(ValueExpression Untyped) : TypedValueExpression<XName>(Untyped)
    {
        public StringExpression LocalName => new(Property(nameof(XName.LocalName)));
    }
}
