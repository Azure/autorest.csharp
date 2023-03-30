// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record Utf8JsonRequestContentExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Utf8JsonRequestContent), Untyped)
    {
        public static Utf8JsonRequestContentExpression New() => new(Snippets.New(typeof(Utf8JsonRequestContent)));
        public Utf8JsonWriterExpression JsonWriter { get; }  = new(new MemberReference(Untyped, nameof(Utf8JsonRequestContent.JsonWriter)));
    }
}
