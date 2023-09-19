// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record Utf8JsonRequestContentExpression(ValueExpression Untyped) : TypedValueExpression<Utf8JsonRequestContent>(Untyped)
    {
        public Utf8JsonWriterExpression JsonWriter => new(Property(nameof(Utf8JsonRequestContent.JsonWriter)));
    }
}
