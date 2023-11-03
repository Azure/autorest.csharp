// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base
{
    internal abstract record BaseUtf8JsonRequestContentExpression(CSharpType Type, ValueExpression Untyped) : TypedValueExpression(Type, Untyped)
    {
        public Utf8JsonWriterExpression JsonWriter => new(Property(nameof(Utf8JsonRequestContent.JsonWriter)));
    }
}
